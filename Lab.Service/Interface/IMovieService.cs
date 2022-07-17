using Lab.Domain.DomainModels;
using Lab.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Service.Interface
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetDetailsForMovie(int id);
        void CreateNewMovie(Movie m);
        void UpdateExistingMovie(Movie m);
        AddToShoppingCartDto GetShoppingCartInfo(int id);
        void DeleteMovie(int id);
        bool AddToShoppingCart(AddToShoppingCartDto item,string userID);
    }
}
