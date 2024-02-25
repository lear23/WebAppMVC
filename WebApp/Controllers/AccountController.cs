using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        //private readonly AccountController _accountService;

        //public AccountController(AccountController accountService)
        //{
        //    _accountService = accountService;
        //}

        [Route("/account")]
        public IActionResult Details()
        {
            var viewModel = new AccountDetailsViewModel();

            //viewModel.BasicInfoModel = _accountService.GetBasicInfoModel();
            //viewModel.AddressModel = _accountService.GetAddressModel();

            return View(viewModel);
        }

        
        [HttpPost]
        public IActionResult BasicInfoModel(AccountDetailsViewModel viewModel)
        {
            //_accountService.SaveBasicInfoModel(viewModel.BasicInfoModel);
           
            return RedirectToAction(nameof(Details), viewModel);
        } 
        
        [HttpPost]
        public IActionResult AddressModel(AccountDetailsViewModel viewModel)
        {
            //_accountService.SaveAddressModel(viewModel.AddressModel);
            return RedirectToAction(nameof(Details), viewModel);
        }
    }
}
