using OnLineShop2026.Data;
using System.Text.Json;
using WriterApp.Models;

namespace WriterApp.Data
{
    public class AllBooksFromFile : IBookRepository
    {
        private static List<Book> products = new List<Book>();

        public AllBooksFromFile()
        {
            string jsonString = File.ReadAllText("Data/books.json");
            products = JsonSerializer.Deserialize<List<Book>>(jsonString);
        }

        public List<Book> GetAll()
        {
            return products;
        }

        public Book? TryGetById(Guid id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
