using System.Security.Cryptography;

using Elektrogrosshandel;

/// <summary>
/// Stellt Hilfsmethoden für die sichere Passwort-Hashing und -Verifizierung bereit.
/// Verwendet PBKDF2 mit SHA256 für kryptografisch sichere Passwort-Hashes.
/// </summary>
internal class PasswordHelper
{
    /// <summary>
    /// Die Größe des Salts in Bytes.
    /// </summary>
    private const int _saltSize = 16;

    /// <summary>
    /// Die Größe des resultierenden Hashes in Bytes.
    /// </summary>
    private const int _hashSize = 32;

    /// <summary>
    /// Die Anzahl der Iterationen für den PBKDF2-Algorithmus.
    /// </summary>
    private const int _iterations = 10000;

    /// <summary>
    /// Generiert einen kryptografisch sicheren zufälligen Salt.
    /// </summary>
    /// <param name="size">Die Größe des Salts in Bytes. Standardwert ist 16 Bytes.</param>
    /// <returns>Ein Byte-Array mit dem generierten Salt.</returns>
    private static byte[] GenerateSalt(int size = _saltSize)
    {
        var saltBytes = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        return saltBytes;
    }

    /// <summary>
    /// Hasht ein Passwort mit einem vorhandenen Salt.
    /// </summary>
    /// <param name="password">Das zu hashende Passwort.</param>
    /// <param name="salt">Der Salt, der für das Hashing verwendet werden soll.</param>
    /// <returns>Der Base64-codierte Passwort-Hash.</returns>
    public static string HashPassword(string password, byte[] salt)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            _iterations,
            HashAlgorithmName.SHA256,
            _hashSize);
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Hasht ein Passwort und generiert einen neuen Salt.
    /// </summary>
    /// <param name="password">Das zu hashende Passwort.</param>
    /// <param name="Salt">Der generierte Salt als Out-Parameter.</param>
    /// <returns>Der Base64-codierte Passwort-Hash.</returns>
    public static string HashPassword(string password, out byte[] Salt)
    {
        byte[] salt = GenerateSalt();
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            _iterations,
            HashAlgorithmName.SHA256,
            _hashSize);

        Salt = salt;
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Verifiziert ein Passwort gegen den gespeicherten Hash eines Benutzerkontos.
    /// </summary>
    /// <param name="userName">Der Benutzername des zu verifizierenden Kontos.</param>
    /// <param name="password">Das zu verifizierende Passwort.</param>
    /// <returns>True, wenn das Passwort mit dem gespeicherten Hash übereinstimmt; andernfalls False.</returns>
    public static bool VerifyPassword(string userName, string password)
    {
        byte[] salt = Account.GetAccountSalt(userName);
        string storedHash = Account.GetAccountPasswordHash(userName);
        string passwordHash = HashPassword(password, salt);

        if (passwordHash == storedHash)
        {
            return true;
        }

        return false;
    }
}
