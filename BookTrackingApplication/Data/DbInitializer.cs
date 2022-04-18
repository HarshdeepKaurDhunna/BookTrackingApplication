using BookTrackingApplication.Models;
using System.Linq;

namespace BookTrackingApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookTrackingApplicationContext context)
        {
            context.Database.EnsureCreated();

            var Categories = new Category[]
            {
                new Category{Type="Fict",Name="Fiction"},
                new Category{Type="NFict",Name="Non-Fiction"},

            };
            foreach (Category c in Categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            // Look for any CategoryTypies.
            if (context.CategoryTypies.Any())
            {
                return;   // DB has been seeded
            }

            var CategoryTypies = new CategoryType[]
            {
                new CategoryType{NameToken="RF",Type="Fict",Description="Romance Fiction"},
                new CategoryType{NameToken="AAF",Type="Fict",Description="Action-Adventure Fiction"},
                new CategoryType{NameToken="SF",Type="Fict",Description="Science Fiction"},
                new CategoryType{NameToken="FF",Type="Fict",Description="Fantasy Fiction"},
                new CategoryType{NameToken="SPF",Type="Fict",Description="Suspense Fiction"},
                new CategoryType{NameToken="TF",Type="Fict",Description="Thriller Fiction"},
                new CategoryType{NameToken="HF",Type="Fict",Description="Horror Fiction"},
                new CategoryType{NameToken="HISF",Type="Fict",Description="History Fiction"},
                new CategoryType{NameToken="BANF",Type="NFict",Description="Biographies and Autobiographies"},
                new CategoryType{NameToken="MNF",Type="NFict",Description="Memoirs"},
                new CategoryType{NameToken="TWNF",Type="NFict",Description="Travel Writing"},
                new CategoryType{NameToken="PNF",Type="NFict",Description="Philosophy"},
                new CategoryType{NameToken="RSNF",Type="NFict",Description="Religion and Spirituality"},
                new CategoryType{NameToken="SHNF",Type="NFict",Description="Self-Help"},
                new CategoryType{NameToken="SNF",Type="NFict",Description="Science"},
                new CategoryType{NameToken="MEDNF",Type="NFict",Description="Medical"},
                new CategoryType{NameToken="PSYNF",Type="NFict",Description="Psychology"},
                new CategoryType{NameToken="ARTNF",Type="NFict",Description="Art"},


            };
            foreach (CategoryType ct in CategoryTypies)
            {
                context.CategoryTypies.Add(ct);
            }
            context.SaveChanges();

            var Books = new Book[]
            {
                new Book{ISBN="8765",Title="The Other Planet",Author="Carson",NameToken="RF"},
                new Book{ISBN="8764",Title="Harry Potter",Author="Alexander",NameToken="FF"},
                new Book{ISBN="8763",Title="A Play",Author="Peter Sheffer",NameToken="BANF"},
                new Book{ISBN="8762",Title="Applied Numeric Analysis",Author="Curtis F Gerald",NameToken="SNF"},

            };
            foreach (Book b in Books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
        }
    }
}
