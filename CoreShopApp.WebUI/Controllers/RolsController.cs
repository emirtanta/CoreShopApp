using CoreShopApp.WebUI.Identity;
using CoreShopApp.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Controllers
{
    //[Authorize(Roles ="Admin")] //Admin rolüne yetkili olan kullanıcılar rol controllera erişebilirler
    public class RolsController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public RolsController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region Roller Listesi Bölgesi

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }


        #endregion

        #region Rol Ekleme Bölgesi

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                //_roleManager aracılığıyla rol ekleme işlemi
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        #endregion

        #region Rol Düzenleme Bölgesi

        [HttpGet]
        public async Task<IActionResult> RolEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            //roldeki kullanıcıları getirdik
            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;

                list.Add(user);
            }

            var model = new RoleDetails()
            {
                Role=role,
                Members=members,
                NonMembers=nonmembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RolEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }

            return Redirect("/role/" + model.RoleId);
        }

        #endregion

        #region Kullanıcı Listesi Bölgesi

        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        #endregion

        #region Kullanıcı Bilgileri ve Kullanıcıya Rol Ekleme İşlemleri Bölgesi

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);

                //veritabanındaki bütün rolleri aldık
                var roles = _roleManager.Roles.Select(x => x.Name);

                ViewBag.Roles = roles;

                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }

            return Redirect("~/user/list");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model,string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user!=null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);

                        //null referans hatası almamak için tanımladık
                        selectedRoles = selectedRoles ?? new string[] { };

                        //kullanıcıları birden fazla role aktarabilmek için tanımladık
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());

                        return Redirect("/user/list");

                    }
                }

                return Redirect("/user/list");
            }

            return View(model);
        }


        #endregion
    }
}
