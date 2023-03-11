using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;

namespace GolfClub.Data
{
    public class GolfClubContext : DbContext
    {
        public GolfClubContext (DbContextOptions<GolfClubContext> options)
            : base(options)
        {
        }

        public DbSet<GolfClub.Models.Booking> Booking { get; set; } = default!;

        public DbSet<GolfClub.Models.Member> Member { get; set; } = default!;
    }
}
