using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public EditModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking =  await _context.Booking.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["PlayerFourId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
           ViewData["PlayerOneId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
           ViewData["PlayerThreeId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
           ViewData["PlayerTwoId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
          return (_context.Booking?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
