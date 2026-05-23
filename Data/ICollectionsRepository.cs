using WriterApp.Models;

namespace WriterApp.Data
{
    public interface ICollectionsRepository
    {
        List<Collection> GetAll();
        //void Remove(Book book, int ind);
    }
}