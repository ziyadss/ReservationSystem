using System.Text;

namespace ReservationSystem.DataStructures.Authentication;

/// <summary>
/// The settings for JWT tokens.
/// </summary>
public class JwtTokenSettings
{
    /// <summary>
    /// The secret key.
    /// </summary>
    public required string SecretKey { get; set; }
 
    /// <summary>
    /// The audience.
    /// </summary>
    public required string Audience { get; set; }

    /// <summary>
    /// The issuer.
    /// </summary>
    public required string Issuer { get; set; }

    /// <summary>
    /// The expiry time in seconds.
    /// </summary>
    public required int ExpiryTimeInSeconds { get; set; }

    /// <summary>
    /// The secret key's bytes.
    /// </summary>
    public byte[] KeyBytes => Encoding.ASCII.GetBytes(SecretKey);
}
