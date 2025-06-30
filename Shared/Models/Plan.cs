using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents a user subscription plan with base capacity and optional extra capacities.</summary>
[Serializable]
public class Plan
{
    ///<summary>Unique identifier of the plan.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>Name of the plan.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    ///<summary>Base capacity in bytes of the plan.</summary>
    [JsonPropertyName("capacity")]
    public ulong Capacity { get; set; } = 0;

    ///<summary>List of extra capacities (e.g., add-ons) with expiration dates.</summary>
    [JsonPropertyName("capacities")]
    public List<Capacity> Capacities { get; set; } = [];

    ///<summary> Gets the total capacity by summing base capacity and all valid, not cancelled extra capacities. </summary>
    [JsonPropertyName("total_capacity")]
    public ulong TotalCapacity => GetTotalCapacity();

    ///<summary>Indicates if the plan is cancelled.</summary>
    [JsonPropertyName("is_cancelled")]
    public bool IsCancelled { get; set; } = false;

    ///<summary>Date and time when the plan was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the plan was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the plan expires.</summary>
    [JsonPropertyName("expire_at")]
    public DateTime ExpiredAt { get; set; } = DateTime.MaxValue;

    ///<summary>Gets the total capacity by summing base capacity and all valid, not cancelled extra capacities.</summary>
    public ulong GetTotalCapacity()
    {
        var now = DateTime.UtcNow;
        return Capacity + (ulong)Capacities.Where(x => !x.IsCancelled && x.ExpiredAt >= now).Sum(x => (long)x.Value);
    }
}