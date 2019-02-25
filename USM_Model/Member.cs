using System;

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

        public Member() { }

        public Member(string nome, string cognome, DateTime dor)
        {
            Name = nome;
            Surname = cognome;
            DateOfRegistration = dor;
        }
    }
}