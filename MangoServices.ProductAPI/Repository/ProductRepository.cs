using AutoMapper;
using MangoServices.ProductAPI.DbContexts;
using MangoServices.ProductAPI.DTO;
using MangoServices.ProductAPI.IRepository;
using MangoServices.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoServices.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async  Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if(product.ProductID>0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
           await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async  Task<bool> DeleteProduct(int ID)
        {
            try
            {
                Product product = await  _db.Products.FirstOrDefaultAsync(x=>x.ProductID== ID);
                if(product==null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public async  Task<ProductDto> GetProductByID(int Id)
        {
            Product product= await _db.Products.Where(x => x.ProductID == Id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {

            IEnumerable <Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
           
        }
    }
}
