using Lab.Domain.DomainModels;
using Lab.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Repository.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Reservation> entities;
        string errorMessage = string.Empty;

        public ReservationRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Reservation>();
        }
        public List<Reservation> getAllReservations()
        {
            return entities.Include(z => z.ReservedBy).Include(z => z.Movies)
                 .Include("Movies.Movie").ToList();
        }

        public Reservation getReservationDetails(BaseEntity model)
        {
            return entities.Include(z => z.ReservedBy).Include(z => z.Movies)
                 .Include("Movies.Movie").SingleOrDefault(z=>z.Id==model.Id);
        }
    }
}
