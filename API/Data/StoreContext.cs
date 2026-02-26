using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = "918c6e4c-bb72-4a7b-817e-ebf9a046593e", ConcurrencyStamp = "Member", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "c8eaa6d9-9c63-4819-a238-c7ffbe0752fa", ConcurrencyStamp = "Admin", Name = "Admin", NormalizedName = "ADMIN" }
            );
    }
}