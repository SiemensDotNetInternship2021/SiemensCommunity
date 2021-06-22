using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Api.Adapters;
using SiemensCommunity.Api.Models.Entities;
using SiemensCommunity.Persistence.Contracts;

namespace SiemensCommunity.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductAdapter _productAdapter;
        

        public ProductController(IProductRepository bookRepository)
        {
            _productRepository = bookRepository;
            _productAdapter = new ProductAdapter();
        }

        public IActionResult ProductsList()
        {
            Services.Models.Entities.Product testProd = new Services.Models.Entities.Product();
            testProd.Name = "book1";
            testProd.Details = "something";

            Product mappedProduct = _productAdapter.AdaptProduct(testProd);

            return View(mappedProduct);
        }
    }
}
