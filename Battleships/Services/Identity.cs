using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class Identity
    {
        readonly IHttpContextAccessor httpAccessor;
        public Identity(IHttpContextAccessor httpContext)
        {
            this.httpAccessor = httpContext;
        }
        public string LoginId => httpAccessor.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
    }
}
