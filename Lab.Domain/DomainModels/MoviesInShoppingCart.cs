using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Domain.DomainModels
{
    public class MoviesInShoppingCart : BaseEntity
    {
        public int MovieId { get; set; }
        public int CartId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
