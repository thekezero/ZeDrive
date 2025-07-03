using ZeDrive.Shared.Models;
using File = ZeDrive.Shared.Models.File;

namespace ZeDrive.Shared.Repositories;

/// <summary>Provides access to all storage-related operations for files, folders, spaces, members, and capacity.</summary>
public interface IStorageRepository
{
    #region File

    /// <summary>Creates a new file inside a space.</summary>
    Task<File?> CreateFileAsync(Token token, Space space, string name, Guid folderId, string hash, string key);

    /// <summary>Uploads a chunk for a specific file by sequence.</summary>
    Task<Chunk?> CreateFileChuckAsync(Token token, Space space, Guid id, ulong sequence, byte[] chuck);

    /// <summary>Retrieves a file by ID within the given space.</summary>
    Task<File?> GetFileAsync(Token token, Space space, Guid id);

    /// <summary>Deletes a file by ID from the space.</summary>
    Task<File?> DeleteFileAsync(Token token, Space space, Guid id);

    /// <summary>Renames a file within the space.</summary>
    Task<File?> RenameFileAsync(Token token, Space space, Guid id, string name);

    #endregion

    #region Folder

    /// <summary>Creates a new folder at the specified path inside a space.</summary>
    Task<Folder?> CreateFolderAsync(Token token, Space space, string name, Guid parentId);

    /// <summary>Deletes a folder by ID from the space.</summary>
    Task<Folder?> DeleteFolderAsync(Token token, Space space, Guid id);

    /// <summary>Renames a folder inside the space by updating its path.</summary>
    Task<Folder?> RenameFolderAsync(Token token, Space space, Guid id, string name);

    #endregion

    #region Space

    /// <summary>Creates a new space with the specified ID and name.</summary>
    Task<Space?> CreateSpaceAsync(Token token, string name);

    /// <summary>Retrieves a space by ID.</summary>
    Task<Space?> GetSpaceAsync(Token token, Guid id);

    /// <summary>Lists all spaces associated with the user.</summary>
    Task<List<Space>?> GetSpacesAsync(Token token);

    /// <summary>Renames an existing space.</summary>
    Task<Space?> RenameSpaceAsync(Token token, Guid id, string name);

    /// <summary>Deletes a space by ID.</summary>
    Task<Space?> DeleteSpaceAsync(Token token, Guid id);

    #endregion

    #region Member

    /// <summary>Adds a new member to a space with the provided encrypted master key and role.</summary>
    Task<Member> CreateSpaceMemberAsync(Token token, Guid id, Guid userId, string masterKey, bool isEditor);

    /// <summary>Gets the owner of a space.</summary>
    Task<Member?> GetSpaceOwnerAsync(Token token, Guid id);
    
    /// <summary>Gets the members of a space.</summary>
    Task<Member?> GetSpaceMemberAsync(Token token, Guid id, Guid memberId);

    /// <summary>Lists all members of a space.</summary>
    Task<List<Member>?> GetSpaceMembersAsync(Token token, Guid id);

    /// <summary>Removes a member from a space.</summary>
    Task<Member?> DeleteSpaceMemberAsync(Token token, Guid id, Guid memberId);

    #endregion

    #region Capacity

    /// <summary>Gets the total storage capacity for the user's plan.</summary>
    Task<ulong?> GetTotalCapacityAsync(Token token);

    /// <summary>Gets the reserved storage capacity (used space).</summary>
    Task<ulong?> GetReservedCapacityAsync(Token token);

    /// <summary>Gets the remaining available storage capacity.</summary>
    Task<ulong?> GetAvailableCapacityAsync(Token token);

    #endregion
}