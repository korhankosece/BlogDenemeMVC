using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.ORM
{
    public class BlogImage : BaseEntity
    {
        public string Path { get; set; }

        public int BlogId { get; set; }
        [ForeignKey("BlogId")] 
        public Blog Blog { get; set; }
    }
}