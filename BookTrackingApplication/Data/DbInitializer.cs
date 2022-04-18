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
                new Category{TypeCode="Fict",Name="Fiction"},
                new Category{TypeCode="NFict",Name="Non-Fiction"},

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
                new CategoryType{NameToken="RF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Romance Fiction"},
                new CategoryType{NameToken="AAF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Action-Adventure Fiction"},
                new CategoryType{NameToken="SF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Science Fiction"},
                new CategoryType{NameToken="FF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Fantasy Fiction"},
                new CategoryType{NameToken="SPF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Suspense Fiction"},
                new CategoryType{NameToken="TF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Thriller Fiction"},
                new CategoryType{NameToken="HF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="Horror Fiction"},
                new CategoryType{NameToken="HISF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "Fict").TypeCode,
                    Description="History Fiction"},
                new CategoryType{NameToken="BANF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Biographies and Autobiographies"},
                new CategoryType{NameToken="MNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Memoirs"},
                new CategoryType{NameToken="TWNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Travel Writing"},
                new CategoryType{NameToken="PNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Philosophy"},
                new CategoryType{NameToken="RSNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Religion and Spirituality"},
                new CategoryType{NameToken="SHNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Self-Help"},
                new CategoryType{NameToken="SNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Science"},
                new CategoryType{NameToken="MEDNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Medical"},
                new CategoryType{NameToken="PSYNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Psychology"},
                new CategoryType{NameToken="ARTNF",CategoryTypeCode=context.Categories.FirstOrDefault(x => x.TypeCode == "NFict").TypeCode,
                    Description="Art"},


            };
            foreach (CategoryType ct in CategoryTypies)
            {
                context.CategoryTypies.Add(ct);
            }
            context.SaveChanges();

            var Books = new Book[]
            {
              new Book{ISBN="8765",Title="The Other Planet",Author="Carson",CategoryTypeNameToken =context.CategoryTypies.FirstOrDefault(x => x.NameToken == "RF").NameToken},
              new Book{ISBN="8764",Title="Harry Potter", Author="Alexander",CategoryTypeNameToken=context.CategoryTypies.FirstOrDefault(x => x.NameToken == "FF").NameToken },
              new Book{ISBN="8763",Title="A Play",Author="Peter Sheffer",CategoryTypeNameToken=context.CategoryTypies.FirstOrDefault(x => x.NameToken == "BANF").NameToken},
              new Book{ISBN="8762",Title="Applied Numeric Analysis",Author="Curtis F Gerald",CategoryTypeNameToken=context.CategoryTypies.FirstOrDefault(x => x.NameToken == "SNF").NameToken},
            };
            foreach (Book b in Books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
        }
    }
}
