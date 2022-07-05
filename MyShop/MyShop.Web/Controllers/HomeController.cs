using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services;

namespace MyShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;

        public HomeController(IAccountService accountService, IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("OnlinePayment/{Id}")]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _accountService.GetWalletByWalletId(id);

                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;
                
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPay = true;
                    _accountService.UpdateWallet(wallet);
                }

            }

            return View();
        }

        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "انتخاب کنید",
                    Value = ""
                }
            };
            list.AddRange(_productService.GetSubGroupForManageProduct(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
