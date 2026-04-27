namespace WriterApp.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public string Author { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
        public string? PathImage { get; set; } = "";
        //public List<List<string>>? Matherials { get; set; }

        //public string bookText { get; set; } = "";

        public Book(string name, bool isdone, string description = ""/*string author, bool isdone, List<List<string>>? matherials*/)
        {
            Id = Guid.NewGuid();

            Name = name;
            IsDone = isdone;
            Description = description;

            //Author = author;
            //PathImage = pathImage;
            //Matherials = matherials;
        }
    }
}
