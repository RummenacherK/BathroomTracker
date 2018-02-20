using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BathroomTracker.Models;
using BathroomTracker.Models.ViewModels;


namespace BathroomTracker.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository repository;
        public int PageSize = 4;

        public StudentController(IStudentRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int studentPage = 1)
            => View(new StudentsListViewModel
            {
                Students = repository.Students
                   .OrderBy(s => s.StudentID)
                   .Skip((studentPage - 1) * PageSize)
                   .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = studentPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Students.Count()
                }
            });
    }  
}
