using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public required Order SelectedOrder { get; set; }

        [DataMember]
        public required OrderStatus WantedOrderStatus { get; set; }

        [DataMember]
        public RequestStatus Status { get; set; }

        [DataMember]
        public bool IsConsidered { get; set; } = false;
    }

    [DataContract]
    public enum RequestStatus
    {
        [EnumMember]
        Accepted,
        [EnumMember]
        Pending,
        [EnumMember]
        Declined
    }
}
