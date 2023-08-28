using AutoMapper;
using Data.Layer.Access;
using Data.Layer.Access.DTO;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericBase_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAutoMapperController : ControllerBase
    {
        private readonly DataAccess _context;
        private readonly IMapper _mapper;

        //public ProductAutoMapperController(DataAccess context)
        //{
        //    _context = context;
        //}

        public ProductAutoMapperController(IMapper mapper,DataAccess context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            await _context.Products.ToListAsync();
            var products = await _context.Products.ToListAsync();

            if (products != null)
            {
                var productDTOs = _mapper.Map<List<ProductDTO>>(products);
                return Ok(productDTOs);
            }
            else throw new Exception("products return a null");
        }

        [HttpGet("GetProductOne")]
        public async Task<IActionResult> GetProductOne(int id)
        {
            var product =await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(product);

        }
        
       // POST: api/products
       [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            var updproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            updproduct.ProductName = product.ProductName;
            updproduct.Category = product.Category;
            updproduct.StockQuantity = product.StockQuantity;
            updproduct.Price = product.Price;
            await _context.SaveChangesAsync();
            return Ok(updproduct);

        }

        [HttpDelete("DeleteProducts")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok("Product Deleted.");
            }
            else throw new Exception("id not found.");
            
        }


    }
}

#region AutoMapper Methods
/*

ReverseMap: Bir eşleme profili tanımlarken, 
ReverseMap yöntemini kullanarak ters eşleme kurallarını 
otomatik olarak oluşturabilirsiniz. Bu, DTO'dan orijinal 
modele geri dönüşü sağlar.

CreateMap<Product, ProductDTO>().ReverseMap();
  
ForMember: Eşleme sırasında belirli alanları özelleştirmek 
için ForMember yöntemini kullanabilirsiniz. Bu yöntem, kaynak 
ve hedef alanların adlarını, dönüşümlerini ve daha fazlasını 
özelleştirmenizi sağlar.

CreateMap<Product, ProductDTO>()
    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ProductCategory));


ConstructUsing: Belirli bir inşa yöntemi kullanarak hedef nesnesini oluşturmanız gereken durumlar için ConstructUsing yöntemini kullanabilirsiniz.

CreateMap<Source, Destination>()
    .ConstructUsing(src => new Destination(src.Value));

ConvertUsing: Özel dönüşümler için ConvertUsing yöntemini kullanabilirsiniz. Bu, belirli bir kaynaktan hedefe dönüşüm sağlamak için özel bir dönüşüm işlevi belirtmenizi sağlar. 
 CreateMap<string, DateTime>().ConvertUsing(s => DateTime.Parse(s));

 NullSubstitute: Kaynak nesne null olduğunda hedef nesnenin belirli bir değerle doldurulmasını sağlar.
 CreateMap<Product, ProductDTO>()
    .ForMember(dest => dest.Category, opt => opt.NullSubstitute("No Category"));

AfterMap: Eşleme tamamlandığında belirli bir işlemi gerçekleştirmek için AfterMap yöntemini kullanabilirsiniz.
CreateMap<Product, ProductDTO>()
    .AfterMap((src, dest) => dest.TotalPrice = src.Price * src.Quantity);

BeforeMap: Eşleme başlamadan önce belirli bir işlemi gerçekleştirmek için BeforeMap yöntemini kullanabilirsiniz.

CreateMap<ProductDTO, Product>()
    .BeforeMap((src, dest) => dest.CreatedAt = DateTime.Now);

MapFrom: Özel bir değeri veya dönüşümü belirli bir üyeden almak için MapFrom yöntemini kullanabilirsiniz.

CreateMap<Product, ProductDTO>()
    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Price * src.Quantity));

 */
#endregion