using Lab.Domain.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.DomainModels
{
    public class Reservation : BaseEntity
    {
        
        public string UserId { get; set; }

        public ShopApplicationUser ReservedBy { get; set; }
        public List<MovieInReservation> Movies { get; set; }
    }
}
