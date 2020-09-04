using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class EFCourseRepository : ICourseRepository
    {
        private readonly AppDBContext _appDBContext;
        public EFCourseRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IEnumerable<Course> AllCourses {
            get
            {
                IEnumerable<Course> course = _appDBContext.Courses.Include(c => c.Category);
                //return _appDBContext.Courses.Include(c=>c.Category);
                return course;
            }
        }

        public IEnumerable<Course> FreeCoursesOfThWeek => throw new NotImplementedException();

        public Course GetCourseById(int courseId)
        {
            return _appDBContext.Courses.Include(c=> c.Category).FirstOrDefault(c => c.CourseId == courseId);
        }
    }
}
