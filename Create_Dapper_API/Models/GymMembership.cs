using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Create_Dapper_API.Models
{
    public class GymMembership
    {
        public int MemberID { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public bool IsActive { get; set; }
    }
}