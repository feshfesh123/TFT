using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFTB.Identity.Models;

namespace TFTB.Identity.Data
{
    public class TFTBDbcontext : IdentityDbContext<User, Role, string>
    {
        public TFTBDbcontext(DbContextOptions options) : base(options)
        {
     
        }
    }
}
    