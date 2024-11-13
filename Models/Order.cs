using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public required string Number { get; set; }

        [DataMember]
        public string? Description { get; set; }

        [DataMember]
        public OrderStatus Status { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public required Book Book { get; set; }

        [DataMember]
        public required Employee Employee { get; set; }

        [DataMember]
        public required Customer Customer { get; set; }

        [DataMember]
        public DateTime RegistrationDate { get; set; }

        [DataMember]
        public DateTime CompletionDate { get; set; }
    }

    [DataContract]
    public enum OrderStatus
    {
        [EnumMember]
        InProgress,
        [EnumMember]
        Completed,
        [EnumMember]
        Cancelled,
        [EnumMember]
        Pending
    }
}
