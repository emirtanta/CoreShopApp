#pragma checksum "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbddc6dae3d10177c23e5744d3237114f0088c30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rols_RoleList), @"mvc.1.0.view", @"/Views/Rols/RoleList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbddc6dae3d10177c23e5744d3237114f0088c30", @"/Views/Rols/RoleList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7d42abdb88e967fc494220d8b8706bd3dd0cb16", @"/Views/_ViewImports.cshtml")]
    public class Views_Rols_RoleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Rols/RolDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
  
    ViewData["Title"] = "Roller Listesi";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center\">");
#nullable restore
#line 6 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                   Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div class=""row"">
    <div class=""col-md-12"">
        <hr>
        <a href=""/Rols/RoleCreate"" class=""btn btn-primary btn-sm"">Rol Ekle</a>
        
        <p></p>

        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <td style=""width: 250px;"">Id</td>
                    <td>Rol Adı</td>
                    <td style=""width: 160px;""></td>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 25 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                 if (Model.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 937, "\"", 958, 2);
            WriteAttributeValue("", 944, "/role/", 944, 6, true);
#nullable restore
#line 34 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
WriteAttributeValue("", 950, item.Id, 950, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm mr-2\">Düzenle</a>\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbddc6dae3d10177c23e5744d3237114f0088c307746", async() => {
                WriteLiteral("\r\n                                    <input type=\"hidden\" name=\"RoleId\"");
                BeginWriteAttribute("value", " value=\"", 1185, "\"", 1201, 1);
#nullable restore
#line 37 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
WriteAttributeValue("", 1193, item.Id, 1193, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                                    <button type=\"submit\" class=\"btn btn-danger btn-sm\">Sil</button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-warning\">\r\n                        <h3>Rol Yok</h3>\r\n                    </div>\r\n");
#nullable restore
#line 51 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Rols\RoleList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591