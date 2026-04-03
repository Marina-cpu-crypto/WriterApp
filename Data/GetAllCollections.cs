using System.Text.Json;
using WriterApp.Models;

namespace WriterApp.Data
{
    public class GetAllCollections
    {
        private static List<string> collections = new List<string>();

        public GetAllCollections()
        {
            string jsonString = File.ReadAllText("Data/collections.json");
            collections = JsonSerializer.Deserialize<List<string>>(jsonString);
        }

        public List<string> GetAll()
        {
            return collections;
        }

        //public string? TryGetById(Guid id)
        //{
        //    return collections.FirstOrDefault(product => product.Id == id);
        //}
    }
}
