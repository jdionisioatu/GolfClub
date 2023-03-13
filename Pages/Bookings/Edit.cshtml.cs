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
using System.Media;

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

            var booking =  await _context.Booking.Include(x => x.PlayerOne).Include(x => x.PlayerTwo).Include(x => x.PlayerThree).Include(x => x.PlayerFour).FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
            
            if(Booking.PlayerTwoId == null)
            {
                var emptyMember = new Member { MembershipNumberId = 0, Name = "Optional" };

                var selectListOptionalList = new List<Member>
                {
                    emptyMember
                };
                foreach (var item in _context.Set<Member>().OrderBy(p => p.Name))
                {
                    selectListOptionalList.Add(item);
                }
                ViewData["PlayerTwoId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
            } else
            {
                ViewData["PlayerTwoId"] = new SelectList(_context.Set<Member>().OrderBy(p => p.Name), "MembershipNumberId", "Name");
            }
            if (Booking.PlayerThreeId == null)
            {
                var emptyMember = new Member { MembershipNumberId = 0, Name = "Optional" };

                var selectListOptionalList = new List<Member>
                {
                    emptyMember
                };
                foreach (var item in _context.Set<Member>().OrderBy(p => p.Name))
                {
                    selectListOptionalList.Add(item);
                }
                ViewData["PlayerThreeId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
            }
            else
            {
                ViewData["PlayerThreeId"] = new SelectList(_context.Set<Member>().OrderBy(p => p.Name), "MembershipNumberId", "Name");
            }
            if (Booking.PlayerFourId == null)
            {
                var emptyMember = new Member { MembershipNumberId = 0, Name = "Optional" };

                var selectListOptionalList = new List<Member>
                {
                    emptyMember
                };
                foreach (var item in _context.Set<Member>().OrderBy(p => p.Name))
                {
                    selectListOptionalList.Add(item);
                }
                ViewData["PlayerFourId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
            }
            else
            {
                ViewData["PlayerFourId"] = new SelectList(_context.Set<Member>().OrderBy(p => p.Name), "MembershipNumberId", "Name");
            }
            ViewData["PlayerOneId"] = new SelectList(_context.Set<Member>().OrderBy(p => p.Name), "MembershipNumberId", "Name");
            
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
            Booking.PlayerOne = _context.Member.FirstOrDefault(x => x.MembershipNumberId == Booking.PlayerOneId);
            Booking.PlayerOneId = Booking.PlayerOneId;
            Booking.PlayerTwo = null;
            Booking.PlayerTwoId = null;
            Booking.PlayerThreeId = null;
            Booking.PlayerThree = null;
            Booking.PlayerFour = null;
            Booking.PlayerFourId = null;
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
