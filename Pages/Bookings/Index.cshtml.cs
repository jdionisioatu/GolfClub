using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public IndexModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.PlayerFour)
                .Include(b => b.PlayerOne)
                .Include(b => b.PlayerThree)
                .Include(b => b.PlayerTwo).ToListAsync();
            }
        }
    }
}
