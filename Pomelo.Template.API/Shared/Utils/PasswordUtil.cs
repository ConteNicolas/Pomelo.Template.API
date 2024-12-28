using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Pomelo.Template.API.Shared.Utils;

public class PasswordUtil
{
    public static string HashPassword(string password)
    {
        byte[] salt = [128 / 8];
        string pwdHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
        ));

        return pwdHashed;
    }
}