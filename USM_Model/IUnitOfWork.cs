using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace USM_Model
{
    public interface IUnitOfWork
    {       
        bool AddMember(Member member);
        bool RemoveMember(int memberId);
        Task<Member[]> SearchMemberByString(string queryString);
        Member EditMember(int memberId);
        IEnumerable<Member> SortedMembers(MemberSortingType sortingType);
        Task<Member[]> AllMembers();
        Task<Member[]> SearchMemberByAgeRange(int startAge, int endAge);
        Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate);
    }

    public enum MemberSortingType
    {
        Surname, DorAscending, DorDescending
    }
}
