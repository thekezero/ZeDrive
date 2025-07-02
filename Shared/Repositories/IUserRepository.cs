using ZeDrive.Shared.Models;

namespace ZeDrive.Shared.Repositories;

/// <summary>
///     Defines a contract for retrieving and updating user-related data in the ZeDrive system. <br />
///     All operations are scoped to an authenticated user token.
/// </summary>
public interface IUserRepository
{
    /// <summary>Retrieves the complete user profile, including internal ID, shared ID, and metadata.</summary>
    Task<User?> GetUserAsync(Token token);

    /// <summary>Gets the internal system ID of the current user (used internally by ZeDrive).</summary>
    Task<Guid?> GetIdAsync(Token token);

    /// <summary>Gets the public/shared identifier of the user (used in shares and pseudonymous references).</summary>
    Task<Guid?> GetSharedIdAsync(Token token);

    /// <summary>Retrieves the current unique name of the user.</summary>
    Task<string?> GetUsernameAsync(Token token);

    /// <summary>Retrieves the current pseudonym of the user, used in anonymous/obfuscated shares.</summary>
    Task<string?> GetPseudonymAsync(Token token);

    /// <summary>Updates the user's pseudonym and returns the updated value.</summary>
    Task<string?> UpdatePseudonymAsync(Token token, string value);

    /// <summary>Retrieves the user's current storage.</summary>
    Task<Storage?> GetStorageAsync(Token token);
}