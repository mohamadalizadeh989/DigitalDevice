using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Generator;
using MyShop.Core.ViewModels.Products;
using MyShop.DataEf.Contexts;
using MyShop.Domain.Entities.Products;

namespace MyShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly MyShopContext _context;

        public ProductService(MyShopContext context)
        {
            _context = context;
        }

        public List<ProductGroup> GetAllGroup()
        {
            return _context.ProductGroups.ToList();
        }

        public List<SelectListItem> GetGroupForManageProduct()
        {
            return _context.ProductGroups.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageProduct(int groupId)
        {
            return _context.ProductGroups.Where(g => g.ParentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetLevels()
        {
            return _context.ProductLevels.Select(l => new SelectListItem()
            {
                Value = l.LevelId.ToString(),
                Text = l.LevelTitle
            }).ToList();
        }

        public List<SelectListItem> GetStatuses()
        {
            return _context.ProductStatuses.Select(l => new SelectListItem()
            {
                Value = l.StatusId.ToString(),
                Text = l.StatusTitle
            }).ToList();
        }

        //public List<ShowProductForAdminVm> GetProductForAdmin()
        //{
        //    return _context.Products.Select(p => new ShowProductForAdminVm()
        //    {
        //        ProductId = p.ProductId,
        //        ImageName = p.ProductImageName,
        //        Title = p.ProductTitle
        //    }).ToList();
        //}

        public List<Product> GetProductForAdmin()
        {
            return _context.Products.ToList();
        }

        public async Task<int> AddProductAsync(Product product, IFormFile imgProduct, IFormFile productDemo)
        {
            product.CreateDate=DateTime.Now;
            product.ProductImageName = "No-Image.png";

            //TODO Check Image

            if (imgProduct != null)
            {
                product.ProductImageName= NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProduct.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/image", product.ProductImageName);
                await using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imgProduct.CopyToAsync(stream);
                }
            }

            if (productDemo != null)
            {
                product.DemoFileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(productDemo.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/demoes", product.DemoFileName);
                await using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    await productDemo.CopyToAsync(stream);
                }
            }

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
