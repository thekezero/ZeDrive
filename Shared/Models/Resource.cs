using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

/// <summary>Represents a resource allocated to a user's plan, such as membership or storage.</summary>
[Serializable]
public class Resource
{
    /// <summary>Unique identifier of the resource entry.</summary>
    [JsonPropertyName("id")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>The type of resource (e.g., PremiumMembership, AdditionalStorage).</summary>
    [JsonPropertyName("type")]
    public ResourceType Type { get; set; } = ResourceType.Undefined;

    /// <summary>Value of the resource, stored as a string.</summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    /// <summary>Indicates whether this resource has been cancelled.</summary>
    [JsonPropertyName("is_cancelled")]
    public bool IsCancelled { get; set; } = false;

    /// <summary>Date and time when the resource was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Date and time when the resource expires.</summary>
    [JsonPropertyName("expired_at")]
    public DateTime ExpiredAt { get; set; } = DateTime.MaxValue;
}