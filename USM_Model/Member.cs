using System;

namespace USM_Model
{
    public class Member
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }

        public Member(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
    }
}