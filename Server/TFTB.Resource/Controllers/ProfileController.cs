using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFTB.Resource.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            var idToken = await HttpContext.GetTokenAsync("id_token");

            var _idToken = await JwtSecurityTokenHandler().ReadJwtToken(idToken);
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}