using System.Runtime.Serialization;
namespace Application.Boundaries.Exception
{
    public  class ApplicationException : System.Exception
    {
        public ApplicationException()
        {
        }
        public ApplicationException(string message) : base(message)
        {
        }
        public ApplicationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
        public ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
