using System;
using System.Collections.Generic;
using System.Text;
using USM_Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace USM_EF_Helper
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IMemberRepository MemberRepository { get; set; }
        public IReservationRepository ReservationRepository { get; set; }
        public DbContext Context;

        public EFUnitOfWork(IMemberRepository memberRepository, IReservationRepository reservationRepository, DbContext context)
        {
            MemberRepository = memberRepository;
            ReservationRepository = reservationRepository;
            Context = context;
        }


        //public IEnumerable<Field> Fields { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Member[]> AllMembers()
        {
            return await MemberRepository.AllMembers();
        }

        public async Task<Reservation[]> AllReservations()
        {
            return await ReservationRepository.AllReservations();
        }


        public bool AddMember(Member member)
        {
            bool memberAdded = MemberRepository.AddMember(member);
            if (memberAdded)
            {
                Context.SaveChanges();
            }
            return memberAdded;
        }

        public bool AddReservation(Reservation reservation)
        {
            bool reservationAdded = ReservationRepository.AddReservation(reservation);
            if (reservationAdded)
            {
                Context.SaveChanges();
            }
            return reservationAdded;
        }


        public bool RemoveMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReservation(int reservationId)
        {
            throw new NotImplementedException();
        }


        public Member EditMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public Reservation EditReservation(int reservationId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Member> SortedMembers(MemberSortingType sortingType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> SortedReservations(ReservationSortingType sortingType)
        {
            throw new NotImplementedException();
        }


        //Metodi di filtraggio per i members
        public async Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate)
        {
            return await MemberRepository.SearchMemberByDateOfRegistration(startDate, endDate);
        }

        public async Task<Member[]> SearchMemberByAgeRange(int startAge, int endAge)
        {
            return await MemberRepository.SearchMembersByAgeRange(startAge, endAge);
        }

        public async Task<Member[]> SearchMemberByString(string queryString)
        {
            return await MemberRepository.SearchMemberByString(queryString);
        }


        //Metodi di filtraggio per le reservations
        public async Task<Reservation[]> SearchReservationsByDate(DateTime startDate, DateTime endDate)
        {
            return await ReservationRepository.SearchReservationsByDate(startDate, endDate);
        }

        public async Task<Reservation[]> SearchReservationsByField(string queryStringField)
        {
            return await ReservationRepository.SearchReservationsByField(queryStringField);
        }

        public async Task<Reservation[]> SearchReservationsByMember(string queryStringMember)
        {
            return await ReservationRepository.SearchReservationsByMember(queryStringMember);
        }

    }
}
