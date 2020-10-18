using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public static class BookExtensions
    {
        public static IEnumerable<Book> ToBook(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Book
                {
                    BookId = int.Parse(columns[0]),
                    Title = columns[1],
                    Author = columns[2],
                    AvarageRating = decimal.Parse(columns[3]),
                    Isbn = columns[4],
                    Isbn13 = long.Parse(columns[5]),
                    Language = columns[6],
                    NumberOfPages = int.Parse(columns[7]),
                    RatingsCount = int.Parse(columns[8]),
                    TextReviewsCount = int.Parse(columns[9]),
                    PublicationDate = DateTime.Parse(columns[10]),
                    Publisher = columns[11]
                };
            }
        }
    }
}
