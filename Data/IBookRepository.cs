using WriterApp.Models;

namespace OnLineShop2026.Data
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? TryGetById(Guid id);
    }
}