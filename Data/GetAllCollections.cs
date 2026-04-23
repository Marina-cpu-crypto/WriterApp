using OnLineShop2026.Data;
using System.Text.Json;
using WriterApp.Models;

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
            return collections;
        }

        //public string? TryGetById(Guid id)
        //{
        //    return collections.FirstOrDefault(product => product.Id == id);
        //}
    }
}
