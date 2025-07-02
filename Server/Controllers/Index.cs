using Microsoft.AspNetCore.Mvc;

namespace ZeDrive.Server.Controllers;

[ApiController]
[Route("/")]
public class Index : ControllerBase
{
    [HttpGet]
    public List<string> Logs()
    {
        return [];
    }
}