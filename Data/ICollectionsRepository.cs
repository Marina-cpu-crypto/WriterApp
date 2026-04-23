using WriterApp.Models;

namespace OnLineShop2026.Data
{
    public interface ICollectionsRepository
    {
        List<Collection> GetAll();
        //Book? TryGetById(Guid id);
    }
}