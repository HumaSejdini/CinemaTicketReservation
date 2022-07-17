using Lab.Domain.DomainModels;

namespace Lab.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Movie SelectedMovie { get; set; }
        public int MovieId { get; set; }

        public int Quantity { get; set; }
    }
}
