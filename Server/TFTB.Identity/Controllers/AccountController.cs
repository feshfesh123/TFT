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

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("name", model.Fullname));
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("money", "0"));
                return Ok();
            }
                
            else
                return BadRequest();
        }
    }
}