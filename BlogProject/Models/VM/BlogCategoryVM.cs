using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models.VM
{
    public class BlogCategoryVM
    {
        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
