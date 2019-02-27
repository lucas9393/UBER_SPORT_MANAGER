using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace USM_Model
{
    public class Challenge
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public ICollection<MembersChallenges> MembersChallenges { get; set; }
        public int AvailableMembers { get; set; }

        public Challenge() { }

        public Challenge(Member challenger, int availableMembers)
        {
            MembersChallenges = new List<MembersChallenges>();
            AddPlayer(challenger);
        }

        public void AddPlayer(Member member)
        {
            if (AvailableMembers > 0)
            {
                MembersChallenges mc = new MembersChallenges();
                mc.Member = member;
                mc.Challenge = this;
                MembersChallenges.Add(mc);
                AvailableMembers--;
            }
            else
            {
                throw new ChallengeFullException();
            }
        }
    }

    [Serializable]
    internal class ChallengeFullException : Exception
    {
        public ChallengeFullException()
        {
        }

        public ChallengeFullException(string message) : base(message)
        {
        }

        public ChallengeFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ChallengeFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}