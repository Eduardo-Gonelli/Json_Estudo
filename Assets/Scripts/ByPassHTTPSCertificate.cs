using UnityEngine.Networking;

public class ByPassHTTPSCertificate : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}
