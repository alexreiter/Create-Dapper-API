using Create_Dapper_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Dapper_API.DAL
{
    internal interface IGymMembershipRepository
    {
        List<GymMembership> GetGymMemberships(int amount, string sort);
        GymMembership GetSingleGymMembership(int memberId);
        bool InsertGymMembership(GymMembership membership);
        bool DeleteGymMembership(int memberId);
        bool UpdateGymMembership(GymMembership membership);
    }
}
