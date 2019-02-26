using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USM_Model;
    
    namespace UberSportManager.DTO
{
    public class ReservationDTO
    {
        public Field Field { get; set; }
        public Member Member { get; set; }
        public bool IsDouble { get; set; }
        public DateTime Date { get; set; }
    }
}
