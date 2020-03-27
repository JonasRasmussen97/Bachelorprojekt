using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Organization
    {

        public String id { get; set; }
        public String Name { get; set; }
        public Dictionary<String, Location> Locations { get; set; }
        public OrganizationAdmin Admin { get; set; }

        public Organization(string id, string name, Dictionary<string, Location> locations, OrganizationAdmin admin)
        {
            this.id = id;
            Name = name;
            Locations = locations;
            Admin = admin;
        }
    }


}
