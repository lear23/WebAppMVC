using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController(UserService userService) : Controller
    {
        private readonly UserService _userService = userService;



        [Route("/signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();

            return View(viewModel);
        }

        
        [Route("/signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)
                    return RedirectToAction("SignIn", "Auth");
            }
            return View(viewModel);          

           
        }


        [Route("/signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var viewModel = new SignInViewModel();

            return View(viewModel);
        }

        [Route("/signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCodes.OK)
                    return RedirectToAction("Details", "Account");           
               
            }

            viewModel.ErrorMessage = "Incorrect email or password";
            return View(viewModel);
            
        }
    }
}


//var result = _authService.SignIn(viewModel.Form);  
// if (result)
// {
//     return RedirectToAction("Account", "Details");
// }


//------------

//return RedirectToAction("Account", "Index");
