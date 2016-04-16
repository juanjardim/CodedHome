using System.Data.Entity;
using CodedHome.Model;

namespace CodeHome.Data.Configuration
{
    public class CustomerDatabaseInitializer : 
        CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var descriptions = new[]
            {
                "Nice neigborhood with friendly neighbors.",
                "A truly beautiful home!",
                "In a cul-de-dac on a quiet street",
                "Freeway accessible with a huge green lawn",
                "Lots of storage and big bedrooms",
                "Well-kept by previous owners",
                "Includes pool, spa and baskeball hoop",
                "The back fenc needs some work, but the house is in great conditions",
                "Includes a huge bonus room great for an office or playroom",
                "Close to local magne schools"
            };
            var count = 10;
            while ((count--) != 0)
            {
                var bedrooms = ((count%2) == 1) ? 4 : 3;
                var imageNumber = ((count % 2) == 1) ? 1 : 2;
                var home = new Home
                {
                    StreetAddress = $"12{count} Street St.",
                    City = "Anytown",
                    ZipCode = 9037,
                    Bedrooms = bedrooms,
                    Bathrooms = (bedrooms -2),
                    SquareFeet = 3700 + count,
                    Price = 27500 + (count * 1000),
                    ImageName = $"home-{imageNumber}.jpg",
                    Description = descriptions[count]
                };

                context.Homes.Add(home);

            }
            //base.Seed(context);
        }
    }
}
