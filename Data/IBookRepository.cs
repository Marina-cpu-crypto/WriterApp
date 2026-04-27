using WriterApp.Models;

namespace WriterApp.Data
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? TryGetById(Guid id);
        void Change(Book book);
        void ChangeStatus(Book book, bool status);
        void Delete(Guid id);
        void Resave();
    }
}