using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Location
    {
        [BsonId]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }
        public String Images { get; set; }
        public List<String> Managers { get; set; }


        public Location(String name, String address, String PostalCode, String Country, String Images, List<String> Managers)
        {
            this.Name = name;
            this.Address = address;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.Images = Images;
            this.Managers = Managers;
        }

        public Location(String id, String name, String address, String PostalCode, String Country, String Images, List<String> Managers)
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
