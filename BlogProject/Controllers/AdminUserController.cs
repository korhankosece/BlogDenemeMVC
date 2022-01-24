using BlogProject.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BlogProject.Models.VM;

namespace BlogProject.Controllers
{
    public class AdminUserController : Controller
    {
        BlogProjectContext _context;

        public AdminUserController()
        {
            _context = new BlogProjectContext();
        }

        public IActionResult Index()
        {
            List<AdminUserVM> model = _context.AdminUsers.Where(p => p.IsDeleted == false).Select(q => new AdminUserVM()
            {
                Id = q.Id,
                Email = q.Email,
                Password = q.Password,
                LastLoginDate = q.LastLoginDate
            }).ToList();
            return View(model);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminUserVM adminUserVm)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = new AdminUser();
                adminUser.Email = adminUserVm.Email;
                adminUser.Password = adminUserVm.Password;

                _context.AdminUsers.Add(adminUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Edit(int id)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(p => p.Id == id);
            AdminUserVM adminUserVm = new AdminUserVM();
            adminUserVm.Id = adminUser.Id;
            adminUserVm.Email = adminUser.Email;
            adminUserVm.Password = adminUser.Password;
            adminUserVm.ConfirmPassword = adminUser.Password;

            return View(adminUserVm);
        }

        [HttpPost]
        public IActionResult Edit(AdminUserVM adminUserVm)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = _context.AdminUsers.FirstOrDefault(p => p.Id == adminUserVm.Id);
                adminUser.Id = adminUserVm.Id;
                adminUser.Email = adminUserVm.Email;
                adminUser.Password = adminUserVm.Password;
                _context.AdminUsers.Update(adminUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminUserVm);
        }

        public IActionResult Delete(int Id)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(p => p.Id == Id);
            adminUser.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
