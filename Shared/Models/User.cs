using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

/// <summary>Represents a user within the ZeDrive system.</summary>
[Serializable]
public class User
{
    /// <summary>Unique identifier of the user entity (internal ID).</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>External user account identifier (e.g., from auth provider).</summary>
    [JsonPropertyName("shared_id")]
    public string SharedId { get; set; } = string.Empty;

    /// <summary>The username or display name of the user.</summary>
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;

    ///<summary>The user pseudonym (displayed name)</summary>
    [JsonPropertyName("name")]
    private string Pseudonym { get; set; } = string.Empty;

    /// <summary>Storage assigned to this user.</summary>
    [JsonPropertyName("storage")]
    public Storage Storage { get; set; } = new();
    
    ///<summary>User plans</summary>
    [JsonPropertyName("plan")]
    public Plan Plan { get; set; } = new();

    /// <summary>The timestamp when the user was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>The timestamp when the user was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}