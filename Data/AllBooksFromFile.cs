using System.Text.Json;
using WriterApp.Data;
using WriterApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WriterApp.Data
{
    public class AllBooksFromFile : IBookRepository
    {
        private static List<Book> books = new List<Book>();

        public AllBooksFromFile()
        {
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

        public void Change(Book book)
        {
            var collections = new List<Collection>()
            {
                new Collection(0,"В процессе"),
                new Collection(1,"Завершено")
            };
            //bool flag = true;

            for (int i=0;i<books.Count;i++)
            {
                if (books[i].Id == book.Id)
                {
                    books[i] = book;
                    //flag = false;
                    //break;
                }
            }

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].IsDone)
                {
                    if (!collections[1].Books.ContainsKey(books[i].Id))
                    {
                        collections[1].Books.Add(books[i].Id, books[i].Name);
                        collections[1].Amount++;
                        collections[0].Amount--;
                    }
                }
                else
                {
                    if (!collections[0].Books.ContainsKey(books[i].Id))
                    {
                        collections[0].Books.Add(books[i].Id, books[i].Name);
                        collections[0].Amount++;
                        collections[1].Amount--;
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true  }; // добавляет отступы и переносы строк

            string newbooks = JsonSerializer.Serialize(books, options);
            File.WriteAllText("Data/books.json", newbooks);

            string newcol = JsonSerializer.Serialize(collections, options);
            File.WriteAllText("Data/collections.json", newcol);

        }
    }
}
