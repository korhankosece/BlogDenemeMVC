using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Models.ORM;
using BlogProject.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        BlogProjectContext _context;

        public HomeController()
        {
            _context = new BlogProjectContext();
        }
        public IActionResult Index()
        {
            List<BlogDetailVM> blogDetailVms = _context.Blogs.Where(p => p.IsDeleted == false)
                .Select(q => new BlogDetailVM()
                {
                    ID = q.Id,
                    Title = q.Title,
                    Subtitle = q.Subtitle,
                    AddDate = q.AddDate
                }).ToList();

            return View(blogDetailVms);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult SamplePost()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Blog blog = _context.Blogs.Include(p=>p.BlogCategory).FirstOrDefault(p => p.Id == id);
           BlogDetailVM blogDetailVm = new BlogDetailVM()
            {
                ID = blog.Id,
                Title = blog.Title,
                Subtitle = blog.Subtitle,
                Content = blog.Content,
                CategoryName = blog.BlogCategory.Name,
                AddDate = blog.AddDate,
                MainImagePath = blog.MainImg
            };
            return View(blogDetailVm);
        }

    }
}
