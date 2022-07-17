using Lab.Domain.DomainModels;
using Lab.Domain.DTO;
using Lab.Repository.Interface;
using Lab.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IUserRepository _userRepository;
        public readonly IRepository<MovieInReservation> _movieInReservationRepository;
        public readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public readonly IRepository<Reservation> _reservationRepository;
        public readonly IRepository<EmailMessage> _mailRepository;

        public ShoppingCartService(IUserRepository userRepository,
          IRepository<MovieInReservation> movieInReservationRepository,
          IRepository<ShoppingCart> shoppingCartRepository,
          IRepository<Reservation> reservationRepository,
          IRepository<EmailMessage> mailRepository)
        {
              _userRepository = userRepository;
              _movieInReservationRepository = movieInReservationRepository;
              _shoppingCartRepository = shoppingCartRepository;
              _reservationRepository=reservationRepository;
              _mailRepository=mailRepository;
        }
        public bool deleteMovieFromShoppingCart(string userId, int movieId)
        {
            if(!string.IsNullOrEmpty(userId) && movieId != null)
            {
                var loggInUser = _userRepository.Get(userId);
                var userShoppingCart = loggInUser.UserShoppingCart;
                var itemToDelete = userShoppingCart.MovieInShoppingCart.Where(z => z.MovieId == movieId).FirstOrDefault();
                userShoppingCart.MovieInShoppingCart.Remove(itemToDelete);
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public AddShoppingCartDto getShoppingCartInfo(string userId)
        {
            var user = _userRepository.Get(userId);

            var userShoppingCart = user.UserShoppingCart;
            var movieList = userShoppingCart.MovieInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                MoviePrice = z.Movie.MoviePrice
            });
            double totalPrice = 0;
            foreach (var movie in movieList)
            {
                totalPrice += movie.MoviePrice * movie.Quantity;
            }
            AddShoppingCartDto model = new AddShoppingCartDto
            {
                TotalPrice = totalPrice,
                MovieInShoppingCart = userShoppingCart.MovieInShoppingCart.ToList()
            };
            return model;
        }

        public bool reserveNow(string userId)
        {
            var user = _userRepository.Get(userId);
            var userShoppingCart = user.UserShoppingCart;

            EmailMessage message = new EmailMessage();
            message.MailTo = user.Email;
            message.Subject = "Successfully created reservation";
            message.Status = false;


            Reservation newReservation = new Reservation
            {
                UserId = user.Id,
                ReservedBy = user
            };
            _reservationRepository.Insert(newReservation);

            List<MovieInReservation> movieInReservation = userShoppingCart.MovieInShoppingCart.Select(z => new MovieInReservation
            {
                Movie = z.Movie,
                MovieId = z.MovieId,
                Reservation = newReservation,
                ReservationId = newReservation.Id,
                Quantity = z.Quantity
            }).ToList();

            StringBuilder sb = new StringBuilder();

            var totalPrice = 0.0;

            sb.AppendLine("Your reservation is completed. The reservation conatins: ");

            for (int i = 1; i <= movieInReservation.Count(); i++)
            {
                var currentItem = movieInReservation[i - 1];
                totalPrice += currentItem.Quantity * currentItem.Movie.MoviePrice;
                sb.AppendLine(i.ToString() + ". " + currentItem.Movie.MovieTitle + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Movie.MoviePrice);
            }
            sb.AppendLine("Total price for your reservation: " + totalPrice.ToString());

            message.Content = sb.ToString();

           // movieInReservation.AddRange(movieInReservation);

            foreach (var movie in movieInReservation)
            {
                _movieInReservationRepository.Insert(movie);
            }
            user.UserShoppingCart.MovieInShoppingCart.Clear();
            this._mailRepository.Insert(message);
            _userRepository.Update(user);
            return true;
        }
    }
}
