using Lab.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Service.Interface
{
    public interface IReservationService
    {
        List<Reservation> getAllReservations();
        Reservation getReservationDetails(BaseEntity model);
    }
}
