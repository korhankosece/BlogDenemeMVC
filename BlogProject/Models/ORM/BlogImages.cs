using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.ORM
{
    public class BlogImages : BaseEntity
    {
        public string Path { get; set; }
        public int BlogId { get; set; }
    }
}
