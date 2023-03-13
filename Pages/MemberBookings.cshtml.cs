using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GolfClub.Pages
{
    public class MemberBookingsModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public MemberBookingsModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Member> Member { get;set; } = default!;

        [BindProperty]
        public int MemberId { get; set; }  = default!;

        [BindProperty]
        public IList<Booking> Booking { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Member != null)
            {
                ViewData["MemberId"] = new SelectList(_context.Set<Member>().OrderBy(m => m.Name), "MembershipNumberId", "Name");
            }
            /*if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.PlayerFour)
                .Include(b => b.PlayerOne)
                .Include(b => b.PlayerThree)
                .Include(b => b.PlayerTwo).ToListAsync();
            }*/
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {            
            if (_context.Member != null)
            {
                ViewData["MemberId"] = new SelectList(_context.Set<Member>().OrderBy(m => m.Name), "MembershipNumberId", "Name");
            }
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.PlayerFour)
                .Include(b => b.PlayerOne)
                .Include(b => b.PlayerThree)
                .Include(b => b.PlayerTwo)
                .Where(b => b.PlayerOneId == MemberId || b.PlayerTwoId == MemberId || b.PlayerThreeId == MemberId || b.PlayerFourId == MemberId).ToListAsync();
            }
            return Page();
        }
    }
}
