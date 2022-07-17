using Lab.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Lab.Domain.Identity
{
    public class ShopApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}
