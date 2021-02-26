using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShopApp.WebUI.EMailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
