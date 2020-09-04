using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class MockCourseRepository : ICourseRepository
    {
        public readonly ICategoryRepository categoryRepository;
        public MockCourseRepository(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }
        public IEnumerable<Course> AllCourses => new List<Course>
        {
            new Course{CourseId=1,
            Title="ASP.NET core",
            Description="Build first ASP core application",
            Fee=1350,
            IsWeekendClassAvailable=true,
            ImageURL="https://blog.tech-fellow.net/content/images/size/w2000/2018/01/aspnetcore.jpg",
            Category= categoryRepository.AllCategories.ToList()[0]},
            
            new Course{CourseId=2,
            Title="Mean Stack",
            Description="Learn Mean Stack development",
            Fee=2000,
            IsWeekendClassAvailable=true,
            ImageURL="https://miro.medium.com/max/700/1*P8aGpuAxcVXgO4m7cByVtA.jpeg",
            Category= categoryRepository.AllCategories.ToList()[1]},

            new Course{CourseId=3,
            Title="Mern Stack",
            Description="Hands on in mErn Stack development",
            Fee=2000,
            IsWeekendClassAvailable=true,
            ImageURL="https://res.cloudinary.com/practicaldev/image/fetch/s--tSq3pK63--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://dev-to-uploads.s3.amazonaws.com/i/j71o6fyry39eaz1eyjna.jpg",
            Category= categoryRepository.AllCategories.ToList()[0]},

            new Course{CourseId=4,
            Title="Data analysis using Python",
            Description="Use python for data analysis and development",
            Fee=1200,
            IsWeekendClassAvailable=true,
            ImageURL="https://ictslab.com/wp-content/uploads/2019/03/d1326ca6cca8038cd115a061b4e2b3bc-840x430.png",
            Category= categoryRepository.AllCategories.ToList()[0]}
        };

        IEnumerable<Course> ICourseRepository.FreeCoursesOfThWeek { get; }

        public Course GetCourseById(int courseId)
        {
            return AllCourses.FirstOrDefault(c => c.CourseId == courseId);
        }
        
    }
}
