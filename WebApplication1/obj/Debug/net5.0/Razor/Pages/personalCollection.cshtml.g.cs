#pragma checksum "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbae0320a1ba4a98b157408dfdfaefe8c9bead54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication1.Pages.Pages_personalCollection), @"mvc.1.0.razor-page", @"/Pages/personalCollection.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbae0320a1ba4a98b157408dfdfaefe8c9bead54", @"/Pages/personalCollection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d92a5a5b9cebb43f4a335cccc2143a08e566847", @"/Pages/_ViewImports.cshtml")]
    public class Pages_personalCollection : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
  
    Layout = "Shared/_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"banner-1\">\r\n        <div class=\"banner-b1\">\r\n            <h4>Mijn collectie</h4>\r\n");
#nullable restore
#line 12 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
             if (Model.GeenBezittingen)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"mt-4\">Het lijkt erop dat je nog geen items in je collectie hebt :(</h4>\r\n");
#nullable restore
#line 15 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    \r\n    <div class=\"kut-imgs\"> <!-- Deze naam maar even veranderen? hahaha -->\r\n        <div class=\"new-content\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 22 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
                 foreach (var stripboek in Model.Bezit)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-xl-3 col-lg-4 col-md-6 mb-3\">\r\n                        <div class=\"mt-4\">\r\n                            <div class=\"image\">\r\n                                <p class=\"text-white text-center\"");
            BeginWriteAttribute("style", " style=\"", 868, "\"", 876, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 920, "\"", 958, 1);
#nullable restore
#line (28,47)-(28,79) 29 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
WriteAttributeValue("", 926, stripboek.Versie.afbeelding_url, 926, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "  alt=\"", 959, "\"", 966, 0);
            EndWriteAttribute();
            WriteLiteral(" border=\"0\"/>\r\n                                    <div class=\"text-white text-center\">\r\n                                        <span>");
#nullable restore
#line (30,48)-(30,70) 6 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
Write(stripboek.Uitgave.naam);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line (30,73)-(30,100) 6 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
Write(stripboek.Versie.datum.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n                                    </div>\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 36 "G:\Mijn Drive\Periode3\Project\Comic2\WebApplication1\Pages\personalCollection.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Pages.personalCollection> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication1.Pages.personalCollection> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication1.Pages.personalCollection>)PageContext?.ViewData;
        public WebApplication1.Pages.personalCollection Model => ViewData.Model;
    }
}
#pragma warning restore 1591
