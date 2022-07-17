using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DomainModels
{
    public class Movie : BaseEntity
    {
       
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public double MoviePrice { get; set; }
        [Required]
        public int MovieRating { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
        public ICollection<MoviesInShoppingCart> MovieInShoppingCart { get; set; }

    }
}
