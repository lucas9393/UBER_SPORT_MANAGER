using System;
using System.Collections.Generic;
using System.Text;

namespace USM_Model
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Members { get;}

        bool AddMember(Member member);
    }
}
