#pragma checksum "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\Phone\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1de1bb08d4028e72e6feed10c8d4e06d0db1019"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_EternaAdmin_Views_Phone_Detail), @"mvc.1.0.view", @"/Areas/EternaAdmin/Views/Phone/Detail.cshtml")]
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
#line 1 "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\_ViewImports.cshtml"
using Eterna_Back_End.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\_ViewImports.cshtml"
using Eterna_Back_End.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1de1bb08d4028e72e6feed10c8d4e06d0db1019", @"/Areas/EternaAdmin/Views/Phone/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9519186f6fb33fa07531ab417514fb8a11f94fe", @"/Areas/EternaAdmin/Views/_ViewImports.cshtml")]
    public class Areas_EternaAdmin_Views_Phone_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\Phone\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detail</h1>\r\n<div>\r\n    <div>\r\n        <p>Icon: </p>\r\n        <h4>");
#nullable restore
#line 10 "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\Phone\Detail.cshtml"
       Write(layoutservice.GetDatas().Result.FirstOrDefault(i => i.Key == "PhoneIcon").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n    <div>\r\n        <p>Number: </p>\r\n        <h4>");
#nullable restore
#line 14 "C:\Users\M S I\source\repos\Eterna Back-End\Eterna Back-End\Areas\EternaAdmin\Views\Phone\Detail.cshtml"
       Write(layoutservice.GetDatas().Result.FirstOrDefault(n => n.Key == "Phone").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Eterna_Back_End.Service.LayoutService layoutservice { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
