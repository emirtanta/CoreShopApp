#pragma checksum "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5972d64d947e0beb466900a583b629f896a7afaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CategoryEdit), @"mvc.1.0.view", @"/Views/Admin/CategoryEdit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5972d64d947e0beb466900a583b629f896a7afaa", @"/Views/Admin/CategoryEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7d42abdb88e967fc494220d8b8706bd3dd0cb16", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CategoryEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/deletefromcategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
  
    ViewData["Title"] = "Kategori Düzenleme Formu";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center\">");
#nullable restore
#line 7 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                   Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <div class=""col-md-8"">
            <div class=""row"">
                <table class=""table table-bordered table-sm"">
                    <thead>
                        <tr>
                            <td>Id</td>
                            <td>Resim</td>
                            <td>Ürün Adı</td>
                            <td>Fiyat</td>
                            <td>Onay</td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 25 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                         if (Model.Products.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                             foreach (var item in Model.Products)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5972d64d947e0beb466900a583b629f896a7afaa7402", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1092, "~/img/", 1092, 6, true);
#nullable restore
#line 32 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
AddHtmlAttributeValue("", 1098, item.ImageUrl, 1098, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 37 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                                         if (item.IsApproved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fas fa-check-circle\"> </i>\r\n");
#nullable restore
#line 40 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fas fa-times-circle\"></i>\r\n");
#nullable restore
#line 45 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1889, "\"", 1927, 2);
            WriteAttributeValue("", 1896, "/Admin/Products/", 1896, 16, true);
#nullable restore
#line 48 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 1912, item.ProductId, 1912, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm mr-2\">Düzenle</a>\r\n\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5972d64d947e0beb466900a583b629f896a7afaa11337", async() => {
                WriteLiteral("\r\n                                            <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 2183, "\"", 2206, 1);
#nullable restore
#line 51 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 2191, item.ProductId, 2191, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
                WriteLiteral("                                            <input type=\"hidden\" name=\"categoryId\"");
                BeginWriteAttribute("value", " value=\"", 2383, "\"", 2408, 1);
#nullable restore
#line 53 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
WriteAttributeValue("", 2391, Model.CategoryId, 2391, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <button type=\"submit\" class=\"btn btn-danger btn-sm\">Sil</button>\r\n                                        ");
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
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 59 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\emirt\source\repos\CoreShopApp\CoreShopApp.WebUI\Views\Admin\CategoryEdit.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
