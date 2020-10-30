using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Library
{
    class BookAction
    {
        public static void Add(List<Book> books)
        {
            var newBook = NewBook(books);

            var newEntry = string.Join(",",
                            newBook.BookId,
                            newBook.Title,
                            newBook.Author,
                            newBook.AvarageRating,
                            newBook.Isbn,
                            newBook.Isbn13,
                            newBook.Language,
                            newBook.NumberOfPages,
                            newBook.RatingsCount,
                            newBook.TextReviewsCount,
                            newBook.PublicationDate.ToShortDateString(),
                            newBook.Publisher);

            Console.WriteLine(newEntry);

            File.AppendAllText("books.csv", newEntry + Environment.NewLine);
        }

        private static Book NewBook(List<Book> books)
        {
            var id = NewId(books);
            var title = NewText("Enter the book title");
            var author = NewText("Enter the author name");
            var avarageRating = NewRating();
            var isbn = NewText("Enter the ISBN");
            var isbn13 = NewIsbn13();
            var language = NewText("Enter the book language");
            var numberOfPages = NewNumber("Enter the number of pages");
            var ratingsCount = NewNumber("Enter the ratings count");
            var textReviewsCount = NewNumber("Enter the text review count");
            var publicationDate = NewDate();
            var publisher = NewText("Enter the publisher name");

            var book = new Book
            {
                BookId = id,
                Title = title,
                Author = author,
                AvarageRating = avarageRating,
                Isbn = isbn,
                Isbn13 = isbn13,
                Language = language,
                NumberOfPages = numberOfPages,
                RatingsCount = ratingsCount,
                TextReviewsCount = textReviewsCount,
                PublicationDate = publicationDate,
                Publisher = publisher
            };

            return book;
        }

        private static int NewId(List<Book> books)
        {
            var lastId = BookQuery.GetLastBookId(books);
            return ++lastId;
        }

        private static int NewNumber(string message)
        {
            int validNumber;
            var valid = false;

            do
            {
                Console.WriteLine($"\n\t{message}");
                var number = Console.ReadLine();

                if (int.TryParse(number, out validNumber))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"\n\tInvalide entry: {number}");
                }

            } while (!valid);

            return validNumber;
        }

        private static long NewIsbn13()
        {
            long validIsbn13;
            var valid = false;

            do
            {
                Console.WriteLine("\n\tEnter the ISBN13");
                var isbn13 = Console.ReadLine();

                if (long.TryParse(isbn13, out validIsbn13))
                {
                    if (isbn13.Length == 13)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("The ISBN13 must be 13 characters long");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalide entry: {isbn13}");
                }

            } while (!valid);

            return validIsbn13;
        }

        private static decimal NewRating()
        {
            decimal validRating;
            var valid = false;

            do
            {
                Console.WriteLine("\n\tEnter the avarage rating of the book (1.00 - 5.00)");
                var rating = Console.ReadLine();

                if (decimal.TryParse(rating, out validRating))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry: {rating}");
                }

            } while (!valid);

            return validRating;
        }

        private static DateTime NewDate()
        {
            DateTime validDate;
            var valid = false;

            do
            {
                Console.WriteLine("\n\tEnter the publication date (mm/dd/yyyy)");
                var date = Console.ReadLine();

                if (DateTime.TryParse(date, out validDate))
                {
                    valid = true;
                }
            } while (!valid);

            return validDate;
        }

        private static string NewText(string message)
        {
            Console.WriteLine($"\n\t{message}");
            return Console.ReadLine();
        }

        public static void Upload()
        {
            Console.WriteLine("Upload file");
            // validate if file is csv
            // validate if csv schema is correct (correct # of tables)
            // validate if each table contains the expected data type
        }

        public static void Remove()
        {
            Console.WriteLine("Remove a single book");
        }

        public static void RemoveMenu()
        {
            Console.WriteLine("Remove book by specifying the index number after a query");
        }
    }
}
