namespace Ombudsman.DataAccessLayer.Authentications;

public interface IPasswordGeneration
{
    string Encrypt(string password, string salt);
    bool Verify(string hash, string password, string salt);
}
