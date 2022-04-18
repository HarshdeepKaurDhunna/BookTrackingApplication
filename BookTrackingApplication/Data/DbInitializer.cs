using BookTrackingApplication.Models;
using System.Linq;

namespace BookTrackingApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookTrackingApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.CategoryTypies.Any())
            {
                return;   // DB has been seeded
            }

            var CategoryTypies = new CategoryType[]
            {
                new CategoryType{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new CategoryType{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new CategoryType{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new CategoryType{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
           
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}
