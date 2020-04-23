using System.Collections.Generic;

namespace InterCareBackend.Models
{
    public class Organization
    {

        public string id { get; set; }
        public string Name { get; set; }
        public List<string> Locations { get; set; }
        public string AdminId { get; set; }

        public Organization(string id, string name, List<string> locations, string adminId)
        {
            this.id = id;
            Name = name;
            Locations = locations;
            AdminId = adminId;
        }

        // Used when clients can retrieve a list of all organizations. We then only send them name and the list of locations to prevent them from seeing data they are not supposed to see.
        public Organization(string name, List<string> locations)
        {
            Name = name;
            Locations = locations;
        }

    }


}
