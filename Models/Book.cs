namespace WriterApp.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PathImage { get; set; }

        public Book(string name, string description, string author, string pathImage="")
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Author = author;
            PathImage = pathImage;
        }
    }
}
