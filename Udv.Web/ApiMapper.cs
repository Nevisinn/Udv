using System.Net;
using Microsoft.AspNetCore.Mvc;
using Udv.Core.Models;
using Udv.Core.Models.DTO;
using Udv.Core.Models.Entities;

namespace Udv;

public static class ApiMapper
{
    public static ActionResult<T> Map<T>(Result<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(result.Value),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(result.Error),
            HttpStatusCode.NotFound => new NotFoundObjectResult(result.Error),
            HttpStatusCode.NoContent => new NoContentResult(),
        };
    }
}