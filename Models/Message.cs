using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Message(string heading, string description)
    {

        [DataMember] public string? Heading { get; set; } = heading;

        [DataMember] public string? Description { get; set; } = description;

        [DataMember] public bool IsRead { get; set; } = false;
    }
}
