using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.Data
{
    public class WebApplication1_SozialMediaPlatform01Context : DbContext
    {
        public WebApplication1_SozialMediaPlatform01Context (DbContextOptions<WebApplication1_SozialMediaPlatform01Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1_SozialMediaPlatform01.Models.User> User { get; set; } = default!;
        public DbSet<WebApplication1_SozialMediaPlatform01.Models.Like> Like { get; set; } = default!;
        public DbSet<WebApplication1_SozialMediaPlatform01.Models.Nachricht> Nachricht { get; set; } = default!;
        public DbSet<WebApplication1_SozialMediaPlatform01.Models.Peep> Peep { get; set; } = default!;
    }
}
