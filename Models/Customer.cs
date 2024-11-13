using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public required string Name { get; set; }

        [DataMember]
        public DateTime AddressDate { get; set; }

        [DataMember]
        public string? Email { get; set; }
    }
}
