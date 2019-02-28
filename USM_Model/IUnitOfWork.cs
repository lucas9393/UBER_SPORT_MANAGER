using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace USM_Model
{
    public interface IUnitOfWork
    {
        //Members
        Task<Member[]> AllMembers();

        bool AddMember(Member member);
        bool RemoveMember(int memberId);
        Member EditMember(int memberId);
        IEnumerable<Member> SortedMembers(MemberSortingType sortingType);
        Task<Member[]> SearchMemberByString(string queryString);
        Task<Member[]> SearchMemberByAgeRange(int startAge, int endAge);
        Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate);

        //Reservation
        Task<Reservation[]> AllReservations();

        bool AddReservation(Reservation reservation);
        bool RemoveReservation(int reservationId);
        Reservation EditReservation(int reservationId);
        IEnumerable<Reservation> SortedReservations(ReservationSortingType sortingType);
        Task<Reservation[]> SearchReservationsByDate(DateTime startDate, DateTime endDate);
        Task<Reservation[]> SearchReservationsByField(string queryStringField);
        Task<Reservation[]> SearchReservationsByMemberName(string memberName);

        // Field
        Task<Field[]> AllFields();

        bool AddField(Field field);
        bool RemoveField(Field field);
        Field EditField(int fieldId);
        IEnumerable<Field> SortedFields(FieldSortingType sortingType);
        Task<Field[]> SearchFieldByName(string fieldName);
        Task<Field[]> SearchFieldByType(TerrainType fieldType);
        Task<Field[]> SearchFieldBySport(SportType sportType);

        // To Populate Database
        bool PopulateDB();
        
    }
    
    public enum MemberSortingType
    {
        Surname, DorAscending, DorDescending
    }

    public enum ReservationSortingType
    {
        Date, Field, Member
    }

    public enum FieldSortingType
    {
        Type, Sport
    }
}
