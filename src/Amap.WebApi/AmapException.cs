using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    [Serializable]
    public class AmapException : Exception
    {
        public AmapException()
        {
        }

        public AmapException(string message)
            : base(message)
        {
        }

        public AmapException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AmapException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
