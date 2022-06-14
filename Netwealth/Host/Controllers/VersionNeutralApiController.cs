using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiVersionNeutral]
public class VersionNeutralApiController : BaseApiController
{
}
