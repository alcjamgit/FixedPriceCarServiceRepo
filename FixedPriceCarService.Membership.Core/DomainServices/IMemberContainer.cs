using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedPriceCarService.Membership.Core.Entities;

namespace FixedPriceCarService.Membership.Core.DomainServices
{
    public interface IMemberContainer
    {
        IEnumerable<Member> MemberList { get; set; }
    }
}
