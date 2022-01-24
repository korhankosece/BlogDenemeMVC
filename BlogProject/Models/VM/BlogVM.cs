using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.VM
{
    public class BlogVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<BlogCategoryVM> Categories { get; set; }

    }
}
