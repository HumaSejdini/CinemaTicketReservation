using Lab.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Service.Interface
{
    public interface IShoppingCartService
    {
        AddShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteMovieFromShoppingCart(string userId,int movieId);
        bool reserveNow(string userId);
    }
}
