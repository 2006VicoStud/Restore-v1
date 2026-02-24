using System;
using API.Data;
using API.DTO;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BasketController(StoreContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
        var basket = await RetrieveBasket(); 

        if (basket == null) return NoContent(); 

        return basket.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity)
    {
        var basket = await RetrieveBasket() ?? CreatedBasket();

        var product = await context.Products.FindAsync(productId);

        if (product == null) return BadRequest("Problem adding item to the basket");

        basket.AddItem(product, quantity);

        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetBasket), basket.ToDto());

        return BadRequest("Problem updating the basket");
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
    {
        var basket = await RetrieveBasket();

        if (basket == null) return BadRequest("Problem updating the basket");

        basket.RemoveItem(productId, quantity); 
        
        var result = await context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Problem updating the basket");
    }

    private async Task<Basket?> RetrieveBasket()
    {
        return await context.Baskets
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.BasketId == Request.Cookies["basketId"]);
    }

    
    private Basket CreatedBasket()
    {
        var basketId = Guid.NewGuid().ToString();
        var cookiesOptions = new CookieOptions
        {
            IsEssential = true,
            Expires = DateTime.UtcNow.AddDays(30),
        };
        Response.Cookies.Append("basketId", basketId, cookiesOptions);
        var basket = new Basket {BasketId = basketId};
        context.Baskets.Add(basket);
        return basket;
    }
}
