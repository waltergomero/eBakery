using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
    public class ProductManager: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<ProductDisplayModel[]> ProductDisplayList()
        {
            return await _productRepository.ProductDisplayList();
        }

        public async Task<ProductModel> ProductById(int ProductId)
        {
            return await _productRepository.ProductById(ProductId);

        }
 
    }
}
