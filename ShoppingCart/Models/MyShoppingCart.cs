using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class MyShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private readonly AppDBContext _appDBContext;
        public MyShoppingCart(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public static MyShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            string ShoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();
            session.SetString("ShoppingCartId", ShoppingCartId);
            var context = services.GetService<AppDBContext>();
            return new MyShoppingCart(context) { ShoppingCartId = ShoppingCartId };

        }

        public void AddItemToCart(Course course, decimal amount)
        {
            var ShoppingCartItem = _appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Course.CourseId == course.CourseId && s.ShoppingCartId == this.ShoppingCartId
                );
            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Course = course,
                    Amount = amount
                };
                _appDBContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {

            }

            _appDBContext.SaveChanges();
        }

        public void RemoveItemFromCart(Course course)
        {
            var ShoppingCartItem = _appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Course.CourseId == course.CourseId && s.ShoppingCartId == this.ShoppingCartId
                );
            if (ShoppingCartItem! == null)
            {
                _appDBContext.ShoppingCartItems.Remove(ShoppingCartItem);
            }
            else
            {

            }

            _appDBContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            this.ShoppingCartItems = _appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId
                ).Include(cart => cart.Course).ToList();
            return this.ShoppingCartItems;
        }

        public decimal GetTotalOfCart()
        {
            return _appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId)
                .Select(c => c.Amount).Sum();
        }

        public void ClearShoppingCart()
        {
            var ShoppingCartItems = _appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId
                );
            _appDBContext.ShoppingCartItems.RemoveRange(ShoppingCartItems);
            _appDBContext.SaveChanges();
        }
    }
}
