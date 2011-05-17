using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cuahsi.wof.ruon
{
    public class ServiceConnectionException : System.ApplicationException
    {
         public ServiceConnectionException() : base() { }
    public ServiceConnectionException(string message) : base(message) { }
    public ServiceConnectionException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client. 
    protected ServiceConnectionException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
}
