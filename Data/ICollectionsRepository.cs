using WriterApp.Models;

namespace WriterApp.Data
{
    public interface ICollectionsRepository
    {
        List<Collection> GetAll();
        //Book? TryGetById(Guid id);
    }
}