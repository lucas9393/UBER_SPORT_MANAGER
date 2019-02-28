using System;
using System.Collections.Generic;

namespace USM_Model
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public ICollection<MembersChallenges> MembersChallenges { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public Member() { }

        public Member(string name, string surname, DateTime dor)
        {
            Name = name;
            Surname = surname;
            DateOfRegistration = dor;
        }


        public int? GetAge()
        {
            if (DateOfBirth == null)
            {
                return null;
            }
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Value.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }

    }
}