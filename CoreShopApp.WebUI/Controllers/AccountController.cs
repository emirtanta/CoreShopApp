using CoreShopApp.WebUI.EMailService;
using CoreShopApp.WebUI.Extensions;
using CoreShopApp.WebUI.Identity;
using CoreShopApp.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Controllers
{
    //[AutoValidateAntiforgeryToken] //bütün post actionlarında validate işlemi yerine getirilir
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;//cookie işlemleri için tanımladık
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        #region Login Bölgesi

        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {
                ReturnUrl=ReturnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous] //herhangi bir yetkiye sahip olmayan kullanıcılar login sayfasını görüntüleyebilir
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //kullanıcı adı ile giriş yapmak için tanımlandı
            //var user = await _userManager.FindByNameAsync(model.Username);

            //email ile giriş yapmak için tanımlandı
            var user = await _userManager.FindByEmailAsync(model.EMail);

            if (user==null)
            {
                ModelState.AddModelError("", "Kullanıcı adı ile daha önce hesap oluşturulmamış");

                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen mail hesabınıza gelen link ile hesabınızı onaylayınız");

                return View(model);
            }

            //birinci false ifadesinde cookie'yi pasif yapar
            //2. false ifadesinde ise yanlış giriş sayısını pasif yapar
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                //return RedirectToAction("Index", "Home");

                return Redirect(model.ReturnUrl ?? "~/Home/Index");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya parola yanlış");

            return View(model);
        }

        #endregion

        #region Register Bölgesi

        [AllowAnonymous] //herhangi bir yetkiye sahip olmayan kullanıcılar bu sayfayı görebilirler
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName=model.UserName,
                Email=model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //kullanıcı kayıt olduktan sonra varsayılan olarak rol değeri aşağıdaki gib verilir
                //await _userManager.AddToRoleAsync(user, "Customer");

                //generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);//token oluşturuldu

                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId=user.Id,
                    token=code
                });

                //email gönderme (https ya da http olarak güncelleyin)
                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız", $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:44314{url}'>tıklayınız</a>");

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oldu.Lütfen tekrar deneyiniz");

            return View(model);
        }

        #endregion

        #region Logout Bölgesi

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new AlertMessage()

            {
                Title = "Oturum kapatıldı",
                Message = "Hesabınızdan çıkış yaptınız",
                AlertType = "warning"
            });

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Email Onaylama Bölgesi

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId==null || token==null)
            {
                TempData.Put("message", new AlertMessage()

                {
                    Title = "Geçersiz token",
                    Message = "Geçersiz token",
                    AlertType = "danger"
                });

                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user!=null)
            {
                //email aktifleştirildi
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()

                    {
                        Title = "Hesabınız onaylandı",
                        Message = "Hesabınız onaylandı",
                        AlertType = "success"
                    });

                    return View();
                }
            }

            TempData.Put("message", new AlertMessage()

            {
                Title = "Hesabınız onaylanmadı",
                Message = "Hesabınız onaylanmadı",
                AlertType = "warning"
            });

            return View();
        }

        #endregion

        #region Şifremi Unuttum Bölgesi

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user==null)
            {
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId=user.Id,
                token=code
            });

            //email gönderme işlemi (https ya da http olarak güncelleyin)
            await _emailSender.SendEmailAsync(Email, "Reset Password", $"linke tıklayın <a href='https://localhost:44314{url}'>tıklayınız</a>");

            return View();
        }

        #endregion

        #region Şifre Sıfırlama Bölgesi

        public IActionResult ResetPassword(string userId,string token)
        {
            //token ve user kontrolü
            if (userId==null || token==null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordModel()
            {
                Token=token
            };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user==null)
            {
                return RedirectToAction("Index", "Home");
            }

            //resetleme işlemi
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
