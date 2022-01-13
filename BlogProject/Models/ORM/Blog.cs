
namespace BlogProject.Models.ORM
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int AuthorID { get; set; }
    }
}
