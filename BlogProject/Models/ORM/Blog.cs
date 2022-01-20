
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models.ORM
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string MainImg { get; set; }
        public int BlogCategoryId { get; set; }
        [ForeignKey("BlogCategoryId")]
        public BlogCategory BlogCategory { get; set; }

        public List<BlogImage> Blogs { get; set; }
    }
}
