using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCardAPI.Models;
using ShoppingCardAPI.Services;

namespace ShoppingCardAPI.Controllers
{
    public class ShoppingCardController : ApiController
    {
        private readonly IShoppingBasketContext _shoppingBasketContext;

        public ShoppingBasketController(IShoppingBasketContext shoppingBasketContext)
        {
            _shoppingBasketContext = shoppingBasketContext;
        }

        [Route("api/ShoppingCard/{cartname}")]
        [HttpGet]
        public IEnumerable<Product> Get(string cartName)
        {
            var shoppingBasket = _shoppingBasketContext.GetShoppingCart(cartName);
            return shoppingBasket;
        }

        [Route("api/ShoppingCard/{cartname}/Checkout")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult CheckOut(string cartName)
        {
            _shoppingBasketContext.Checkout(cartName);
            return Ok();
        }

        [Route("api/ShoppingCard/{cartname}/Add/{productId}/{quantity}")]
        [HttpGet]
        [HttpPut]
        public IHttpActionResult AddProduct(string cartName, int productId, int quantity)
        {
            _shoppingBasketContext.AddProduct(cartName, productId, quantity);
            return Ok();
        }
    }
}
