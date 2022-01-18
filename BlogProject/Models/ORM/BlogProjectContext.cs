using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.ORM
{
    public class BlogProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=37.230.108.246; Database=cagatay8_gonzalesdb; UID=user_gonzales; PWD=Hk8$N7@&");
            //optionsBuilder.UseSqlServer(@"Server=.; Database=cagatay8_gonzalesdb; UID=sa; PWD=1234");
        }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }


    }
}
