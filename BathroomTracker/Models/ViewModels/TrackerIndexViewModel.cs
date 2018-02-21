using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BathroomTracker.Models;

namespace BathroomTracker.Models.ViewModels
{
    public class TrackerIndexViewModel
    {
        public Tracker Tracker { get; set; }
        public string ReturnUrl { get; set; }
    }
}
