using System.Runtime.Serialization;

namespace WebApi.Controllers.V1.CompanyThree.Request
{
    [DataContract]
    public class CompanyThreeAddress
    {
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }
}
