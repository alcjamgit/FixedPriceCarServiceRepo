using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedPriceCarService.Membership.Core.Entities;

namespace FixedPriceCarService.Membership.Infrastructure.DomainServices
{
    public static class MemberContainer
    {
        public static List<Member> MemberList { get; set; }  
    }
}
