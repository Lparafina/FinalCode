using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FGF.Models;

namespace FGF.DAL
{
    public class OrgInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrgContext>
    {
        protected override void Seed(OrgContext context)
        {
            
                var students = new List<Student>
            {
                new Student{FirstName="Diana", LastName="Algomeda", RegistrationDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Kristi", LastName="Mae", RegistrationDate=DateTime.Parse("2005-09-03")},
                new Student{FirstName="Hanan", LastName="Gumale", RegistrationDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Louise", LastName="Parafina", RegistrationDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Kendy", LastName="Trinh", RegistrationDate=DateTime.Parse("2005-09-03")},
                new Student{FirstName="Hannah", LastName="Noceda", RegistrationDate=DateTime.Parse("2005-09-02")}
            };
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();

                var events = new List<Event>
            {
                new Event{EventID=1050, Title="Swipe Right for Success", NumofEvents=3 },
                new Event{EventID=1050, Title="De-stress Fest", NumofEvents=2 },
                new Event{EventID=1050, Title="Project F Word", NumofEvents=1 },
                new Event{EventID=1050, Title="Fire Pit Forward", NumofEvents=1 },
                new Event{EventID=1050, Title="Paws for Break", NumofEvents=3 },
                new Event{EventID=1050, Title="CAP", NumofEvents=2 }
            };
                events.ForEach(s => context.Event.Add(s));
                context.SaveChanges();

                var registers = new List<Register>
            {
                new Register{StudentID=1, EventID=1010, Types=Types.Academic},
                new Register{StudentID=2, EventID=1020, Types=Types.Art},
                new Register{StudentID=3, EventID=1030, Types=Types.Academic},
                new Register{StudentID=4, EventID=1040, Types=Types.Music},
                new Register{StudentID=5, EventID=1050, Types=Types.Entertainment},
                new Register{StudentID=6, EventID=1060, Types=Types.Others},
                new Register{StudentID=7, EventID=1070, Types=Types.Music},
                new Register{StudentID=8, EventID=1080, Types=Types.Art},
                new Register{StudentID=9, EventID=1090, Types=Types.Academic}
            };
                registers.ForEach(s => context.Registers.Add(s));
                context.SaveChanges();

            }

        }
    
}
