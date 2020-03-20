using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Location
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }
        public ArrayList Images { get; set; }
        public Dictionary<String, LocationManager> Managers { get; set; }
    }
}
