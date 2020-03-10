using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class MyServices
    {
        readonly IHttpContextAccessor httpAccessor;
        public MyServices(IHttpContextAccessor httpContext)
        {
            this.httpAccessor = httpContext;
        }
        public string LoginId => httpAccessor.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
    }
}
