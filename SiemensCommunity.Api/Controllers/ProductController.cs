using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Domain.Contracts;

namespace SiemensCommunity.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository bookRepository)
        {
            _productRepository = bookRepository;
        }

        public IActionResult ProductsList()
        {
            return View(_productRepository.AllProducts);
        }
    }
}
