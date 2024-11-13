using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public required string Name { get; set; }

        [DataMember]
        public string? Author { get; set; }

        [DataMember]
        public long Isbn { get; set; }

        [DataMember]
        public int PublicationYear { get; set; }

        [DataMember]
        public int Pages { get; set; }
    }
}
