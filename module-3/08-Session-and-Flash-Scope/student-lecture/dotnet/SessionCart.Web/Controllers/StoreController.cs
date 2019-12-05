using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.DAL;
using SessionCart.Web.Models;
using SessionControllerData;

namespace SessionCart.Web.Controllers
{
    public class StoreController : SessionController
    {
        private const string CART_KEY = "ShoppingCart";

        IProductDAO _db = null;
        
        public StoreController(IProductDAO db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            var products = _db.GetProducts();
            return View(products);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            UpdateCart(productId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ShowCart()
        {
            var cart = GetShoppingCart();
            return View(cart.Items);
        }

        private void UpdateCart(int productId)
        {
            // Check session for shopping cart
            var cart = GetShoppingCart();

            // Add item to cart
            var product = _db.GetProduct(productId);
            cart.AddToCart(product, 1);

            SaveShoppingCart(cart);
        }

        private void SaveShoppingCart(ShoppingCart cart)
        {
            SetSessionData(CART_KEY, cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            // Check session for shopping cart
            var cart = GetSessionData<ShoppingCart>(CART_KEY);

            // If it is not present create and add it
            if (cart == null)
            {
                cart = new ShoppingCart();
                SetSessionData(CART_KEY, cart);
            }

            return cart;
        }

    }
}