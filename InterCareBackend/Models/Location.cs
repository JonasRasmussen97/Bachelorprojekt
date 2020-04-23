using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace InterCareBackend.Models
{
    public class Location
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Images { get; set; }
        public List<string> Managers { get; set; }


        public Location(string name, string address, string PostalCode, string Country, string Images, List<string> Managers)
        {
            this.Name = name;
            this.Address = address;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.Images = Images;
            this.Managers = Managers;
        }

        public Location(string id, string name, string address, string PostalCode, string Country, string Images, List<string> Managers)
        {
            this.Name = name;
            this.Address = address;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.Images = Images;
            this.Managers = Managers;
            this.Id = id;
        }

        public Location()
        {
        }
    }
}
