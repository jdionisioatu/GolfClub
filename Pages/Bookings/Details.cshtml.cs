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
    public class DetailsModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public DetailsModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

      public Booking Booking { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
                Booking.PlayerOne = _context.Member.FirstOrDefault(m => m.MembershipNumberId == Booking.PlayerOneId);
                if (Booking.PlayerTwoId != 0)
                {
                    Booking.PlayerTwo = _context.Member.FirstOrDefault(m => m.MembershipNumberId == Booking.PlayerTwoId);
                }
                if (Booking.PlayerThreeId != 0)
                {
                    Booking.PlayerThree = _context.Member.FirstOrDefault(m => m.MembershipNumberId == Booking.PlayerThreeId);
                }
                if (Booking.PlayerFourId != 0)
                {
                    Booking.PlayerFour = _context.Member.FirstOrDefault(m => m.MembershipNumberId == Booking.PlayerFourId);
                }
            }
            return Page();
        }
    }
}
