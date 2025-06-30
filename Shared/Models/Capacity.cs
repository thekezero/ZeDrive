using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents an additional capacity with expiration and cancellation state.</summary>
[Serializable]
public class Capacity
{
    ///<summary>Unique identifier of the capacity.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>Name or description of the extra capacity.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    ///<summary>Capacity value in bytes.</summary>
    [JsonPropertyName("value")]
    public ulong Value { get; set; } = 0;

    ///<summary>Indicates if the capacity has been cancelled.</summary>
    [JsonPropertyName("is_cancelled")]
    public bool IsCancelled { get; set; } = false;

    ///<summary>Date and time when the capacity was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the capacity expires.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime ExpiredAt { get; set; } = DateTime.MaxValue;
}