using EashCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index(int id)
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel, string mail)
        {
			var value = mail;
            var user = await _userManager.FindByEmailAsync(value.ToString());
            if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
