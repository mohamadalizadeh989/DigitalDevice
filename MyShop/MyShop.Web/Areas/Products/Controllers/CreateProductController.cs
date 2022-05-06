using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;
using MyShop.Domain.Entities.Products;

namespace MyShop.Web.Areas.Products.Controllers
{
    public class CreateProductController : ProductController
    {
        private readonly IProductService _productService;

        public CreateProductController(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        // Can you Replace view model
        public Product Product { get; set; }
       
        public IActionResult Index()
        {
            var groups= _productService.GetGroupForManageProduct();
            ViewData["Groups"] = new SelectList(groups,"Value","Text");

            var subGroups = _productService.GetSubGroupForManageProduct(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");

            var levels = _productService.GetLevels();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text");

            var statuses = _productService.GetStatuses();
            ViewData["Statuses"] = new SelectList(statuses, "Value", "Text");

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(IFormFile imgProductUp, IFormFile demoUp)
        {
            if(!ModelState.IsValid)
                return View();

            await _productService.AddProductAsync(Product, imgProductUp, demoUp);
            return Redirect("/Admin/Products");
        }
    }
}
