#pragma checksum "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17d8e64e83ed80c8715f346a4c7310929ee4eb65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_ShowOrder), @"mvc.1.0.view", @"/Views/Orders/ShowOrder.cshtml")]
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
#line 1 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\_ViewImports.cshtml"
using MohamadShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\_ViewImports.cshtml"
using MohamadShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17d8e64e83ed80c8715f346a4c7310929ee4eb65", @"/Views/Orders/ShowOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a67363c3fa972fa8ccc2eaf18f0c68f0ae299d26", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_ShowOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MohamadShop.Models.ViewModels.ShowOrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
  
    ViewData["Title"] = "ShowOrder";
    int row = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>نمایش فاکتور</h1>\r\n<hr />\r\n\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>#</th>\r\n    \r\n        <th>عنوان</th>\r\n        <th>تعداد</th>\r\n        <th>قیمت</th>\r\n        <th>جمع</th>\r\n        <th></th>\r\n    </tr>\r\n");
#nullable restore
#line 20 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 23 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
           Write(row);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           \r\n            <td>");
#nullable restore
#line 25 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
           Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
           Write(item.Sum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a class=\"btn btn-sm btn-success\"");
            BeginWriteAttribute("href", " href=\"", 661, "\"", 714, 3);
            WriteAttributeValue("", 668, "/Orders/Command/", 668, 16, true);
#nullable restore
#line 30 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
WriteAttributeValue("", 684, item.OrderDetailId, 684, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 703, "?command=up", 703, 11, true);
            EndWriteAttribute();
            WriteLiteral(">افزایش</a>\r\n                <a class=\"btn btn-sm btn-warning\"");
            BeginWriteAttribute("href", " href=\"", 777, "\"", 832, 3);
            WriteAttributeValue("", 784, "/Orders/Command/", 784, 16, true);
#nullable restore
#line 31 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
WriteAttributeValue("", 800, item.OrderDetailId, 800, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 819, "?command=down", 819, 13, true);
            EndWriteAttribute();
            WriteLiteral(">کاهش</a>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17d8e64e83ed80c8715f346a4c7310929ee4eb658229", async() => {
                WriteLiteral("\r\n                    حذف\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
                                                                                               WriteLiteral(item.OrderDetailId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 37 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"

        row += 1;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td colspan=\"5\" class=\"text-left\">جمع کل : </td>\r\n        <td colspan=\"2\">\r\n            ");
#nullable restore
#line 43 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Orders\ShowOrder.cshtml"
       Write(Model.Sum(s => s.Sum).ToString("#,0 تومان"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td colspan=\"4\" class=\"text-left\"></td>\r\n        <td colspan=\"3\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17d8e64e83ed80c8715f346a4c7310929ee4eb6511567", async() => {
                WriteLiteral("تایید و پرداخت نهایی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </td>\r\n    </tr>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MohamadShop.Models.ViewModels.ShowOrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591