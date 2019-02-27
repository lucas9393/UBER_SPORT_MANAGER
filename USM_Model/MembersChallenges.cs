namespace USM_Model
{
    public class MembersChallenges
    {
            public int MemberId { get; set; }
            public Member Member { get; set; }
            public int ChallengeId { get; set; }
            public Challenge Challenge { get; set; }
    }
}