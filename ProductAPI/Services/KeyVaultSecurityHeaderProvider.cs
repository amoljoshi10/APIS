using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ProductAPI.Interfaces;

namespace ProductAPI.Services
{
    public class KeyVaultServiceProviderc : ISecurityHeaderProvider
    {
        string ISecurityHeaderProvider.GetSecurityHeader()
        {
            var client = new SecretClient(new System.Uri("https://kv-for-apim.vault.azure.net/"), new DefaultAzureCredential());
            return client.GetSecret("securityHeaader").Value.Value;

        }
    }
}
