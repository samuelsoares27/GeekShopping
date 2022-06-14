using AutoMapper;
using GeekShopping.ProductApi.Context;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MYSQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MYSQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product products = _mapper.Map<Product>(vo);
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(products);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var products = await _context.Products.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if(products == null) return false;

                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
                return true;    

            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var products = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(products);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product products = _mapper.Map<Product>(vo);
            _context.Products.Update(products);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(products);
        }
    }
}
