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
            var originalBooking = _context.Booking.AsNoTracking().FirstOrDefault(b => b.BookingId == Booking.BookingId);
            
            var bookingsForGivenDay = _context.Booking.AsNoTracking().Where(b => b.TeeTime.Date == Booking.TeeTime.Date);
            bool invalidBookingPlayerOne = false;
            bool invalidBookingPlayerTwo = false;
            bool invalidBookingPlayerThree = false;
            bool invalidBookingPlayerFour = false;
            foreach (var booking in bookingsForGivenDay)
            {
                if (originalBooking.PlayerOneId != Booking.PlayerOneId)
                {
                    if (Booking.PlayerOneId == booking.PlayerOneId)
                    {
                        invalidBookingPlayerOne = true;
                    }
                    if (Booking.PlayerOneId == booking.PlayerTwoId)
                    {
                        invalidBookingPlayerOne = true;
                    }
                    if (Booking.PlayerOneId == booking.PlayerThreeId)
                    {
                        invalidBookingPlayerOne = true;
                    }
                    if (Booking.PlayerOneId == booking.PlayerFourId)
                    {
                        invalidBookingPlayerOne = true;
                    }
                }
                if (originalBooking.PlayerTwoId != Booking.PlayerTwoId && Booking.PlayerTwoId != 0) { 
                    if (Booking.PlayerTwoId == booking.PlayerOneId)
                    {
                        invalidBookingPlayerTwo = true;
                    }
                    if (Booking.PlayerTwoId == booking.PlayerTwoId)
                    {
                        invalidBookingPlayerTwo = true;
                    }
                    if (Booking.PlayerTwoId == booking.PlayerThreeId)
                    {
                        invalidBookingPlayerTwo = true;
                    }
                    if (Booking.PlayerTwoId == booking.PlayerFourId)
                    {
                        invalidBookingPlayerTwo = true;
                    }
                }
                if (originalBooking.PlayerThreeId != Booking.PlayerThreeId && Booking.PlayerThreeId != 0)
                { 
                    if (Booking.PlayerThreeId == booking.PlayerOneId)
                    {
                        invalidBookingPlayerThree = true;
                    }
                    if (Booking.PlayerThreeId == booking.PlayerTwoId)
                    {
                        invalidBookingPlayerThree = true;
                    }
                    if (Booking.PlayerThreeId == booking.PlayerThreeId)
                    {
                        invalidBookingPlayerThree = true;
                    }
                    if (Booking.PlayerThreeId == booking.PlayerFourId)
                    {
                        invalidBookingPlayerThree = true;
                    }
                }
                if (originalBooking.PlayerFourId != Booking.PlayerFourId && Booking.PlayerFourId != 0)
                    {
                    if (Booking.PlayerFourId == booking.PlayerOneId)
                    {
                        invalidBookingPlayerFour = true;
                    }
                    if (Booking.PlayerFourId == booking.PlayerTwoId)
                    {
                        invalidBookingPlayerFour = true;
                    }
                    if (Booking.PlayerFourId == booking.PlayerThreeId)
                    {
                        invalidBookingPlayerFour = true;
                    }
                    if (Booking.PlayerThreeId == booking.PlayerFourId)
                    {
                        invalidBookingPlayerFour = true;
                    }
                }
            }
            _context.Attach(Booking).State = EntityState.Modified;
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
            if (invalidBookingPlayerOne)
            {
                ViewData["ErrorMessage"] += " Player Name: " + Booking.PlayerOne.Name + " already has a booking for that day";
            }
            if (invalidBookingPlayerTwo)
            {
                ViewData["ErrorMessage"] += " Player Name: " + Booking.PlayerTwo.Name + " already has a booking for that day";
            }
            if (invalidBookingPlayerThree)
            {
                ViewData["ErrorMessage"] += " Player Name: " + Booking.PlayerThree.Name + " already has a booking for that day";
            }
            if (invalidBookingPlayerFour)
            {
                ViewData["ErrorMessage"] += " Player Name: " + Booking.PlayerFour.Name + " already has a booking for that day";
            }

            if (invalidBookingPlayerOne || invalidBookingPlayerTwo || invalidBookingPlayerThree || invalidBookingPlayerFour)
            {
                ViewData["PlayerOneId"] = new SelectList(_context.Set<Member>(), "MembershipNumberId", "Name");
                var emptyMember = new Member { MembershipNumberId = 0, Name = "Optional" };

                var selectListOptionalList = new List<Member>
                {
                    emptyMember
                };
                foreach (var item in _context.Set<Member>())
                {
                    selectListOptionalList.Add(item);
                }
                ViewData["PlayerTwoId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
                ViewData["PlayerThreeId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
                ViewData["PlayerFourId"] = new SelectList(selectListOptionalList, "MembershipNumberId", "Name");
                return Page();
            }
            if (Booking.PlayerTwoId == 0)
            {
                Booking.PlayerTwo = null;
                Booking.PlayerTwoId = null;
            }
            if (Booking.PlayerThreeId == 0)
            {
                Booking.PlayerThree = null;
                Booking.PlayerThreeId = null;
            }
            if (Booking.PlayerFourId == 0)
            {
                Booking.PlayerFour = null;
                Booking.PlayerFourId = null;
            }
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
