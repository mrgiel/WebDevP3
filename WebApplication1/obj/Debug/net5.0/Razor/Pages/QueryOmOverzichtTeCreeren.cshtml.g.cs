#pragma checksum "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2694a41b6cc3910b5f21407da0ff8802ecb6a978"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication1.Pages.Pages_QueryOmOverzichtTeCreeren), @"mvc.1.0.razor-page", @"/Pages/QueryOmOverzichtTeCreeren.cshtml")]
namespace WebApplication1.Pages
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
#line 1 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2694a41b6cc3910b5f21407da0ff8802ecb6a978", @"/Pages/QueryOmOverzichtTeCreeren.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d92a5a5b9cebb43f4a335cccc2143a08e566847", @"/Pages/_ViewImports.cshtml")]
    public class Pages_QueryOmOverzichtTeCreeren : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
  
    Layout = "Shared/_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row text-white\">\r\n");
#nullable restore
#line 9 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
     foreach (var stripboek in Model.data)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-4 col-md-6 col-sm-12\">\r\n            <div class=\"row\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 289, "\"", 320, 1);
#nullable restore
#line (13,27)-(13,52) 29 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
WriteAttributeValue("", 295, stripboek.afbeelding_url, 295, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 300px; height: 300px\"");
            BeginWriteAttribute("alt", " alt=\"", 357, "\"", 363, 0);
            EndWriteAttribute();
            WriteLiteral("/>\r\n            </div>\r\n            <p");
            BeginWriteAttribute("class", " class=\"", 402, "\"", 410, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line (15,26)-(15,60) 6 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
Write(stripboek.Uitgave.Reeks.reeks_naam);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line (15,62)-(15,84) 6 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
Write(stripboek.Uitgave.naam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n");
#nullable restore
#line 17 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\QueryOmOverzichtTeCreeren.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Pages.QueryOmOverzichtTeCreeren> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication1.Pages.QueryOmOverzichtTeCreeren> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication1.Pages.QueryOmOverzichtTeCreeren>)PageContext?.ViewData;
        public WebApplication1.Pages.QueryOmOverzichtTeCreeren Model => ViewData.Model;
    }
}
#pragma warning restore 1591
