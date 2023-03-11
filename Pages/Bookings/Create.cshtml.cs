using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public CreateModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerFourId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
        ViewData["PlayerOneId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
        ViewData["PlayerThreeId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
        ViewData["PlayerTwoId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Email");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
