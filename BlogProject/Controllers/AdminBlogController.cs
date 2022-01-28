using BlogProject.Models.ORM;
using BlogProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

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
                Content =q.Content,
                CategoryName = q.BlogCategory.Name
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<BlogCategoryVM> model = _context.BlogCategories.Where(q => q.IsDeleted == false).Select(q =>
                new BlogCategoryVM()
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
                string imagePath = "";

                if (blogCreateVm.blogImage != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(blogCreateVm.blogImage.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogimage", guid + extension);

                    using (var stream = System.IO.File.Create(path))
                    {
                        blogCreateVm.blogImage.CopyTo(stream);
                    }
                    //using (var stream = new FileStream(path, FileMode.Create))
                    //{
                    //    blogCreateVm.blogImage.CopyTo(stream);
                    //}
                    imagePath = guid + extension;
                }


                blog.Title = blogCreateVm.Title;
                blog.Subtitle = blogCreateVm.Subtitle;
                blog.Content = blogCreateVm.Content;
                blog.MainImg = imagePath;
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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(q => q.Id == Id);
            List<BlogCategoryVM> categories = _context.BlogCategories.Where(q => q.IsDeleted == false).Select(q =>
                new BlogCategoryVM()
                {
                    ID = q.Id,
                    Name = q.Name
                }).ToList();
            BlogVM blogVm = new BlogVM()
            {
                ID = blog.Id,
                Title = blog.Title,
                Subtitle = blog.Subtitle,
                CategoryID = blog.BlogCategoryId,
                Content = blog.Content,
                Categories = categories
            };

            return View(blogVm);
        }

        [HttpPost]
        public IActionResult Edit(BlogVM blogVM)
        {
            Blog blog = _context.Blogs.FirstOrDefault(q => q.Id == blogVM.ID);
            blog.Title = blogVM.Title;
            blog.Subtitle = blogVM.Subtitle;
            blog.BlogCategoryId = blogVM.CategoryID;
            blog.Content = blogVM.Content;

            //kişi foto yükledimi kontrol edilmeli
            //yüklediyse dbden foto ismini yakala
            //    var imagePath = Path.Combine(anadizin, klasör, fotoğraf);
            //if (File.Exists(imagePath))
            //{
            //    File.Delete(imagePath);
            //}

            _context.Blogs.Update(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(q => q.Id == id);
            blog.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}