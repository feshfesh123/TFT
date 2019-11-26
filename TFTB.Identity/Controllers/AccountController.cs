using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFTB.Identity.Models;
using TFTB.Identity.ViewModels;

namespace TFTB.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = new User() { Email = model.Email, UserName = model.Email };

            user.Claims.Add(new IdentityUserClaim<string>() { 
                ClaimType = JwtClaimTypes.GivenName,
                ClaimValue = model.Fullname
            });

            user.Claims.Add(new IdentityUserClaim<string>()
            {
                ClaimType = "money",
                ClaimValue = "0"
            });
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest();
        }
    }
}