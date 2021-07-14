using MangoServices.ProductAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoServices.ProductAPI.IRepository
{
    public interface IProductRepository
    {

        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductByID(Int32 Id);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(Int32 Id);
    }
}
