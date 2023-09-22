namespace HVACTopGun.UI.Services;

public interface IApiKeyGenerator
{
    string GenerateKey(int length);
}