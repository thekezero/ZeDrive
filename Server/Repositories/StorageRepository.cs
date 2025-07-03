using Microsoft.AspNetCore.Mvc;
using ZeDrive.Server.Data;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;
using File = ZeDrive.Shared.Models.File;

namespace ZeDrive.Server.Repositories;

public class StorageRepository([FromServices] DatabaseContext database) : IStorageRepository
{
    public Task<File?> CreateFileAsync(Token token, Space space, string name, Guid folderId, string hash, string key)
    {
        throw new NotImplementedException();
    }

    public Task<Chunk?> CreateFileChuckAsync(Token token, Space space, Guid id, ulong sequence, byte[] chuck)
    {
        throw new NotImplementedException();
    }

    public Task<File?> GetFileAsync(Token token, Space space, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<File?> DeleteFileAsync(Token token, Space space, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<File?> RenameFileAsync(Token token, Space space, Guid id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Folder?> CreateFolderAsync(Token token, Space space, string name, Guid parentId)
    {
        throw new NotImplementedException();
    }

    public Task<Folder?> DeleteFolderAsync(Token token, Space space, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Folder?> RenameFolderAsync(Token token, Space space, Guid id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Space?> CreateSpaceAsync(Token token, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Space?> GetSpaceAsync(Token token, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Space>?> GetSpacesAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Space?> RenameSpaceAsync(Token token, Guid id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Space?> DeleteSpaceAsync(Token token, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Member> CreateSpaceMemberAsync(Token token, Guid id, Guid userId, string masterKey, bool isEditor)
    {
        throw new NotImplementedException();
    }

    public Task<Member?> GetSpaceOwnerAsync(Token token, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Member?> GetSpaceMemberAsync(Token token, Guid id, Guid memberId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Member>?> GetSpaceMembersAsync(Token token, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Member?> DeleteSpaceMemberAsync(Token token, Guid id, Guid memberId)
    {
        throw new NotImplementedException();
    }

    public Task<ulong?> GetTotalCapacityAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<ulong?> GetReservedCapacityAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<ulong?> GetAvailableCapacityAsync(Token token)
    {
        throw new NotImplementedException();
    }
}