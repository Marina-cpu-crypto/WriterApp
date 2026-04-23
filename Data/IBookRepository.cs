using WriterApp.Models;

namespace WriterApp.Data
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? TryGetById(Guid id);
    }
}