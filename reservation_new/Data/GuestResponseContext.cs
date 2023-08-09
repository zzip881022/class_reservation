using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using reservation_new.Models;

namespace reservation_new.Data
{
    public class GuestResponseContext : DbContext
    {
        public GuestResponseContext (DbContextOptions<GuestResponseContext> options)
            : base(options)
        {
        }

        public DbSet<reservation_new.Models.GuestResponse> responses { get; set; }
    }
}
