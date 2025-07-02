using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

/// <summary>Represents a user-owned virtual storage space.</summary>
[Serializable]
public class Space
{
    /// <summary>Unique identifier of the space.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>The owner of the space.</summary>
    [JsonPropertyName("owner")]
    public Member Owner { get; set; } = null!;

    /// <summary>Display name of the space.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Root space folder.</summary>
    [JsonPropertyName("folder")]
    public Folder Folder { get; set; } = new();

    /// <summary>List of members that have access to the space.</summary>
    [JsonPropertyName("members")]
    public List<Member> Members { get; set; } = [];

    /// <summary>List of shares created for this space (public, private, or file-specific).</summary>
    [JsonPropertyName("shares")]
    public List<Share> Shares { get; set; } = [];

    /// <summary>The timestamp when the space was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>The timestamp when the space was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}