using BlogProject.Models.ORM;
using BlogProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class AdminBlogController : Controller
    {
        BlogProjectContext _context;
        public AdminBlogController()
        {
            _context = new BlogProjectContext();
        }

        public IActionResult Index()
        {
            List<BlogVM> model = _context.Blogs.Where(q => q.IsDeleted == false).Select(q => new BlogVM()
            {
                ID = q.Id,
                Title = q.Title,
                Subtitle = q.Subtitle,
                CategoryName = q.BlogCategory.Name
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<BlogCategoryVM> model = _context.BlogCategories.Where(q => q.IsDeleted == false).Select(q => new BlogCategoryVM()
            {
                ID = q.Id,
                Name = q.Name
            }).ToList();

            BlogCreateVM blogCreateVM = new BlogCreateVM();
            blogCreateVM.Categories = model;

            return View(blogCreateVM);
        }

        [HttpPost]
        public IActionResult Add(BlogCreateVM blogCreateVm)
        {
            
            Blog blog = new Blog();
            if (ModelState.IsValid)
            {
                blog.Title = blogCreateVm.Title;
                blog.Subtitle = blogCreateVm.Subtitle;
                blog.BlogCategoryId = blogCreateVm.CategoryId;
                _context.Blogs.Add(blog);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(blogCreateVm);
            }

        }


    }
}
