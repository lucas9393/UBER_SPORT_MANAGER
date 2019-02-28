using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USM_Model;
using Microsoft.EntityFrameworkCore;

namespace USM_EF_Helper
{
    public class EFReservationRepository : IReservationRepository
    {
        public IQueryable<Reservation> Reservations => Context.Reservations;
        public EFDBContext Context { get; set; }

        public EFReservationRepository(EFDBContext context)
        {
            Context = context;
        }

        public bool AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReservation(int reservationId)
        {
            throw new NotImplementedException();
        }


        public Reservation EditReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> SortedReservations(ReservationSortingType sortingType)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation[]> AllReservations()
        {
            return await Reservations.ToArrayAsync();
        }

        public async Task<Reservation[]> SearchReservationsByDate(DateTime startDate, DateTime endDate)
        {
            return await Reservations.Where(r => r.Date >= startDate && r.Date <= endDate).ToArrayAsync();
        }

        public async Task<Reservation[]> SearchReservationsByField(string queryStringField)
        {
            return await Reservations.Where(r => r.Field.Name.Contains(queryStringField)).ToArrayAsync();
        }

        public async Task<Reservation[]> SearchReservationsByMemberName(string memberName)
        {
            return await Reservations.Where(r => r.Member.Surname.Contains(memberName) || r.Member.Name.Contains(memberName)).ToArrayAsync();
        }
     
    }
}
