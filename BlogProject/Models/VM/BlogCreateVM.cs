using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.VM
{
    public class BlogCreateVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public List<BlogCategoryVM> Categories { get; set; }
        public int CategoryId { get; set; }
        public IFormFile blogImage { get; set; }
    }
}
