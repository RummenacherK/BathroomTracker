using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BathroomTracker.Infrastructure;
using BathroomTracker.Models;
using BathroomTracker.Models.ViewModels;

namespace BathroomTracker.Controllers
{
    public class TrackerController : Controller
    {
        private IStudentRepository repository;

        public TrackerController(IStudentRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new TrackerIndexViewModel
            {
                Tracker = GetTracker(),
                ReturnUrl = returnUrl
            });
        }

        //Adds Students to Tracker
        public RedirectToActionResult BathroomTrip(int studentID, string returnUrl)
        {
            Student student = repository.Students
                .FirstOrDefault(s => s.StudentID == studentID);

            if (student != null)
            {
                Tracker tracker = GetTracker();
                tracker.AddStudent(student, 1);
                SaveTracker(tracker);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //Removes Students from Tracker
        public RedirectToActionResult RemoveFromTracker(int studentId, string returnUrl)
        {
            Student student = repository.Students
                .FirstOrDefault(s => s.StudentID == studentId);

            if (student != null)
            {
                Tracker tracker = GetTracker();
                tracker.RemoveLine(student);
                SaveTracker(tracker);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Tracker GetTracker()
        {
            Tracker tracker = HttpContext.Session.GetJson<Tracker>("Tracker") ?? new Tracker();
            return tracker;
        }

        private void SaveTracker(Tracker tracker)
        {
            HttpContext.Session.SetJson("Tracker", tracker);
        }
    }
}
