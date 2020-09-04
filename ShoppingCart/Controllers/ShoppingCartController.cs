using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly MyShoppingCart _shoppingCart;
        public ShoppingCartController(ICourseRepository courseRepository,MyShoppingCart shoppingCart)
        {
            _courseRepository = courseRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            return View(_shoppingCart);
        }

        public RedirectToActionResult AddToShoppingCart(int courseId)
        {
            var selectedCourse = _courseRepository.GetCourseById(courseId);
            _shoppingCart.AddItemToCart(selectedCourse, selectedCourse.Fee);
            return RedirectToAction("Index");

        }

        public RedirectToActionResult RemoveFromShoppingCart(int courseId)
        {
            var selectedCourse = _courseRepository.GetCourseById(courseId);
            _shoppingCart.RemoveItemFromCart(selectedCourse);
            return RedirectToAction("Index");

        }
    }
}
