using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WriterApp.Data;
using WriterApp.Models;

namespace WriterApp.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        public Guid MainId = Guid.Parse(System.IO.File.ReadAllText("Data/MainId.txt"));
        public IActionResult Index(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            return View(book);
        }

        public BookController(IBookRepository bookRep)
        {
            this.bookRepository = bookRep;
        }
        public IActionResult Redact(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            return View(book);
        }

        public IActionResult ChangeStatus(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            book.IsDone = !book.IsDone;

            bookRepository.ChangeStatus(book,book.IsDone);
            
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult SetRating(Guid id, int rating)
        {
            var book = bookRepository.TryGetById(id);
            book.Rating = rating;

            bookRepository.Change(book);
            bookRepository.Resave();

            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult ChangeImage(Guid id, string PathImage)
        {
            var book = bookRepository.TryGetById(id);
            book.PathImage = PathImage;
            bookRepository.Change(book);

            return RedirectToAction("Index","Book" ,new { id = id });
        }

        public IActionResult Save(Guid Id, string Name, string Author, string Genre, string bookText, string Description)
        {
            Book book = bookRepository.TryGetById(Id);

            if(book.Name != Name)
            {
                System.IO.File.Delete("Data/"+MainId+"/Texts/"+book.Name+".txt");
                book.Name = Name;
            }
            book.Author = Author;
            book.Genre = Genre;
            book.Description = Description;

            string file = "Data/" + MainId + "/Texts/" + Name + ".txt";
            System.IO.File.WriteAllText(file, bookText);

            bookRepository.Change(book);

            return RedirectToAction("Index", new { id = Id });
        }

        public IActionResult Delete(Guid Id)
        {
            var book = bookRepository.TryGetById(Id);
            bookRepository.Delete(book);

            return RedirectToAction("Index", "Home");
        }
    }
}
