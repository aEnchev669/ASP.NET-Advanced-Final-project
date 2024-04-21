using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.User;
using TheReader.Core.Models.Account;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Extensions;
using TheReader.Core.Models.User;

namespace Bookshop___The_Reader.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                if (user.IsDeleted)
                {
                    ModelState.AddModelError(string.Empty, "This account doesn't exist");
                    return View(loginModel);
                }

                var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: true);
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "The account is locked. Too many attempts! Try again later");
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("All", "Book");
                }
            }

            TempData[ErrorMessage] = "Incorect Email or Password! Please  try again.";
            return View(loginModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var user = await userManager.FindByEmailAsync(registerModel.Email);
            if (user != null)
            {
                TempData[ErrorMessage] = "This email is already registered!";

                return View(registerModel);
            }

            var username = await userManager.FindByNameAsync(registerModel.Username);
            if (username != null)
            {
                TempData[ErrorMessage] = "This Username is already registered!";

                return View(registerModel);
            }

            user = new ApplicationUser();

            await userManager.SetEmailAsync(user, registerModel.Email);
            await userManager.SetUserNameAsync(user, registerModel.Username);

            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(registerModel);
            }

            await userManager.AddToRoleAsync(user, "User");
            await signInManager.SignInAsync(user, false);

            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.GetId();

            try
            {
                var editUserModel = await userService.GetUserByIdAsync(userId!);
                return View(editUserModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel userModel)
        {
            var users = await userService.GetAllUsersExceptCurrOneAsync(userModel.Id);

            if (users.Any(u => u.Email == userModel.Email))
            {
                ModelState.AddModelError("Email", "This email address is already used");
            }
            if (userModel.UserName != null && users.Any(u => u.UserName!.ToLower() == userModel.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "This Username is already used");
            }

            var userId = User.GetId();
            var user = await userService.GetUserByIdAsync(userId!);

            if (!ModelState.IsValid)
            {
                userModel.UserName = user.UserName;
                userModel.Email = user.Email;

                return View(userModel);
            }

            try
            {
                await userService.EditProfileAsync(userId!, userModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited your profile successfully.";
            return RedirectToAction("Details", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            var userId = User.GetId();

            try
            {
                await userService.SoftDeleteUserAsync(userId!);

                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Confirm Password doesn't match!");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound();
                }

                var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                await signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userId = User.GetId();
            try
            {
                var currUser = await userService.GetUserByIdAsync(userId!);
                return View(currUser);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            var previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
