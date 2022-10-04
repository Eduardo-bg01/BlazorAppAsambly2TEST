using BlazorAppAsambly2TEST.Client.Shared;
using EjemploAssemblyAppNet.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppAsambly2TEST.Server.Controllers
{

    [ApiController]
    [Route("/Api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private ProductServices service;

        public ProductController()
        {
            service = new ProductServices();
        }

        [HttpGet]
        public async Task<List<Product>> get()
        {
            return await service.GetProductAsync();
        }

        [HttpGet("{id}")]

        public async Task<Product>GetById(int id)
        {
            Product p = new Product();
            p.Id = id;
            return await service.GetProductAsync(p);
        }
    }
}
