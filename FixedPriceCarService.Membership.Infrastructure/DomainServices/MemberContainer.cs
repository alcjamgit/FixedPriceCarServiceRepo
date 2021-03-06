﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedPriceCarService.Membership.Core.DomainServices;
using FixedPriceCarService.Membership.Core.Entities;

namespace FixedPriceCarService.Membership.Infrastructure.DomainServices
{

    public static class MemberContainer
    {
        static MemberContainer()
        {
            MemberList = new List<Member>();
        }
        public static List<Member> MemberList { get; set; }

        public static int GenerateMemberId()
        {
            if (MemberList.Count == 0)
            {
                return 1;
            }
            else
            {
                return MemberList.Max(m => m.Id) + 1;
            }
            
        }
    }
}
