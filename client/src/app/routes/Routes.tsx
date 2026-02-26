import { createBrowserRouter, Navigate } from "react-router-dom";
import App from "../layout/App";
import Catalog from "../../features/catalog/Catalog";
import ProductDetails from "../../features/catalog/ProductDetails";
import HomePage from "../../features/home/HomePage";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import NotFound from "../store/errors/NotFound";
import ServerError from "../store/errors/ServerError";
import BasketPage from "../../features/basket/BasketPage";
import CheckoutPage from "../../features/checkout/CheckoutPage";
import LoginForm from "../../features/account/LoginForm";
import RegisterForm from "../../features/account/RegisterForm";
import RequiredAuth from "./RequiredAuth";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            { element: <RequiredAuth />, children: [
                { path: 'checkout', element: <CheckoutPage/> },
            ]},
            { path: '', element: <HomePage/> }, 
            { path: 'catalog', element: <Catalog/> }, 
            { path: 'catalog/:id', element: <ProductDetails/> }, 
            { path: 'about', element: <AboutPage/> }, 
            { path: 'contact', element: <ContactPage/> },
            { path: 'basket', element: <BasketPage/> },
            
            { path: 'server-error', element: <ServerError/> },
            { path: 'login', element: <LoginForm/> },
            { path: 'register', element: <RegisterForm/> },
            { path: 'not-found', element: <NotFound/> }, 
            { path: '*', element: <Navigate replace to='/not-found'/> },
        ]
    }
],)