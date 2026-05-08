using Microsoft.Extensions.Options;
using System.Text.Json;
using WriterApp.Data;
using WriterApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WriterApp.Data
{
    public class AllBooksFromFile : IBookRepository
    {
        private static List<Book> books = new List<Book>();
        private static List<Collection> collections;

        public AllBooksFromFile(ICollectionsRepository collectRep)
        {
            collections = collectRep.GetAll();
            string jsonString = File.ReadAllText("Data/books.json");
            books = JsonSerializer.Deserialize<List<Book>>(jsonString);
        }

        public List<Book> GetAll()
        {
            return books;
        }

        public Book? TryGetById(Guid id)
        {
            return books.FirstOrDefault(book => book.Id == id);
        }
        public void ChangeStatus(Book book, bool status)
        {
            if(status)
            {
                collections[1].Books.Add(book.Id, book.Name);
                collections[0].Books.Remove(book.Id);

                collections[1].Amount++;
                collections[0].Amount--;
            }
            else
            {
                collections[0].Books.Add(book.Id, book.Name);
                collections[1].Books.Remove(book.Id);

                collections[0].Amount++;
                collections[1].Amount--;
            }
            this.Resave();
        }

        public void Change(Book book)
        {
            if(book.IsDone)
            {
                collections[1].Books[book.Id] = book.Name;
            }
            else
            {
                collections[0].Books[book.Id] = book.Name;
            }

            this.Resave();
        }

        public void Delete(Guid id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    System.IO.File.Delete("Data/Texts/" + books[i].Name + ".txt");

                    if (books[i].IsDone) collections[1].Books.Remove(id);
                    else collections[0].Books.Remove(id);

                    books.RemoveAt(i);
                    break;
                }
            }

            this.Resave();

        }

        public void Resave()
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // добавляет отступы и переносы строк

            string newbooks = JsonSerializer.Serialize(books, options);
            File.WriteAllText("Data/books.json", newbooks);

            string newcol = JsonSerializer.Serialize(collections, options);
            File.WriteAllText("Data/collections.json", newcol);
        }
    }
}
