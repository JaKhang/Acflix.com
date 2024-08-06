namespace Infrastructure.Authentication.Config
{
    public class JwtProperties
    {
        public string SecretKey { get; set;}
        public string Issuer{ get; set;}
        public string Audience{ get; set;}
        public int Expiry { get; set; }

        public JwtProperties(string secretKey, string issuer, string audience, int expiry)
        {
            SecretKey = secretKey;
            Issuer = issuer;
            Audience = audience;
            Expiry = expiry;
        }

        public JwtProperties()
        {

        }
    }
}
