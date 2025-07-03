using Microsoft.AspNetCore.Mvc;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;

namespace ZeDrive.Server.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController([FromServices] IUserRepository repository) : ControllerBase, IUserRepository
{
    [HttpGet]
    public Task<User?> GetUserAsync([FromHeader] Token token)
    {
        return repository.GetUserAsync(token);
    }

    [HttpGet("id")]
    public Task<Guid?> GetIdAsync([FromHeader] Token token)
    {
        return repository.GetIdAsync(token);
    }

    [HttpGet("id/shared")]
    public Task<Guid?> GetSharedIdAsync([FromHeader] Token token)
    {
        return repository.GetSharedIdAsync(token);
    }

    [HttpGet("username")]
    public Task<string?> GetUsernameAsync([FromHeader] Token token)
    {
        return repository.GetUsernameAsync(token);
    }

    [HttpGet("pseudonym")]
    public Task<string?> GetPseudonymAsync([FromHeader] Token token)
    {
        return repository.GetPseudonymAsync(token);
    }

    [HttpPatch("pseudonym")]
    public Task<string?> UpdatePseudonymAsync([FromHeader] Token token, [FromQuery] string value)
    {
        return repository.UpdatePseudonymAsync(token, value);
    }

    [HttpGet("storage")]
    public Task<Storage?> GetStorageAsync([FromHeader] Token token)
    {
        return repository.GetStorageAsync(token);
    }
}