using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.Models
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        //kullanıcı rollerini görmek için tanımlandı
        public IEnumerable<string> SelectedRoles { get; set; }

    }
}
