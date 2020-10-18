using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal AvarageRating { get; set; }
        public string Isbn { get; set; }
        public long Isbn13 { get; set; }
        public string Language { get; set; }
        public int NumberOfPages { get; set; }
        public int RatingsCount { get; set; }
        public int TextReviewsCount { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; }
    }
}
