using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;



namespace Toplearn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {

        private IUserService _userService;

        public WalletController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);

            return View();
        }


        [Route("UserPanel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel wallet)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);
                return View(wallet);
            }

            _userService.ChargeWallet(User.Identity.Name, wallet.Amount, "شارژ حساب");

            #region Online Payment


            //var payment = new ZarinpalSandbox.Payment(charge.Amount);

            //var res = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44349/OnlinePayment/" + walletId, "Info@topLearn.Com", "09197070750");

            //if (res.Result.Status == 100)
            //{
            //    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            //}


            #endregion

            return null;
        }

    }
}
