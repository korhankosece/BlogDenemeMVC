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
        public List<BlogCategoryVM> Categories { get; set; }
    }
}
