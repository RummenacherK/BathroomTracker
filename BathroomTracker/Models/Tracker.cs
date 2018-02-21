using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BathroomTracker.Models
{
    public class Tracker
    {
        private List<TrackerLine> lineCollection = new List<TrackerLine>();

        public virtual void AddStudent(Student student, int quantity) {
            TrackerLine line = lineCollection
                .Where(s => s.Student.StudentID == student.StudentID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new TrackerLine
                {
                    Student = student,
                    Quantity = quantity
                });
            } else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Student student) =>
            lineCollection.RemoveAll(l => l.Student.StudentID == student.StudentID);

        public virtual int ComputeTotalValue() =>
            lineCollection.Sum(e => e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<TrackerLine> Lines => lineCollection;
    }

    public class TrackerLine
    {
        public int TrackerLineID { get; set; }
        public Student Student { get; set; }
        public int Quantity { get; set; }
    }
}
