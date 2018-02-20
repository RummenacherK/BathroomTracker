using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BathroomTracker.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Students.Any ())
            {
                context.Students.AddRange(
                    new Student
                    {
                        Name = "Adam Smith",
                        Gender = "Male",
                        GradeLevel = "6th Grade",
                        Advisor = "Mr K"
                    },
                    new Student
                    {
                        Name = "Beatrice LaStrange",
                        Gender = "Female",
                        GradeLevel = "7th Grade",
                        Advisor = "Mr K"
                    },
                    new Student
                    {
                        Name = "Curt Arbtin",
                        Gender = "Male",
                        GradeLevel = "8th Grade",
                        Advisor = "Ms Schrim"
                    },
                    new Student
                    {
                        Name = "Daniella Sforza",
                        Gender = "Female",
                        GradeLevel = "6th Grade",
                        Advisor = "Ms Schrim"
                    },
                    new Student
                    {
                        Name = "Evan Runyon",
                        Gender = "Male",
                        GradeLevel = "7th Grade",
                        Advisor = "Mr K"
                    },
                    new Student
                    {
                        Name = "Felicia Potranco",
                        Gender = "Female",
                        GradeLevel = "8th Grade",
                        Advisor = "Mr K"
                    },
                    new Student
                    {
                        Name = "Gerald Clark",
                        Gender = "Male",
                        GradeLevel = "6th Grade",
                        Advisor = "Ms Schrim"
                    },
                    new Student
                    {
                        Name = "Helga Pizarro",
                        Gender = "Female",
                        GradeLevel = "7th Grade",
                        Advisor = "Ms Schrim"
                    },
                    new Student
                    {
                        Name = "Ignacio Cortes",
                        Gender = "Male",
                        GradeLevel = "8th Grade",
                        Advisor = "Mr K"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
