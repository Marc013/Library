using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class QueryData
    {

        public static void Author(List<Book> books)
        {

            Console.WriteLine("Enter author name: ");
            var authorName = Console.ReadLine();

            var filter = books.Where(b => b.Author.ToLower().Contains(authorName.ToLower()))
                               .GroupBy(b => b.Author)
                               .Take(5);

            if (filter.Count() >= 1)
            {
                foreach (var book in filter)
                {
                    Console.WriteLine(book.Key);

                    foreach (var item in book)
                    {
                        Console.WriteLine($"\t {item.Title} : {item.PublicationDate.ToShortDateString()}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Author '{authorName}' not found.");
            }
        }

        public static void Year(List<Book> books)
        {
            Console.WriteLine("Enter publication year: ");
            var year = int.Parse(Console.ReadLine());

            var filter = books.Where(b => b.PublicationDate.Year == year)
                               .GroupBy(b => b.Author)
                               .Take(5);

            if (filter.Count() >= 1)
            {
                foreach (var book in filter)
                {
                    Console.WriteLine(book.Key);

                    foreach (var item in book)
                    {
                        Console.WriteLine($"\t {item.Title} : {item.PublicationDate.ToShortDateString()}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Year '{year}' not found.");
            }
        }

        public static void Rating(List<Book> books)
        {
            Console.WriteLine("Enter mininum rating: ");
            var rating = decimal.Parse(Console.ReadLine());

            var filter = books.Where(b => b.AvarageRating >= rating)
                               .OrderByDescending(b => b.AvarageRating)
                               .GroupBy(b => b.Author)
                               .Take(100);

            if (filter.Count() >= 1)
            {
                foreach (var book in filter)
                {
                    Console.WriteLine(book.Key);

                    foreach (var item in book)
                    {
                        Console.WriteLine($"\t {item.Title} : {item.AvarageRating}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Rating '{rating}' not found.");
            }
        }
    }
}
