namespace OAuthCSharp
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class OAuthProtocolException : Exception
    {
        public OAuthProtocolException()
            : base()
        { }

        public OAuthProtocolException(string message)
            : base(message)
        { }

        public OAuthProtocolException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected OAuthProtocolException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}