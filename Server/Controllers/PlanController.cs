using Microsoft.AspNetCore.Mvc;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;

namespace ZeDrive.Server.Controllers;

[ApiController]
[Route("/api/plan")]
public class PlanController([FromServices] IPlanRepository repository) : ControllerBase, IPlanRepository
{
    [HttpGet]
    public Task<Plan?> GetPlan([FromHeader] Token token)
    {
        return repository.GetPlan(token);
    }

    [HttpGet("resource/basic")]
    public Task<Resource?> GetBasicResource([FromHeader] Token token)
    {
        return repository.GetBasicResource(token);
    }

    [HttpGet("resource/premium")]
    public Task<Resource?> GetPremiumResource([FromHeader] Token token)
    {
        return repository.GetPremiumResource(token);
    }

    [HttpGet("resource/storage/all")]
    public Task<List<Resource>?> GetAdditionalStorageResources([FromHeader] Token token)
    {
        return repository.GetAdditionalStorageResources(token);
    }

    [HttpGet("capacity/total")]
    public Task<decimal> GetTotalCapacity([FromHeader] Token token)
    {
        return repository.GetTotalCapacity(token);
    }

    [HttpPost("resource/basic")]
    public Task<Resource?> AddOrRenewBasicResource([FromQuery] string serverKey, [FromQuery] Guid planId,
        [FromQuery] DateTime expireAt)
    {
        return repository.AddOrRenewBasicResource(serverKey, planId, expireAt);
    }

    [HttpPost("resource/premium")]
    public Task<Resource?> AddOrRenewPremiumResource([FromQuery] string serverKey, [FromQuery] Guid planId,
        [FromQuery] DateTime expireAt)
    {
        return repository.AddOrRenewPremiumResource(serverKey, planId, expireAt);
    }

    [HttpPost("resource/storage")]
    public Task<Resource?> AddAdditionalStorageResource([FromQuery] string serverKey, [FromQuery] Guid planId,
        [FromQuery] DateTime expireAt,
        ulong bytesCount)
    {
        return repository.AddAdditionalStorageResource(serverKey, planId, expireAt, bytesCount);
    }
}