using Microsoft.AspNetCore.Mvc;
using ZeDrive.Server.Data;
using ZeDrive.Shared.Models;
using ZeDrive.Shared.Repositories;

namespace ZeDrive.Server.Repositories;

public class PlanRepository([FromServices] DatabaseContext database) : IPlanRepository
{
    public Task<Plan?> GetPlan(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Resource?> GetBasicResource(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Resource?> GetPremiumResource(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<List<Resource>?> GetAdditionalStorageResources(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetTotalCapacity(Token token)
    {
        throw new NotImplementedException();
    }

    public Task<Resource?> AddOrRenewBasicResource(string serverKey, Guid planId, DateTime expireAt)
    {
        throw new NotImplementedException();
    }

    public Task<Resource?> AddOrRenewPremiumResource(string serverKey, Guid planId, DateTime expireAt)
    {
        throw new NotImplementedException();
    }

    public Task<Resource?> AddAdditionalStorageResource(string serverKey, Guid planId, DateTime expireAt,
        ulong bytesCount)
    {
        throw new NotImplementedException();
    }
}