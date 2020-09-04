using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class ShoppingCatalogueController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ShoppingCatalogueController(ICourseRepository courseRepository,
                                            ICategoryRepository categoryRepository)
        {
            this._courseRepository = courseRepository;
            this._categoryRepository = categoryRepository;
        }
        
        public ViewResult List()
        {
            //ViewBag.SelectedCategory = _categoryRepository.AllCategories.ToList()[2].Name; 
            //return View(_courseRepository.AllCourses);
            CourseListVM courseListVM = new CourseListVM()
            {
                Courses = _courseRepository.AllCourses,             
                SelectedCategoryName = _categoryRepository.AllCategories.ToList()[2].Name
            };

            return View(courseListVM);
          
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            return View(course);
        }
    }
}
