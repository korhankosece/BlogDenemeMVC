using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.VM
{
    public class BlogDetailVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddDate { get; set; }

    }
}
