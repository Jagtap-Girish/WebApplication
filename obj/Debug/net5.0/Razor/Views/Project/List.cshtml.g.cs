#pragma checksum "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7907cb46178e6e2f7381668d810c50eb6963b9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_List), @"mvc.1.0.view", @"/Views/Project/List.cshtml")]
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
#line 1 "C:\Users\hp\Source\Repos\WebApplication\Views\_ViewImports.cshtml"
using PPMMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Source\Repos\WebApplication\Views\_ViewImports.cshtml"
using PPMMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7907cb46178e6e2f7381668d810c50eb6963b9a", @"/Views/Project/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16f3595ef8d4397390d10cd25777ef854c389039", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PPMMvc.Models.EmployeeToProject>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
           Write(Html.DisplayNameFor(model => model.ProjectId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
           Write(Html.DisplayNameFor(model => model.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 27 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProjectId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\hp\Source\Repos\WebApplication\Views\Project\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PPMMvc.Models.EmployeeToProject>> Html { get; private set; }
    }
}
#pragma warning restore 1591