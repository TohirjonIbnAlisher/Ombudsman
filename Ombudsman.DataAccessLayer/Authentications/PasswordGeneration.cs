using System.Security.Cryptography;
using System.Text;

namespace Ombudsman.DataAccessLayer.Authentications;

public sealed class PasswordGeneration : IPasswordGeneration
{
    private const int KeySize = 32;
    private const int IterationsCount = 1000;

    public string Encrypt(string password, string salt)
    {
        using (var algorithm = new Rfc2898DeriveBytes(
            password: password,
            salt: Encoding.UTF8.GetBytes(salt),
            iterations: IterationsCount,
            hashAlgorithm: HashAlgorithmName.SHA256))
        {
            return Convert.ToBase64String(algorithm.GetBytes(KeySize));
        }
    }

    public bool Verify(string hash, string password, string salt)
    {

       var a = Encrypt(password, salt);

       return a.SequenceEqual(hash);
    }
}

