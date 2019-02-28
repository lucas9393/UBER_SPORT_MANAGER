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
        public EFDBContext Context;

        public EFUnitOfWork(IMemberRepository memberRepository, IReservationRepository reservationRepository, EFDBContext context)
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

        public async Task<Reservation[]> SearchReservationsByMemberName(string memberName)
        {
            return await ReservationRepository.SearchReservationsByMemberName(memberName);
        }

        public bool PopulateDB()
        {
            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo2 = new PaddleField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo3 = new SoccerField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);

            Context.Fields.Add(campo1);
            Context.Fields.Add(campo2);
            Context.Fields.Add(campo3);

            Context.SaveChanges();

            Member user1 = new Member(name: "Matteo", surname: "Bianchi", dor: DateTime.Now);
            Member user2 = new Member(name: "Alessio", surname: "Maggio", dor: DateTime.Now);

            Context.Members.Add(user1);
            Context.Members.Add(user2);

            Context.SaveChanges();
            Reservation reservation1 = new Reservation(field: campo1, member: user2, date: DateTime.Now, isDouble: false);
            Reservation reservation2 = new Reservation(field: campo2, member: user1, date: DateTime.Now, isDouble: false);
            Reservation reservation3 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);

            Context.Reservations.Add(reservation1);
            Context.Reservations.Add(reservation2);
            Context.Reservations.Add(reservation3);

            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
