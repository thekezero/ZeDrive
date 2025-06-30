using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents a JWT token with standard claims.</summary>
[Serializable]
public class Token
{
    ///<summary>Unique identifier of the entity.</summary>
    [JsonPropertyName("jit")]
    private string Id { get; set; } = string.Empty;

    ///<summary>Username (subject) of the token.</summary>
    [JsonPropertyName("sub")]
    public string Username { get; set; } = string.Empty;

    ///<summary>Pseudonymous identifier for the user.</summary>
    [JsonPropertyName("name")]
    private string Pseudonym { get; set; } = string.Empty;

    ///<summary>Audience (provider) of the token.</summary>
    [JsonPropertyName("aud")]
    public string Provider { get; set; } = string.Empty;

    ///<summary>Expiration date and time of the token.</summary>
    [JsonPropertyName("exp")]
    public DateTime ExpireAt { get; set; } = DateTime.UtcNow.AddYears(sbyte.MinValue);

    ///<summary>Issued at date and time of the token.</summary>
    [JsonPropertyName("iat")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddYears(sbyte.MaxValue);
}