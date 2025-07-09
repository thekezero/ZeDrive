using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ZeDrive.Shared.Models;

/// <summary>Represents a user's membership and access level within a specific space.</summary>
[Serializable]
[Index(nameof(MasterKey), IsUnique = true)]
public class Member
{
    /// <summary>Unique identifier of the membership entry (not the user's ID).</summary>
    [JsonPropertyName("id")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Encrypted Master Key (encrypted using the user's Master Key). Base64 encoded.</summary>
    [JsonPropertyName("master_key")]
    public string MasterKey { get; set; } = string.Empty;

    /// <summary>Indicates whether the user is the owner of the space.</summary>
    [JsonPropertyName("is_owner")]
    public bool IsOwner { get; set; } = false;

    /// <summary>
    ///     Indicates whether the user has permission to view and edit the space when true, otherwise (false) view-only
    ///     access to the space.
    /// </summary>
    [JsonPropertyName("is_editor")]
    public bool IsEditor { get; set; } = false;

    /// <summary>Date and time when the membership was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Date and time when the membership was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}