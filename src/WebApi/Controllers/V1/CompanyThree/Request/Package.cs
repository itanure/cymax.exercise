using System.Runtime.Serialization;

namespace WebApi.Controllers.V1.CompanyThree.Request
{
    [DataContract]
    public class Package
    {
        [DataMember]
        public double Length { get; set; }
        [DataMember]
        public double Width { get; set; }
        [DataMember]
        public double Height { get; set; }
        [DataMember]
        public double Weight { get; set; }

    }
}
