using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace USM_Model
{
    public interface IMemberRepository
    {
        Task<Member[]> AllMembers();

        bool AddMember(Member member);
        bool RemoveMember(int memberId);
        Member EditMember(int memberId);
        IEnumerable<Member> SortedMembers(MemberSortingType sortingType);
        Task<Member[]> SearchMemberByString(string queryString);
        Task<Member[]> SearchMembersByAgeRange(int startAge, int endAge);
        Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate);
    }
}
