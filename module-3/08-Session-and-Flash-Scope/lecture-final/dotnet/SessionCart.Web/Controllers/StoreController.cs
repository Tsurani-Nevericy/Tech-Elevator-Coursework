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
        /* Steps
           1. (StoreController)    Create Index Action for store/index
           2. (Index View)         Create Index View for store/index
           TEST
           3. (Startup.cs)        Configure DI container to inject IProductDAL > FakeProductDAL
           4. (StoreController)    Enable constructor injection for IProductDAL
           5. (StoreController)    Update Index Action to pass products
           6. (Index View)         Display Products
           TEST
           7. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                   Pass Product Id in Form
           8. (StoreController)    Create POST Index Action for store/index, accept product id & 
                                   redirect to store/viewcart            
           9. (StoreController)    Create ViewCart action for store/viewcart
           10.(ViewCart View)      Display empty View Cart View
           TEST
           11.(StoreController)    POST store/index: retrieve product and add to active
                                   shopping cart
           12.(ShoppingCart)       Create Shopping Cart class to add Product & Quantity
           13.(StoreController)    Guarantee ShoppingCart is in session, create if not
           14.(StoreController)    POST store/index: Update shopping cart with new product
           15.(StoreController)    GET store/viewcart: Retrieve shoping cart from session
           16.(ViewCart View)      Bind go ShoppingCart and disply each product in it
       */

        IProductDAO dao;
        public StoreController(IProductDAO dao, IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            var products = dao.GetProducts();

            return View(products);
        }

        [HttpPost]
        public ActionResult AddToCart(Product product, int quantity)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            product = dao.GetProduct(product.Id);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, 1);

            //3. Save shopping cart
            SaveActiveShoppingCart(cart);

            return RedirectToAction("ViewCart");
        }


        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Get the product associated with the id
            var product = dao.GetProduct(id);

            // Find the active shopping cart
            var cart = GetActiveShoppingCart();

            // Remove Qty 1 of product from shopping cart
            cart.RemoveOne(product);

            // Save shopping cart
            SaveActiveShoppingCart(cart);

            // Redirect to ViewCart
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session            
            if (GetSessionData<ShoppingCart>("Shopping_Cart") == null)
            {
                cart = new ShoppingCart();
                SaveActiveShoppingCart(cart);                
            }
            else
            {
                cart = GetSessionData<ShoppingCart>("Shopping_Cart"); // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            SetSessionData("Shopping_Cart", cart);        // <-- saves the shopping cart into session
        }
    }
}