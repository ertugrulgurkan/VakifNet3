#pragma checksum "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84ff3fcc7790dcf4d8ce28a54787daef4958ee53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\_ViewImports.cshtml"
using miniShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\_ViewImports.cshtml"
using miniShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84ff3fcc7790dcf4d8ce28a54787daef4958ee53", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e89c7a1ffe5e5bc12468818da738b27fa24854d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input type=\"text\" name=\"name\" id=\"search\"");
            BeginWriteAttribute("value", " value=\"", 118, "\"", 126, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Aranacak kelime\" />\r\n<a href=\"#\" id=\"searchLink\">Ara</a>\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <h3 class=\"card-title\">");
#nullable restore
#line 14 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p>");
#nullable restore
#line 15 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
          Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>");
#nullable restore
#line 16 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
          Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" yerine ");
#nullable restore
#line 16 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"
                              Write((decimal)item.Price * 1 - (decimal) item.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL  </p>\r\n\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 20 "C:\Users\turka\source\repos\Kurumsal\Vakıfbank\.NET Core Part III\miniShop\miniShop\Views\Home\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
  <script>
      $(document).ready(function () {
          $('#search').on('change', function () {
              let word = $(this).val();
              console.log(word);
              $('#searchLink').attr('href', '/Home/Index?word=' + word);

          });
      });
  </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
