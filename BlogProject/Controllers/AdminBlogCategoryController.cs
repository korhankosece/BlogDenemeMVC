using BlogProject.Models.ORM;
using BlogProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class AdminBlogCategoryController : Controller
    {
        BlogProjectContext _context;

        public AdminBlogCategoryController()
        {
            _context = new BlogProjectContext();
        }

        public IActionResult Index()
        {
            List<BlogCategoryVM> model = _context.BlogCategories.Where(q => q.IsDeleted == false).Select(q => new BlogCategoryVM()
            {
                ID = q.Id,
                Name = q.Name
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlogCategoryVM blogCategoryVM)
        {
            BlogCategory blogCategory = new BlogCategory();
            blogCategory.Name = blogCategoryVM.Name;

            _context.BlogCategories.Add(blogCategory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            BlogCategory category = _context.BlogCategories.FirstOrDefault(q => q.Id == Id);
            BlogCategoryVM blogCategoryVM = new BlogCategoryVM()
            {
                ID = category.Id,
                Name = category.Name
            };

            return View(blogCategoryVM);
        }

        [HttpPost]
        public IActionResult Edit(BlogCategoryVM blogCategoryVM)
        {
            BlogCategory category = _context.BlogCategories.FirstOrDefault(q => q.Id == blogCategoryVM.ID);
            category.Name = blogCategoryVM.Name;

            _context.BlogCategories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            BlogCategory category = _context.BlogCategories.FirstOrDefault(q => q.Id == Id);
            category.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
