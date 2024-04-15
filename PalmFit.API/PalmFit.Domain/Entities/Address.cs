using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmFit.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
