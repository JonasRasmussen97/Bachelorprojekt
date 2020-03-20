using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Organization
    {
        public String Name { get; set; }
        public Dictionary<String, Location> Locations { get; set; }
        public OrganizationAdmin Admin { get; set; }

    }
}
