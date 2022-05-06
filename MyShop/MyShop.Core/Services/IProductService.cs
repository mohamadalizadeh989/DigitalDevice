using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyShop.Core.ViewModels.Products;
using MyShop.Domain.Entities.Products;

namespace MyShop.Core.Services
{
    public interface IProductService
    {
        #region Group

        List<ProductGroup> GetAllGroup();
        List<SelectListItem> GetGroupForManageProduct();
        List<SelectListItem> GetSubGroupForManageProduct(int groupId);
        List<SelectListItem> GetLevels();
        List<SelectListItem> GetStatuses();

        #endregion

        #region MyRegion

        //List<ShowProductForAdminVm> GetProductForAdmin();
        List<Product> GetProductForAdmin();
        Task<int> AddProductAsync(Product product, IFormFile imgProduct, IFormFile productDemo);


        #endregion
    }
}
