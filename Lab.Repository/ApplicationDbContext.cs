using Lab.Domain.DomainModels;
using Lab.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ShopApplicationUser>
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<MoviesInShoppingCart> MoviesInShoppingCarts { get; set; }
        public virtual DbSet<ShopApplicationUser> ShopApplicationUsers { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<MovieInReservation> MovieInReservations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MoviesInShoppingCart>().HasKey(c => new { c.CartId, c.MovieId });
            builder.Entity<MovieInReservation>().HasKey(c => new { c.ReservationId, c.MovieId });

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
