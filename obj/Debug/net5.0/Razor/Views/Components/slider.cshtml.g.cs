#pragma checksum "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Components\slider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "646dd665012ea1b99f1d90c712416a7769335ddf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Components_slider), @"mvc.1.0.view", @"/Views/Components/slider.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"646dd665012ea1b99f1d90c712416a7769335ddf", @"/Views/Components/slider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a67363c3fa972fa8ccc2eaf18f0c68f0ae299d26", @"/Views/_ViewImports.cshtml")]
    public class Views_Components_slider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< Slider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Components\slider.cshtml"
 foreach (var Slier1 in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"item active\">\r\n            <figure>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 151, "\"", 185, 3);
            WriteAttributeValue("", 157, "img/slide/", 157, 10, true);
#nullable restore
#line 11 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Components\slider.cshtml"
WriteAttributeValue("", 167, Slier1.Name, 167, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 181, ".jpg", 181, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 186, "\"", 192, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <figcaption></figcaption>\r\n            </figure>\r\n            <div class=\"carousel-caption\">\r\n                <h3>دیزاینر</h3>\r\n                <p>طراحی  رو از همین امروز شروع کن</p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 19 "G:\Users\ALimehrabi\source\repos\MohamadShop\MohamadShop\Views\Components\slider.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< Slider>> Html { get; private set; }
    }
}
#pragma warning restore 1591
