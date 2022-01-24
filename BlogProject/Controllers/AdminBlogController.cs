using BlogProject.Models.ORM;
using BlogProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogProject.Controllers
{
    public class AdminBlogController : Controller
    {
        BlogProjectContext _context;
        public AdminBlogController()
        {
            _context = new BlogProjectContext();
        }

        public IActionResult BlogList()
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
        public IActionResult AddBlog()
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


    }
}
