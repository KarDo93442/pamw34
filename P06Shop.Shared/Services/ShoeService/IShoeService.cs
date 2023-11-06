using P06Shop.Shared;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.ProductService
{
    public interface IShoeService
    {
        Task<ServiceResponse<List<Shoe>>> GetProductsAsync();
    }
}
