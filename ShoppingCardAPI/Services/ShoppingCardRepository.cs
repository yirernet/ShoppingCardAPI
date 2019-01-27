using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCardAPI.Models;

namespace ShoppingCardAPI.Services
{
    public class ShoppingCardRepository
    {
        private const string CacheKey = "ShoppingCardStore";

        public ShoppingCardRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var basket = new ShoppingCard[]
                    {
                new ShoppingCard
                {
                    Id = 1, Quantity = 2
                },
                new ShoppingCard
                {
                    Id = 2, Quantity = 34
                }
                    };

                    ctx.Cache[CacheKey] = basket;
                }
            }
        }
        public ShoppingCard[] GetAllBaskets()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (ShoppingCard[])ctx.Cache[CacheKey];
            }

            return new ShoppingCard[]
            {
                new ShoppingCard
                {
                    Id = 0,
                    Quantity = 0
                },           
            };
        }

        public bool SaveBasket(ShoppingCard basket)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((ShoppingCard[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(basket);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}