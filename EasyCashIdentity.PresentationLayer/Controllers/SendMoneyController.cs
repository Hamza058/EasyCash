using EashCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string currency)
        {
            ViewBag.currency = currency;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoney)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var receiverAccountNummberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoney.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var senderAccountNummberID = context.CustomerAccounts.Where(x => x.AppUserID == user.Id && x.CustomerAccountCurrency == "Türk Lirası").Select(y => y.CustomerAccountID).FirstOrDefault();

            //sendMoney.SenderID = user.Id;
            //sendMoney.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoney.ProcessType = "Havale";
            //sendMoney.ReceiverID = receiverAccountNummberID;

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.ProcessType = "Havale";
            values.SenderID = senderAccountNummberID;
            values.ReceiverID = receiverAccountNummberID;
            values.Amount = sendMoney.Amount;
            values.Description = sendMoney.Description;

            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }
    }
}
