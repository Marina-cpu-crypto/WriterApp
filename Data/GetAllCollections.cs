using Microsoft.Extensions.Options;
using System.Text.Json;
using WriterApp.Data;
using WriterApp.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WriterApp.Data
{
    public class GetAllCollections : ICollectionsRepository
    {
        private static List<Collection> collections = new List<Collection>();

        public GetAllCollections()
        {
            string jsonString = File.ReadAllText("Data/collections.json");
            collections = JsonSerializer.Deserialize<List<Collection>>(jsonString);
        }

        public List<Collection> GetAll()
        {
            string jsonString = File.ReadAllText("Data/collections.json");
            collections = JsonSerializer.Deserialize<List<Collection>>(jsonString);

            
            return collections;
        }

        public void ResetCollection()
        {
            string jsonString = File.ReadAllText("Data/books.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);

            foreach(var book in books)
            {
                int ind = 0;
                bool flag = false;
                if (book.IsDone) ind = 1;

                foreach (var b in collections[ind].Books) if (b.Id == book.Id) flag = true;

                if (!flag) collections[ind].Books.Add(book);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string newcol = JsonSerializer.Serialize(collections, options);
            File.WriteAllText("Data/collections.json", newcol);
        }
    }
}
