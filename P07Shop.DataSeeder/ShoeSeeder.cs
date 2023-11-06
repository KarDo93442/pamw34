using Bogus;
using P06Shop.Shared.Shop;

namespace P07Shop.DataSeeder
{
    public class ShoeSeeder
    {
        public static List<Shoe> GenerateProductData()
        {
            int productId = 1;
            string[] genders = new string[] { "male", "female" };
            string[] shoeTypes = new string[] { "sneakers", "loafers", "high heels", "sandals", "boots", "dress shoes" };

            var productFaker = new Faker<Shoe>()
                .RuleFor(x=>x.Name, x=>x.Commerce.ProductName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x=>x.Id, x=> productId++)
                .RuleFor(x=>x.Gender, x=>x.PickRandom(genders))
                .RuleFor(x=>x.Type, x=>x.PickRandom(shoeTypes))
                .RuleFor(x=>x.ShoeSize, x=>x.Random.Int(35,45));

            return productFaker.Generate(10).ToList();

        }
    }
}