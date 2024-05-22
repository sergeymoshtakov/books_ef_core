using myproj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace myproj
{
    public class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-UQI130RV;Database=Library;Trusted_Connection=True;MultipleActiveResultSets=true");

            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                var booksWithAuthors = context.Books
                    .Include(b => b.IdAuthorNavigation)
                    .ToList();

                Console.WriteLine("Books and Authors:");
                foreach (var book in booksWithAuthors)
                {
                    Console.WriteLine($"Book Id: {book.Id}");
                    Console.WriteLine($"Book Name: {book.Name}");
                    Console.WriteLine($"Book Pages: {book.Pages}");
                    Console.WriteLine($"Book Year of Press: {book.YearPress}");
                    Console.WriteLine($"Book Theme Id: {book.IdTheme}");
                    Console.WriteLine($"Book Category Id: {book.IdCategory}");
                    Console.WriteLine($"Book Author Id: {book.IdAuthor}");
                    Console.WriteLine($"Book Publishment Id: {book.IdPublishment}");
                    Console.WriteLine($"Book Comment: {book.Comment}");
                    Console.WriteLine($"Book Quantity: {book.Quantity}");

                    if (book.IdAuthorNavigation != null)
                    {
                        Console.WriteLine($"Author Id: {book.IdAuthorNavigation.Id}");
                        Console.WriteLine($"Author First Name: {book.IdAuthorNavigation.FirstName}");
                        Console.WriteLine($"Author Last Name: {book.IdAuthorNavigation.LastName}");
                    }

                    Console.WriteLine();
                }

                var newBook = new Book
                {
                    Name = "New Book",
                    Pages = 200,
                    YearPress = 2024,
                    IdTheme = 1, 
                    IdCategory = 1,
                    IdPublishment = 1, 
                    Comment = "New Comment",
                    Quantity = 10 
                };

                var newAuthor = new Author
                {
                    FirstName = "John",
                    LastName = "Doe"
                };

                context.Books.Add(newBook);
                context.Authors.Add(newAuthor);

                newBook.IdAuthor = newAuthor.Id;

                context.SaveChanges();
                Console.WriteLine("New book and author added successfully!");

                var booksAuthorsViewData = context.Books
                    .Include(b => b.IdAuthorNavigation)
                    .ToList();

                Console.WriteLine("Books and Authors from View:");
                foreach (var book in booksWithAuthors)
                {
                    Console.WriteLine($"Book Id: {book.Id}");
                    Console.WriteLine($"Book Name: {book.Name}");
                    Console.WriteLine($"Book Pages: {book.Pages}");
                    Console.WriteLine($"Book Year of Press: {book.YearPress}");
                    Console.WriteLine($"Book Theme Id: {book.IdTheme}");
                    Console.WriteLine($"Book Category Id: {book.IdCategory}");
                    Console.WriteLine($"Book Author Id: {book.IdAuthor}");
                    Console.WriteLine($"Book Publishment Id: {book.IdPublishment}");
                    Console.WriteLine($"Book Comment: {book.Comment}");
                    Console.WriteLine($"Book Quantity: {book.Quantity}");

                    if (book.IdAuthorNavigation != null)
                    {
                        Console.WriteLine($"Author Id: {book.IdAuthorNavigation.Id}");
                        Console.WriteLine($"Author First Name: {book.IdAuthorNavigation.FirstName}");
                        Console.WriteLine($"Author Last Name: {book.IdAuthorNavigation.LastName}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
