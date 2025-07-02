namespace ZeDrive.Shared.Models;

/// <summary>Represents the type of resource allocated to a user's plan or subscription.</summary>
public enum ResourceType
{
    /// <summary>Undefined or unspecified resource type.</summary>
    Undefined = 0,

    /// <summary>Basic membership resource (e.g., free or base plan).</summary>
    BasicMembership = 100,

    /// <summary>Premium membership resource (higher tier plan).</summary>
    PremiumMembership = 1000,

    /// <summary>Additional storage capacity resource (extra space beyond base plan).</summary>
    AdditionalStorage = 1001
}
