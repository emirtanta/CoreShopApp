#pragma checksum "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Shared\_ResultMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc2bd4662a6443c917972899b548fe769ad6be3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ResultMessage), @"mvc.1.0.view", @"/Views/Shared/_ResultMessage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using CoreShopApp.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using CoreShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using CoreShopApp.WebUI.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\_ViewImports.cshtml"
using CoreShopApp.WebUI.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc2bd4662a6443c917972899b548fe769ad6be3e", @"/Views/Shared/_ResultMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7d42abdb88e967fc494220d8b8706bd3dd0cb16", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ResultMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreShopApp.WebUI.Models.AlertMessage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 110, "\"", 146, 3);
            WriteAttributeValue("", 118, "alert", 118, 5, true);
            WriteAttributeValue(" ", 123, "alert-", 124, 7, true);
#nullable restore
#line 6 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Shared\_ResultMessage.cshtml"
WriteAttributeValue("", 130, Model.AlertType, 130, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <h4 class=\"alert-title\">\r\n                ");
#nullable restore
#line 8 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Shared\_ResultMessage.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h4>\r\n\r\n            <p>");
#nullable restore
#line 11 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Shared\_ResultMessage.cshtml"
          Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreShopApp.WebUI.Models.AlertMessage> Html { get; private set; }
    }
}
#pragma warning restore 1591
