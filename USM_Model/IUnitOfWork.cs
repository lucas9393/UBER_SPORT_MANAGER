using System;
using System.Collections.Generic;
using System.Text;

namespace USM_Model
{
    public interface IUnitOfWork
    {
        IEnumerable<Member> Members { get;}
        //IEnumerable<Field> Fields { get; set; }
        
        bool AddMember(Member member);
        bool RemoveMember(int memberId);
        IEnumerable<Member> SearchMemberByName(string name);
        Member EditMember(int memberId);
        IEnumerable<Member> SortedMembers(MemberSortingType sortingType);
    }

    public enum MemberSortingType
    {
        Surname, DorAscending, DorDescending
    }
}
