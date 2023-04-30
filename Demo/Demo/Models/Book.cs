using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public  List<Image> Images { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }


        [NotMapped]
        public List<int> Authorİds { get; set; }
        [NotMapped]
        public List<int> GenresIds { get; set; }




        public Book()
        {
            BookAuthors=new List<BookAuthor>();
            BookGenres=new List<BookGenre>();  
            Images=new List<Image>(); 
        }

    }
}
