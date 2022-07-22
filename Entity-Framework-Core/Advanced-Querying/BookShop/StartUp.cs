namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //  DbInitializer.ResetDatabase(db);

            // Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine())); 
            // Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            // Console.WriteLine(GetBooksNotReleasedIn(db,int.Parse(Console.ReadLine())));
            // Console.WriteLine(GetBooksByCategory(db,Console.ReadLine()));
            // Console.WriteLine(GetBooksReleasedBefore(db,Console.ReadLine()));
            // Console.WriteLine(GetAuthorNamesEndingIn(db,Console.ReadLine()));
            // Console.WriteLine(GetBookTitlesContaining(db,Console.ReadLine()));
            //Console.WriteLine(GetBooksByAuthor(db,Console.ReadLine()));
            // Console.WriteLine(CountBooks(db,int.Parse(Console.ReadLine())));
            //Console.WriteLine(CountCopiesByAuthor(db));
            // Console.WriteLine(GetTotalProfitByCategory(db));
            // Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            //RemoveBooks(db);

        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();
            context.Books.RemoveRange(books);
            return books.Count;
        }

        public static void IncreasePrices(BookShopContext context)
        {

            // Increase the prices of all books released before 2010 by 5.


            var allBooks = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            allBooks.ForEach(x => x.Price += 5);
            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            //Get the most recent books by categories. The categories should be ordered by name alphabetically. Only take the top 3 most recent books from each category - ordered by release date (descending). Select and print the category name, and for each book – its title and release year.


            StringBuilder sb = new StringBuilder();


            var recent = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks.Select(b => new
                    {
                        bookName = b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(d => d.ReleaseDate)
                    .Take(3)
                    .ToList()

                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in recent)
            {
                sb.AppendLine($"--{category.Name}");

                category.Books.ForEach(b => sb.AppendLine($"{b.bookName} ({b.ReleaseDate.Value.Year})"));
            }

            return String.Join(Environment.NewLine, sb.ToString().TrimEnd());
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            //Return the total profit of all books by category. Profit for a book can be calculated by multiplying its number of copies by the price per single book.
            ////Order the results by descending by total profit for category and ascending by category name.

            var profit = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)

                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            return String.Join(Environment.NewLine, profit.Select(p => $"{p.Name} ${p.Profit:f2}"));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //Return the total number of book copies for each author. Order the results descending by total book copies.
            //            Return all results in a single string, each on a new line.

            var result = context.Authors
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(a => a.Copies);

            return String.Join(Environment.NewLine, result.Select(x => $"{x.Name} - {x.Copies}"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {



            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //Return all titles of books and their authors’ names for books, which are written by authors whose last names start with the given string.
            // Return a single string with each title on a new row.Ignore casing.Order by book id ascending.

            var result = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return String.Join(Environment.NewLine, result);

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //Return the titles of book, which contain a given string. Ignore casing.
            //            Return all titles in a single string, each on a new row, ordered alphabetically.

            var result = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            //Return the full names of authors, whose first name ends with a given string.
            //           Return all names in a single string, each on a new row, ordered alphabetically.

            var result = context.Authors
                .Where(b => b.FirstName.EndsWith(input))
                .OrderBy(b => b.FirstName)
                .ThenBy(b => b.LastName)
                .Select(b => $"{b.FirstName} {b.LastName}")
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //Return the title, edition type and price of all books that are released before a given date. The date will be a string in format dd-MM-yyyy.
            // Return all of the rows in a single string, ordered by release date descending.

            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Date.CompareTo(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)) < 0)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();


            return String.Join(Environment.NewLine, result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            //Return in a single string the titles of books by a given list of categories. The list of categories will be given in a single line separated with one or more spaces. Ignore casing. Order by title alphabetically.
            var listOfCategories = input.ToLower().Split();

            var result = context.Books
                .Where(b => b.BookCategories.Any(c => listOfCategories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, result);

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            //Return in a single string all titles of books that are NOT released on a given year. Order them by book id ascending.
            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {

            /*Return in a single string all titles and prices of books with price higher than 40, each on a new row in the format given below. Order them by price descending.
*/
            var result = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            // Return in a single string titles of the golden edition books that have less than 5000 copies, each on a new line. Order them by book id ascending.
            var result = context.Books
                .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold") && b.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return String.Join(Environment.NewLine, result);

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)

        {
            //  TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            // var formattedString = ti.ToTitleCase(command);
            var result = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }
    }
}
