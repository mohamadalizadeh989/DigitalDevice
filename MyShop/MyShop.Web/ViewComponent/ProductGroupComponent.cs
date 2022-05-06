using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Services;

namespace MyShop.Web.ViewComponent
{
    public class ProductGroupComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IProductService _productService;

        public ProductGroupComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ProductGroup", _productService.GetAllGroup()));
        }
    }
}
