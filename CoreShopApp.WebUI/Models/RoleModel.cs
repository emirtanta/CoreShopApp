using CoreShopApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Models
{
    public class RoleModel
    {
        public string Name { get; set; }

    }

    public class RoleDetails
    {
        public IdentityRole Role { get; set; }

        //rol içerisindeki kullanıcılar
        public IEnumerable<User> Members { get; set; }

        //rolde olmayan kullanıcılar
        public IEnumerable<User> NonMembers { get; set; }
    }

    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        //role kullanıcı ekleme
        public string[] IdsToAdd { get; set; }

        //rol içerisinden kullanıcı çıkarma
        public string[] IdsToDelete { get; set; }
    }
}
