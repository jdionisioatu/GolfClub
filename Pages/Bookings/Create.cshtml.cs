using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClub.Data;
using GolfClub.Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Booking == null || Booking == null)
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
            
            var bookingsForGivenDay = _context.Booking.Where(b => b.TeeTime.Date == Booking.TeeTime.Date);
            bool invalidBookingPlayerOne = false;
            bool invalidBookingPlayerTwo = false;
            bool invalidBookingPlayerThree = false;
            bool invalidBookingPlayerFour = false;
            foreach (var booking in bookingsForGivenDay)
            {
                if(Booking.PlayerOneId == booking.PlayerOneId)
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
                if(Booking.PlayerTwoId != 0)
                {
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
                if (Booking.PlayerThreeId != 0)
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
                if (Booking.PlayerFourId != 0)
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
            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
