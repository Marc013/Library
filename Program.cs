using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = ProcessBooks("books.csv");

            int action;
            do
            {
                action = DisplayMenu();
            } while (action !>= 7);

            switch (action)
            {
                case 0: // DEZE WERKT NIET, MISSCHIEN MOET HET EEN 7 ZIJN.
                    Console.WriteLine("Please provide a number [1 - 6]");
                    break;
                case 1:
                    QueryData.Author(books);
                    break;
                case 2:
                    QueryData.Year(books);
                    break;
                case 3:
                    QueryData.Rating(books);
                    break;
                case 4:
                    Action(action);
                    break;
                case 5:
                    Action(action);
                    break;
                case 6:
                    Console.WriteLine("Exiting the program");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Unexpected option");
                    break;
            }
        }

        private static void Action(int action)
        {
            Console.WriteLine($"You have chosen action '{action}'");
        }

        private static List<Book> ProcessBooks(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToBook();

            return query.ToList();
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("What action do you want to perform: ");
            Console.WriteLine();
            Console.WriteLine("1. Get all books by author");
            Console.WriteLine("2. Get all books by year");
            Console.WriteLine("3. Get all books by rating");
            Console.WriteLine("4. Add book");
            Console.WriteLine("5. Remove book");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter the number: ");
            var result = Console.ReadLine();
            char firstCharacter = result[0];
            bool isNumber = Char.IsDigit(firstCharacter);
            if (!isNumber)
            {
                var wrongEntry = 7;
                return wrongEntry;
            }
            else
            {
                return int.Parse(result); //What if a string is provided?
            }
        }
    }
}
