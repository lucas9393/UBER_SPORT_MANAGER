using System;
using System.Collections.Generic;

namespace USM_Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int? ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        public bool IsDouble { get; set; }
        public DateTime Date { get; set; }

        public Reservation() { }

        public Reservation(Field field, Member member, DateTime date, bool isDouble=false)
        {
            Field = field;
            Member = member;
            IsDouble = isDouble;
            Date = date;

        }

        public decimal Price() => IsDouble ? Field.Price * 1.25m : Field.Price;
        public int MaxPlayer() => IsDouble ? Field.MaxPlayer * 2 : Field.MaxPlayer;
       
    }
}