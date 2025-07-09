using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZeDrive.Shared.Models;

///<summary>Represents a user subscription plan with base capacity and optional extra capacities.</summary>
[Serializable]
public class Plan
{
    ///<summary>Unique identifier of the plan.</summary>
    [JsonPropertyName("id")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    ///<summary>List of extra resources (e.g., add-ons) with expiration dates.</summary>
    [JsonPropertyName("resources")]
    public List<Resource> Resources { get; set; } = [];

    ///<summary> Gets the total capacity by summing base capacity and all valid, not cancelled extra capacities. </summary>
    [JsonPropertyName("total_capacity")]
    public decimal TotalCapacity => CalculateTotalCapacity();

    ///<summary>Date and time when the plan was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    ///<summary>Date and time when the plan was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    private decimal CalculateTotalCapacity()
    {
        var now = DateTime.UtcNow;

        var additionalStorage = Resources
            .Where(x => x is { Type: ResourceType.AdditionalStorage, IsCancelled: false } && x.ExpiredAt >= now)
            .Aggregate(decimal.Zero, (current, x) => current + decimal.Parse(x.Value));

        var basicStorage = Resources
            .Where(x => x is { Type: ResourceType.PremiumMembership, IsCancelled: false } && x.ExpiredAt >= now)
            .MinBy(x => x.CreatedAt)?.Value;

        var premiumStorage = Resources
            .Where(x => x is { Type: ResourceType.PremiumMembership, IsCancelled: false } && x.ExpiredAt >= now)
            .MinBy(x => x.CreatedAt)?.Value;

        var basicStorageValue = decimal.Parse(basicStorage ?? decimal.Zero.ToString());
        var premiumStorageValue = decimal.Parse(premiumStorage ?? decimal.Zero.ToString());

        return basicStorageValue + premiumStorageValue + additionalStorage;
    }
}