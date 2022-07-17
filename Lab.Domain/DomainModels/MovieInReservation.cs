using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Domain.DomainModels
{
    public class MovieInReservation : BaseEntity
    {   
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("ReservationId")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int Quantity { get; set; }
    }
}
