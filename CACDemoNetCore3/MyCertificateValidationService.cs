using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CACDemoNetCore3
{
    public class MyCertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            var rootCert = new X509Certificate2("rootCA.cer");

            var clientChain = new X509Chain();
            clientChain.Build(clientCertificate);

            var clientChainElements = clientChain.ChainElements;

            var clientRootCert = clientChainElements[clientChainElements.Count - 1].Certificate;

            return rootCert.Thumbprint == clientRootCert.Thumbprint;
        }
    }
}
