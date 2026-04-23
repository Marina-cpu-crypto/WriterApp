namespace WriterApp.Models
{
    public class Collection
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Book[] Books { get; set; }

        
    }
}
