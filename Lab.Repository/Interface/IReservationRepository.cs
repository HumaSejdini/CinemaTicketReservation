using Lab.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Repository.Interface
{
    public interface IReservationRepository
    {
        List<Reservation> getAllReservations();
        Reservation getReservationDetails(BaseEntity model);
    }
}
