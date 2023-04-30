namespace Demo.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public SocialPage SocialPage { get; set; }
        public int SocialPageId { get; set; }



    }
}
