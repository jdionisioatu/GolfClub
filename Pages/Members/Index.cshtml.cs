using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;
using Microsoft.Build.Framework;

namespace GolfClub.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly GolfClub.Data.GolfClubContext _context;

        private const string ReverseSortKey = "false";

        private const string WhatToViewKey = "all";

        public string ReverseSort
        {
            get => HttpContext.Session.GetString(ReverseSortKey);
            set => HttpContext.Session.SetString(ReverseSortKey, value);
        }

        public string WhatToView
        {
            get => HttpContext.Session.GetString(WhatToViewKey);
            set => HttpContext.Session.SetString(WhatToViewKey, value);
        }

        public IndexModel(GolfClub.Data.GolfClubContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetReverseSortingOrder()
        {
            if (ReverseSort == "true")
            {
                ReverseSort = "false";
            } else
            {
                ReverseSort = "true";
            }

            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewAllMembers()
        {
            WhatToView = "all";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewMaleOnly()
        {
            WhatToView = "male";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewFemaleOnly()
        {
            WhatToView = "female";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewOtherOnly()
        {
            WhatToView = "other";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewHandiCapBellowEqualsTen()
        {
            WhatToView = "handicapbellowequalsten";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }

        public async Task OnGetViewHandiCapBellowBetweenElevenAndTwenty()
        {
            WhatToView = "handicapbetweenelevenandtwenty";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
        public async Task OnGetViewHandiCapAboveTwenty()
        {
            WhatToView = "handicapabovetewnty";
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
    }
}
