﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        public DeleteModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.MembershipNumberId == id);

            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }
            var member = await _context.Member.FindAsync(id);

            if (member != null)
            {
                var booking = _context.Booking.FirstOrDefault(b => b.PlayerOneId == id);
                if(booking != null)
                {
                    Member = member;
                    ViewData["ErrorMessage"] = "This member has one or more bookings and cannot be deleted";
                    return Page();
                }
                booking = _context.Booking.FirstOrDefault(b => b.PlayerTwoId == id);
                if (booking != null)
                {
                    Member = member;
                    ViewData["ErrorMessage"] = "This member has one or more bookings and cannot be deleted";
                    return Page();
                }
                booking = _context.Booking.FirstOrDefault(b => b.PlayerThreeId == id);
                if (booking != null)
                {
                    Member = member;
                    ViewData["ErrorMessage"] = "This member has one or more bookings and cannot be deleted";
                    return Page(); ;
                }
                booking = _context.Booking.FirstOrDefault(b => b.PlayerFourId == id);
                if (booking != null)
                {
                    Member = member;
                    ViewData["ErrorMessage"] = "This member has one or more bookings cannot be deleted";
                    return Page();
                }
                Member = member;
                _context.Member.Remove(Member);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
