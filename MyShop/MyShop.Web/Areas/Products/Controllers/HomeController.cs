using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Products;
using MyShop.Core.ViewModels.Users;
using MyShop.Domain.Entities.Products;

namespace MyShop.Web.Areas.Products.Controllers
{
    public class HomeController : ProductController
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        //public List<ShowProductForAdminVm> ListProduct { get; set; }
        public List<Product> ListProduct { get; set; }

        [Route("Admin/Products")]
        public IActionResult Index()
        {
            ListProduct = _productService.GetProductForAdmin();
            ViewData["Products"] = ListProduct;
            return View(ListProduct);
        }
    }       
}
