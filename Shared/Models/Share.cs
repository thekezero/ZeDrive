using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

/// <summary> Represents a secure share object that allows access to specific files or folders in ZeDrive. </summary>
[Serializable]
public class Share
{
    /// <summary>Unique identifier of the share.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Encrypted master key for accessing the share (base64).</summary>
    [JsonPropertyName("master_key")]
    public string MasterKey { get; set; } = string.Empty;

    /// <summary>Indicates whether the share is public (true) or private (false).</summary>
    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }

    /// <summary>Indicates whether this share represents a folder (true) or a group of files (false).</summary>
    [JsonPropertyName("is_folder")]
    public bool IsFolder { get; set; }

    /// <summary>List of shared file items, each with its own encrypted key.</summary>
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; } = [];

    /// <summary>Defines whether the share is currently active and accessible.</summary>
    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>Optional expiration date after which the share is invalid.</summary>
    [JsonPropertyName("expire_at")]
    public DateTime? ExpireAt { get; set; }

    /// <summary>Date and time when the share was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Date and time when the share was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}