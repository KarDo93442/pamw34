using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.ProductService
{
    public class ShoeService : IShoeService
    {
        public async Task<ServiceResponse<List<Shoe>>> GetProductsAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Shoe>>()
                {
                    Data = ShoeSeeder.GenerateProductData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new  ServiceResponse<List<Shoe>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
           
        }
    }
}
