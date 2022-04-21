using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApi.Controllers.V1.CompanyThree.Request
{
    [DataContract]
    public class CompanyThreeRequest
    {
        [DataMember]
        public CompanyThreeAddress Source { get; set; }
        [DataMember]
        public CompanyThreeAddress Destination { get; set; }
        [DataMember]
        public Package[] Packages { get; set; }
    }
}
