using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyShop.Core.Services;
using MyShop.Core.ViewModels.Wallet;

namespace MyShop.Web.Areas.UserPanel.Controllers
{
    public class WalletController : UserPanelController
    {
        private readonly IAccountService _accountService;

        public WalletController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            if (User.Identity != null)
                ViewBag.ListWallet = _accountService.GetWalletUser(User.Identity.Name);

            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public async Task<IActionResult> IndexAsync(ChargeWalletViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                if (User.Identity != null)
                    ViewBag.ListWallet = _accountService.GetWalletUser(User.Identity.Name);
                return View(charge);
            }

            if (User.Identity != null)
            {
                int walletId = await _accountService.ChargeWalletAsync(User.Identity.Name, charge.Amount, "شارژ حساب");

                #region Online Payment

                var payment = new ZarinpalSandbox.Payment(charge.Amount);
                var response = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44351/OnlinePayment/" + walletId);

                if (response.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
                }

                #endregion
            }


            return null;
        }
    }
}
