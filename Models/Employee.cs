using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public required string Name { get; set; }

        [DataMember]
        public required string Position { get; set; }

        [DataMember]
        public string? Email { get; set; }

        [DataMember]
        public string? Phone { get; set; }

    }
}
