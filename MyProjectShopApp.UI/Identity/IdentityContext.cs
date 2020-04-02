using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Identity
{
    public class IdentityContext:IdentityDbContext<User>
    {

        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {

        }
    }
}
