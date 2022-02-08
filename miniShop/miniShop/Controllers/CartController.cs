using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniShop.Models;
using miniShop.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;



        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var items = GetCartFromSession();
            return View(items);
        }

        public IActionResult AddProductToCart(int id)
        {
            var product = productService.GetProductById(id);
            var cart = GetCartFromSession();
            cart.AddItem(product, 1);
            saveToCard(cart);
            //Sepete ekleme senaryosunda Session yalnızca ilk ürün ekleme esnasında oluşur.
            return Redirect("/");
        }

        private void saveToCard(Cart cart)
        {
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        private Cart GetCartFromSession()
        {
            if (HttpContext.Session.Get("cart")==null)
            {
                Cart cart = new Cart();
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }

            var cartInSession = HttpContext.Session.GetString("cart");
            var cartObject = JsonConvert.DeserializeObject<Cart>(cartInSession);

            return cartObject;
        }
    }
}
