using System;
using System.Collections.Generic;
using System.Text;
using USM_Model;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Member> Members { get => MemberRepository.Members;}
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

        public IEnumerable<Member> SearchMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> SortedMembers(MemberSortingType sortingType)
        {
            throw new NotImplementedException();
        }
    }
}
