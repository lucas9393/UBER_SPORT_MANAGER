﻿using System;
using System.Collections.Generic;

namespace USM_Model
{
    public class Reservation
    {
        public Field Field { get; set; }
        public Member Member { get; set; }
        public Challenge Challenge { get; set; }
        public bool IsDouble { get; set; }
        public DateTime Date { get; set; }

        public Reservation(Field field, Member member, DateTime date, bool isDouble=false)
        {
            Field = field;
            Member = member;
            IsDouble = isDouble;
            Date = date;

        }

        public decimal Price() => IsDouble ? Field.Price * 1.25m : Field.Price;
        //{
        //    if(IsDouble)
        //    {
        //        return Field.Price* 1.25m;
        //    }
        //    else
        //    {
        //        return Field.Price;
        //    }
        //}

        public int MaxPlayer() => IsDouble ? Field.MaxPlayer * 2 : Field.MaxPlayer;
        //{
        //    switch(Field)
        //    {
        //        case PaddleField p:
        //            return 4;
        //        case SoccerField s:
        //            if(s.IsSeven)
        //            {
        //                return 14;
        //            }
        //            else
        //            {
        //                return 10;
        //            }
        //        case TennisField t:
        //            if (IsDouble)
        //            {
        //                return 4;
        //            }
        //            else
        //            {
        //                return 2;
        //            }
        //        default:
        //            return -1;
        //    }
        //}
       
    }
}