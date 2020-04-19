using Ejc.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Entities
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Utc)]
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public IList<EventParticipation> EventParticipations { get; set; }

        public Person()
        {
            EventParticipations = new List<EventParticipation>();
        }

        public Person(string name, string phone, DateTime dateOfBirth, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
        }
    }
}
