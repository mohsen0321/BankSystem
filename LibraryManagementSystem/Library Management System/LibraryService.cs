using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class LibraryService
    {
        public static List<Book> books = new List<Book>();

        public  void AddBook()
        {
            Console.WriteLine("Enter Book Id:");
            int id = int.Parse(Console.ReadLine());
            var existingid = books.FirstOrDefault(b => b.Id == id);

            if (existingid != null)
            {
                Console.WriteLine("Book with this Id already exists.");
                return;
            }
            Console.WriteLine("Enter Book Title:");


            string title = Console.ReadLine();
            Console.WriteLine("Enter Author Name:");
            string authorname = Console.ReadLine();
            Console.WriteLine("Enter Publication Year:");
            int year = int.Parse(Console.ReadLine());

            Book book = new Book(id, title, authorname, year);
            books.Add(book);
            Console.WriteLine("Book added Successfully");


        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter Book Id to delete:");
            int id = int.Parse(Console.ReadLine());
            var result = books.FirstOrDefault(b => b.Id == id);
            if (result == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            books.Remove(result);
            Console.WriteLine("Book deleted successfully.");

        }

        public void ViewAvailableBooks()
        {
            var available = books.Where(b => !b.IsBorrowed);
            if (!available.Any())
            {
                Console.WriteLine("No available books.");
                return;
            }

            foreach (var b in available)
            {
                Console.WriteLine($"{b.Id} - {b.Title} - {b.Author}");
            }

        }

        public  void viewBook()
        {
            if (!books.Any())
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (Book b in books)
            {
                Console.WriteLine($"ID: {b.Id}");
                Console.WriteLine($"Title: {b.Title}");
                Console.WriteLine($"Author: {b.Author}");
                Console.WriteLine($"Year: {b.Year}");
                Console.WriteLine($"Borrowed: {b.IsBorrowed}");
                Console.WriteLine("---------------------");
            }
        }


        public void ViewBorrowedBooks()
        {
            var borrowed = books.Where(b => b.IsBorrowed);

            if (!borrowed.Any())
            {
                Console.WriteLine("No borrowed books.");
                return;
            }

            foreach (var b in borrowed)
            {
                Console.WriteLine($"{b.Id} - {b.Title} - {b.Author}");
            }
        }


        public void SearchBookByTitle()
        {
            Console.WriteLine("Enter title keyword:");
            string title = Console.ReadLine();

            var result = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            if (result.Any())
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"ID: {res.Id}, Title: {res.Title}, Author: {res.Author}, Year: {res.Year}, Borrowed: {res.IsBorrowed}");

                }
            }
            else
            {
                Console.WriteLine("No books found with this title.");

            }
        }


        public void SearchBookByAuthor()
        {
            Console.WriteLine("Enter author keyword:");
            string title = Console.ReadLine();

            var result = books.Where(b => b.Author.Contains(title, StringComparison.OrdinalIgnoreCase));
            if (result.Any())
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"ID: {res.Id}, Title: {res.Title}, Author: {res.Author}, Year: {res.Year}, Borrowed: {res.IsBorrowed}");

                }
            }
            else
            {
                Console.WriteLine("No books found for this author.");

            }
        }

        public void BorrowBook()
        {

            Console.WriteLine("Enter Book Id to borrow:");
            int id = int.Parse(Console.ReadLine());
            var book = books.FirstOrDefault(f => f.Id == id);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            if (book.IsBorrowed)
            {
                Console.WriteLine("Book is already borrowed.");

            }
            else
            {
                book.IsBorrowed = true;
                Console.WriteLine("Book borrowed successfully.");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Enter Book Id to return:");
            int id = int.Parse(Console.ReadLine());
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            if (!book.IsBorrowed)
            {
                Console.WriteLine("Book was not borrowed.");

            }
            else
            {
                book.IsBorrowed = false;
                Console.WriteLine("Book returned successfully.");
            }
        }



    }
}
