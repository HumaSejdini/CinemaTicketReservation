using Lab.Domain.DomainModels;
using System.Collections.Generic;

namespace Lab.Domain.DTO
{
    public class AddShoppingCartDto
    {
        public List<MoviesInShoppingCart> MovieInShoppingCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
