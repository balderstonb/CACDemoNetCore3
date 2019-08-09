using System.Security.Cryptography.X509Certificates;

namespace CACDemoNetCore3
{
    public class MyCertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            return clientCertificate.Issuer.StartsWith("CN=DOD ID CA"); //TODO: Get DoD root cert and validate chain
        }
    }
}
