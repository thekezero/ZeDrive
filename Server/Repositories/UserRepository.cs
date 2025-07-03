using Microsoft.AspNetCore.Mvc;
using ZeDrive.Server.Data;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;

namespace ZeDrive.Server.Repositories;

public class UserRepository([FromServices] DatabaseContext database) : IUserRepository
{
    public Task<User?> GetUserAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> GetIdAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> GetSharedIdAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUsernameAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetPseudonymAsync(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<string?> UpdatePseudonymAsync(Token token, string value)
    {
        throw new NotImplementedException();
    }

    public Task<Storage?> GetStorageAsync(Token token)
    {
        throw new NotImplementedException();
    }
}