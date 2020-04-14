using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Entities
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get;set; }
        public string Name { get; set; }
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<EventParticipation> EventParticipations { get; set; }

        public Person()
        {
            EventParticipations = new List<EventParticipation>();
        }
    }
}
