#pragma checksum "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b886e9c1d9e4e491d1af4a5414dcd521ea90b67a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__PartialTagDrop), @"mvc.1.0.view", @"/Views/Home/_PartialTagDrop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_PartialTagDrop.cshtml", typeof(AspNetCore.Views_Home__PartialTagDrop))]
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
#line 2 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml"
using Portal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b886e9c1d9e4e491d1af4a5414dcd521ea90b67a", @"/Views/Home/_PartialTagDrop.cshtml")]
    public class Views_Home__PartialTagDrop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Portal.Models.modelPackage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 9, true);
            WriteLiteral("\r\n<div>\r\n");
            EndContext();
#line 5 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml"
     foreach (modelTag tag in Model.tags)
    {

#line default
#line hidden
            BeginContext(118, 61, true);
            WriteLiteral("    <div class=\"row\">\r\n        <i class=\"fas fa-circle fa-xs\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 179, "\"", 204, 2);
            WriteAttributeValue("", 187, "color:", 187, 6, true);
#line 8 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml"
WriteAttributeValue(" ", 193, tag.color, 194, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(205, 49, true);
            WriteLiteral(" data-toggle=\"tooltip\" data-placement=\"top\"></i> ");
            EndContext();
            BeginContext(255, 8, false);
#line 8 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml"
                                                                                                            Write(tag.name);

#line default
#line hidden
            EndContext();
            BeginContext(263, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 10 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialTagDrop.cshtml"
    }

#line default
#line hidden
            BeginContext(284, 6, true);
            WriteLiteral("</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Portal.Models.modelPackage> Html { get; private set; }
    }
}
#pragma warning restore 1591
