using System.Security.Cryptography;

namespace HVACTopGun.UI.Services;

public class ApiKeyGenerator : IApiKeyGenerator
{
    public string GenerateKey(int byteLength)
    {
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        var randomNumber = new byte[byteLength];
        randomNumberGenerator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
