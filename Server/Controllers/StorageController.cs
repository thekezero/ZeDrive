using Microsoft.AspNetCore.Mvc;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;
using File = ZeDrive.Shared.Models.File;

namespace ZeDrive.Server.Controllers;

[ApiController]
[Route("/api/storage")]
public class StorageController([FromServices] IStorageRepository repository) : ControllerBase, IStorageRepository
{
    [HttpPost("file")]
    public Task<File?> CreateFileAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] string name,
        [FromQuery] Guid folderId, [FromQuery] string hash, [FromQuery] string key)
    {
        return repository.CreateFileAsync(token, space, name, folderId, hash, key);
    }

    [HttpPost("file/chuck")]
    public Task<Chunk?> CreateFileChuckAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id,
        [FromQuery] ulong sequence, [FromQuery] byte[] chuck)
    {
        return repository.CreateFileChuckAsync(token, space, id, sequence, chuck);
    }

    [HttpGet("file")]
    public Task<File?> GetFileAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id)
    {
        return repository.GetFileAsync(token, space, id);
    }

    [HttpDelete("file")]
    public Task<File?> DeleteFileAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id)
    {
        return repository.DeleteFileAsync(token, space, id);
    }

    [HttpPatch("file")]
    public Task<File?> RenameFileAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id,
        [FromQuery] string name)
    {
        return repository.RenameFileAsync(token, space, id, name);
    }

    [HttpPost("folder")]
    public Task<Folder?> CreateFolderAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] string name,
        Guid parentId)
    {
        return repository.CreateFolderAsync(token, space, name, parentId);
    }

    [HttpDelete("folder")]
    public Task<Folder?> DeleteFolderAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id)
    {
        return repository.DeleteFolderAsync(token, space, id);
    }

    [HttpPatch("folder")]
    public Task<Folder?> RenameFolderAsync([FromHeader] Token token, [FromQuery] Space space, [FromQuery] Guid id,
        [FromQuery] string name)
    {
        return repository.RenameFolderAsync(token, space, id, name);
    }

    [HttpPost("space")]
    public Task<Space?> CreateSpaceAsync([FromHeader] Token token, [FromQuery] string name)
    {
        return repository.CreateSpaceAsync(token, name);
    }

    [HttpGet("space")]
    public Task<Space?> GetSpaceAsync([FromHeader] Token token, [FromQuery] Guid id)
    {
        return repository.GetSpaceAsync(token, id);
    }

    [HttpGet("space/all")]
    public Task<List<Space>?> GetSpacesAsync([FromHeader] Token token)
    {
        return repository.GetSpacesAsync(token);
    }

    [HttpPatch("space")]
    public Task<Space?> RenameSpaceAsync([FromHeader] Token token, [FromQuery] Guid id, [FromQuery] string name)
    {
        return repository.RenameSpaceAsync(token, id, name);
    }

    [HttpDelete("space")]
    public Task<Space?> DeleteSpaceAsync([FromHeader] Token token, [FromQuery] Guid id)
    {
        return repository.DeleteSpaceAsync(token, id);
    }

    [HttpPost("space/member")]
    public Task<Member> CreateSpaceMemberAsync([FromHeader] Token token, [FromQuery] Guid id, [FromQuery] Guid userId,
        [FromQuery] string masterKey,
        bool isEditor)
    {
        return repository.CreateSpaceMemberAsync(token, id, userId, masterKey, isEditor);
    }

    [HttpGet("space/owner")]
    public Task<Member?> GetSpaceOwnerAsync([FromHeader] Token token, [FromQuery] Guid id)
    {
        return repository.GetSpaceOwnerAsync(token, id);
    }

    [HttpGet("space/member")]
    public Task<Member?> GetSpaceMemberAsync(Token token, Guid id, Guid memberId)
    {
        return repository.GetSpaceMemberAsync(token, id, memberId);
    }

    [HttpGet("space/member/all")]
    public Task<List<Member>?> GetSpaceMembersAsync([FromHeader] Token token, [FromQuery] Guid id)
    {
        return repository.GetSpaceMembersAsync(token, id);
    }

    [HttpDelete("space/member")]
    public Task<Member?> DeleteSpaceMemberAsync([FromHeader] Token token, [FromQuery] Guid id,
        [FromQuery] Guid memberId)
    {
        return repository.DeleteSpaceMemberAsync(token, id, memberId);
    }

    [HttpGet("capacity/total")]
    public Task<ulong?> GetTotalCapacityAsync([FromHeader] Token token)
    {
        return repository.GetTotalCapacityAsync(token);
    }

    [HttpGet("capacity/reserved")]
    public Task<ulong?> GetReservedCapacityAsync([FromHeader] Token token)
    {
        return repository.GetReservedCapacityAsync(token);
    }

    [HttpGet("capacity/available")]
    public Task<ulong?> GetAvailableCapacityAsync([FromHeader] Token token)
    {
        return repository.GetAvailableCapacityAsync(token);
    }
}