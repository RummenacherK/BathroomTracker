using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BathroomTracker.Models;

namespace BathroomTracker.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStudentRepository repository;

        public NavigationMenuViewComponent(IStudentRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGradeLevel = RouteData?.Values["gradeLevel"];
            return View(repository.Students
                .Select(x => x.GradeLevel)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
