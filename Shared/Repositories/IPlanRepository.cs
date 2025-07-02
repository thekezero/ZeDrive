using ZeDrive.Shared.Models;

namespace ZeDrive.Shared.Repositories;

/// <summary>Repository interface for managing user subscription plans and related resources.</summary>
public interface IPlanRepository
{
    /// <summary>Gets the current plan for the user identified by the token.</summary>
    Task<Plan?> GetPlan(Token token);

    /// <summary>Gets the basic membership resource of the user's plan.</summary>
    Task<Resource?> GetBasicResource(Token token);

    /// <summary>Gets the premium membership resource of the user's plan.</summary>
    Task<Resource?> GetPremiumResource(Token token);

    /// <summary>Gets the list of additional storage resources for the user's plan.</summary>
    Task<List<Resource>?> GetAdditionalStorageResources(Token token);

    /// <summary>Calculates the total storage capacity available to the user.</summary>
    Task<decimal> GetTotalCapacity(Token token);

    /// <summary>
    ///     Adds or renews the basic membership resource for the specified plan.<br />
    ///     Requires a server key for internal authentication.
    /// </summary>
    Task<Resource?> AddOrRenewBasicResource(string serverKey, Guid planId, DateTime expireAt);

    /// <summary>
    ///     Adds or renews the premium membership resource for the specified plan.<br />
    ///     Requires a server key for internal authentication.
    /// </summary>
    Task<Resource?> AddOrRenewPremiumResource(string serverKey, Guid planId, DateTime expireAt);

    /// <summary>
    ///     Adds additional storage resource for the specified plan.<br />
    ///     Requires a server key for internal authentication.
    /// </summary>
    Task<Resource?> AddAdditionalStorageResource(string serverKey, Guid planId, DateTime expireAt, ulong bytesCount);
}