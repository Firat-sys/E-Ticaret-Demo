//using ETicaretApplication.Abstraction;
using ETicaretApi_Domain.Entitys;
using ETicaretApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IOrderWriterRepository _OrderWriterRepository;
        readonly private ICustomerWriteRepository _CustomerWriterRepository;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ICustomerWriteRepository customerWriterRepository, IOrderWriterRepository orderWriterRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _CustomerWriterRepository = customerWriterRepository;
            _OrderWriterRepository = orderWriterRepository;
        }


        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            // {
            //     new(){ Id=Guid.NewGuid(), Name="product1", Price=100,CreateDate=DateTime.UtcNow,Stock=10},
            //     new(){ Id=Guid.NewGuid(), Name="product2", Price=103,CreateDate=DateTime.UtcNow,Stock=1},
            //     new(){ Id=Guid.NewGuid(), Name="product3", Price=104,CreateDate=DateTime.UtcNow,Stock=4},
            //     new(){ Id=Guid.NewGuid(), Name="product4", Price=105,CreateDate=DateTime.UtcNow,Stock=6},

            //     });
            //await _productWriteRepository.SaveAsync();
            //Product p = await _productReadRepository.GetByIdAsync("c9584585-f1a2-409c-8b06-d1c12a7f29cd",false);
            //p.Name = "Mehmet";
            //await _productWriteRepository.SaveAsync();
            //await _productWriteRepository.AddAsync(new() { Name = "C product", Price = 1.500F, Stock = 11, CreateDate = DateTime.UtcNow });
            // await _productWriteRepository.SaveAsync();
            var customerId=Guid.NewGuid();
            await _CustomerWriterRepository.AddAsync(new() { Name = "Muhittin", Id = customerId });


           await _OrderWriterRepository.AddAsync(new() { Description = "bla bla bla", Address = "Urfa Karaköprü",CustomerId=customerId });
            await _OrderWriterRepository.AddAsync(new() { Description = "bla2 bla bla", Address = "Urfa haliliye",CustomerId = customerId });
            await _OrderWriterRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            Product product=await _productReadRepository.GetByIdAsync( 
               id);
            return Ok(product);
        }
    }
}
