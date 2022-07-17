using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ICollection<MoviesInShoppingCart> MovieInShoppingCart { get; set; }

    }
}
