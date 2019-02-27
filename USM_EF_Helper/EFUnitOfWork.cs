using System;
using System.Collections.Generic;
using System.Text;
using USM_Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace USM_EF_Helper
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IMemberRepository MemberRepository { get; set; }
        public DbContext Context;

        public EFUnitOfWork(IMemberRepository memberRepository, DbContext context)
        {
            MemberRepository = memberRepository;
            Context = context;
        }

   
        //public IEnumerable<Field> Fields { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool AddMember(Member member)
        {
            bool memberAdded = MemberRepository.AddMember(member);
            if(memberAdded)
            {
                Context.SaveChanges();
            }
            return memberAdded;
        }

        public Member EditMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<Member[]> SearchMemberByString(string queryString)
        {
            return await MemberRepository.SearchMemberByString(queryString);
        }

        public IEnumerable<Member> SortedMembers(MemberSortingType sortingType)
        {
            throw new NotImplementedException();
        }

        public async Task<Member[]> AllMembers()
        {
           return await MemberRepository.AllMembers();
        }

        public async Task<Member[]> SearchMemberByAgeRange(int startAge, int endAge)
        {
            return await MemberRepository.SearchMembersByAgeRange(startAge, endAge);
        }

        public async Task<Member[]> SearchMemberByDateOfRegistration(DateTime startDate, DateTime endDate)
        {
            return await MemberRepository.SearchMemberByDateOfRegistration(startDate, endDate);
        }
    }
}
