namespace OAuthCSharp
{
    using System;
    using System.Collections.Specialized;
    using System.Web;

    public class TokenBase
    {
        public string Token { get; protected set; }
        public string TokenSecret { get; protected set; }
        public NameValueCollection AdditionalProperties { get; private set; }

        public TokenBase()
        {
            AdditionalProperties = new NameValueCollection();
        }

        public void Init(string tokenResponse)
        {
            if (tokenResponse == null) { throw new ArgumentNullException("tokenResponse"); }

            var parts = tokenResponse.Split('&');
            foreach (var part in parts)
            {
                var nameValue = part.Split('=');
                if (nameValue.Length == 2)
                {
                    switch (nameValue[0])
                    {
                        case "oauth_token":
                            Token = HttpUtility.UrlDecode(nameValue[1]);
                            break;
                        case "oauth_token_secret":
                            TokenSecret = HttpUtility.UrlDecode(nameValue[1]);
                            break;
                        default:
                            AdditionalProperties.Add(nameValue[0], HttpUtility.UrlDecode(nameValue[1]));
                            break;
                    }
                }
            }
        }
    }

    public class RequestToken : TokenBase
    {
        public bool CallbackConfirmed { get; set; }
    }

    public class AccessToken : TokenBase
    {
    }
}