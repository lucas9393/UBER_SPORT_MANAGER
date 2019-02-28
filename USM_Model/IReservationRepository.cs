using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace USM_Model
{
    public interface IReservationRepository
    {
        Task<Reservation[]> AllReservations();

        bool AddReservation(Reservation reservation);
        bool RemoveReservation(int reservationId);
        Reservation EditReservation(int reservationId);
        IEnumerable<Reservation> SortedReservations(ReservationSortingType sortingType);
        Task<Reservation[]> SearchReservationsByDate(DateTime startDate, DateTime endDate);
        Task<Reservation[]> SearchReservationsByField(string queryStringField);
        Task<Reservation[]> SearchReservationsByMember(string queryStringMember);
    }
}
