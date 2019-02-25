using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace USM_Model
{
    public class Challenge
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Challenger { get; set; }
        public List<Member> ATeam { get; set; }
        public List<Member> BTeam { get; set; }
        public int AvailableMembers { get; set; }

        public Challenge() { }

        public Challenge(Member challenger, int availableMembers)
        {
            Challenger = challenger;
            ATeam = new List<Member>();
            ATeam.Add(Challenger);
            BTeam = new List<Member>();
            AvailableMembers = availableMembers-1;
        }

        public void AddPlayer(Member member)
        {
            if (AvailableMembers > 0)
            {
                if (ATeam.Count() > BTeam.Count())
                {
                    BTeam.Add(member);
                }
                else
                {
                    ATeam.Add(member);
                }
                --AvailableMembers;

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