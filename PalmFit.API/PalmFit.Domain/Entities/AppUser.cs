using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmFit.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public DateTime LastOnLine { get; set; }
        public bool IsVerified { get; set; }
        public bool IsArchived { get; set; }
        public bool IsActive { get; set; }
        public string ReferralCode { get; set; }
        public string InviteCode { get; set; }
    }
}
