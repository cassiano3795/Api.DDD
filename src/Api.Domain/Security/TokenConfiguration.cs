using System.Collections.Generic;

namespace Api.Domain.Security
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }


        public string SecretKey { get; set; }
        public int Expiration { get; set; }
        public IList<string> Issuers { get; set; }
        public IList<string> Audiences { get; set; }
    }
}
