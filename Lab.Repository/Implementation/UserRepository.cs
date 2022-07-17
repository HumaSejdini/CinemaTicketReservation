using Lab.Domain.Identity;
using Lab.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopApplicationUser>();
        }
        public void Delete(ShopApplicationUser entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public ShopApplicationUser Get(string id)
        {
            return entities.Include(z => z.UserShoppingCart).
                Include("UserShoppingCart.MovieInShoppingCart").
                Include("UserShoppingCart.MovieInShoppingCart.Movie").
                SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<ShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
