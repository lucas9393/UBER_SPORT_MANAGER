using System;
using System.Collections.Generic;
using System.Text;
using USM_Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace USM_EF_Helper
{
    public class EFMemberRepository : IMemberRepository
    {
        public IQueryable<Member> Members => Context.Members;
        public EFDBContext Context { get; set; }

        public EFMemberRepository(EFDBContext context)
        {
            Context = context;
        }

        public bool AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public Member EditMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> SortedMembers(MemberSortingType sortingType)
        {
            throw new NotImplementedException();
        }

        public async Task<Member[]> AllMembers()
        {
            return await Members.ToArrayAsync();
        }

        public async Task<Member[]> SearchMemberByString(string queryString)
        {
            return await Members.Where(m => m.Name.Contains(queryString) || m.Surname.Contains(queryString)).ToArrayAsync();
        }

        public async Task<Member[]> SearchMembersByAgeRange(int startAge, int endAge)
        {
            return await Members.Where(m => m.GetAge() >= startAge && m.GetAge() <= endAge).ToArrayAsync();
        }

        public async Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate)
        {
            return await Members.Where(m => m.DateOfRegistration.Value >= startDate && m.DateOfRegistration.Value <= endDate).ToArrayAsync();
        }
    }
}
