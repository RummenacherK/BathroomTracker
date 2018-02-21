using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using BathroomTracker.Infrastructure;

namespace BathroomTracker.Models
{
    public class SessionTracker : Tracker
    {
        public static Tracker GetTracker(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionTracker tracker = session?.GetJson<SessionTracker>("Tracker")
                ?? new SessionTracker();
            return tracker;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddStudent(Student student, int quantity)
        {
            base.AddStudent(student, quantity);
            Session.SetJson("Tracker", this);
        }

        public override void RemoveLine(Student student)
        {
            base.RemoveLine(student);
            Session.SetJson("Tracker", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Tracker");
        }
    }
}
