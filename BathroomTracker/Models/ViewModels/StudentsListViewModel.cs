using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BathroomTracker.Models;

namespace BathroomTracker.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGradeLevel { get; set; }
    }
}
