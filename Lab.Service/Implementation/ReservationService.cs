using Lab.Domain.DomainModels;
using Lab.Repository.Interface;
using Lab.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Service.Implementation
{
    public class ReservationService : IReservationService
    {
        public readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<Reservation> getAllReservations()
        {
           return _reservationRepository.getAllReservations();
        }

        public Reservation getReservationDetails(BaseEntity model)
        {
            return _reservationRepository.getReservationDetails(model);
        }
    }
}
