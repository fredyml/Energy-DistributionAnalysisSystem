using System.Runtime.Serialization;

namespace EDAS.Domain.Exceptions
{
    public class NotFoundException : Exception, ISerializable
    {
        public NotFoundException(string message) : base(message)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
           
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
