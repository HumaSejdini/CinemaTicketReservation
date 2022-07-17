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
    public class MovieService : IMovieService
    {
        public readonly IRepository<Movie> _movieRepository;
        public readonly IUserRepository _userRepository;
        public readonly IRepository<MoviesInShoppingCart> _movieInShoppingCartRepository;
        public MovieService(IRepository<Movie> movieRepository, IUserRepository userRepository, IRepository<MoviesInShoppingCart> movieInShoppingCartRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _movieInShoppingCartRepository = movieInShoppingCartRepository;
        }
        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserShoppingCart;

            if (userShoppingCard != null)
            {
                var movie = this.GetDetailsForMovie(item.MovieId);

                if (movie != null)
                {
                    MoviesInShoppingCart itemToAdd = new MoviesInShoppingCart
                    {
                        
                        Movie = movie,
                        MovieId = movie.Id,
                        ShoppingCart = userShoppingCard,
                        CartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._movieInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewMovie(Movie m)
        {
            this._movieRepository.Insert(m);
        }

        public void DeleteMovie(int id)
        {
            var movie=_movieRepository.Get(id);
            this._movieRepository.Delete(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(int id)
        {
            return _movieRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingMovie(Movie m)
        {
           _movieRepository.Update(m);
        }
    }
}
