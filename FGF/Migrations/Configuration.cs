namespace FGF.Migrations
{
    using FGF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FGF.DAL.OrgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FGF.DAL.OrgContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Diana",   LastName = "Algomeda",
                    RegistrationDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Kristi", LastName = "Mae",
                    RegistrationDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Hanan",   LastName = "Gumale",
                    RegistrationDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Louise",    LastName = "Parafina",
                    RegistrationDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Kendy",      LastName = "Trinh",
                    RegistrationDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Hannah",    LastName = "Noceda",
                    RegistrationDate = DateTime.Parse("2011-09-01") }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var courses = new List<Event>
            {
                new Event {EventID = 1050, Title = "Swipe Right for Success",      NumofEvents = 3, },
                new Event {EventID = 4022, Title = "De-stress Fest", NumofEvents = 3, },
                new Event {EventID = 4041, Title = "Project F Word", NumofEvents = 3, },
                new Event {EventID = 1045, Title = "Fire Pit Forward",       NumofEvents = 4, },
                new Event {EventID = 3141, Title = "Paws for Break",   NumofEvents = 4, },
                new Event {EventID = 2021, Title = "CAP",    NumofEvents = 3, },
                new Event {EventID = 2042, Title = "Pie on the Face",     NumofEvents = 4, }
            };
            courses.ForEach(s => context.Event.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Register>
            {
                new Register {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    EventID = courses.Single(c => c.Title == "Chemistry" ).EventID,
                    Types = Types.Academic
                },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    EventID = courses.Single(c => c.Title == "Microeconomics" ).EventID,
                    Types = Types.Art
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    EventID = courses.Single(c => c.Title == "Macroeconomics" ).EventID,
                    Types = Types.Academic
                 },
                 new Register {
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    EventID = courses.Single(c => c.Title == "Calculus" ).EventID,
                    Types = Types.Music
                 },
                 new Register {
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    EventID = courses.Single(c => c.Title == "Trigonometry" ).EventID,
                    Types = Types.Entertainment
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    EventID = courses.Single(c => c.Title == "Composition" ).EventID,
                    Types = Types.Others
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    EventID = courses.Single(c => c.Title == "Chemistry" ).EventID
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    EventID = courses.Single(c => c.Title == "Microeconomics").EventID,
                    Types = Types.Music
                 },
                new Register {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
                    EventID = courses.Single(c => c.Title == "Chemistry").EventID,
                    Types = Types.Art
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Li").StudentID,
                    EventID = courses.Single(c => c.Title == "Composition").EventID,
                    Types = Types.Academic
                 },
                 new Register {
                    StudentID = students.Single(s => s.LastName == "Justice").StudentID,
                    EventID = courses.Single(c => c.Title == "Literature").EventID,
                    Types = Types.Music
                 }
            };

            foreach (Register e in enrollments)
            {
                var enrollmentInDataBase = context.Registers.Where(
                    s =>
                         s.Student.StudentID == e.StudentID &&
                         s.Event.EventID == e.EventID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Registers.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}