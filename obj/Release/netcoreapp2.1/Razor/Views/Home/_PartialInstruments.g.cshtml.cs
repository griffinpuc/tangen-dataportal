#pragma checksum "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b1290fa13f8beb743dedbeb189225a30f03d288"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__PartialInstruments), @"mvc.1.0.view", @"/Views/Home/_PartialInstruments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_PartialInstruments.cshtml", typeof(AspNetCore.Views_Home__PartialInstruments))]
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
#line 2 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
using Portal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b1290fa13f8beb743dedbeb189225a30f03d288", @"/Views/Home/_PartialInstruments.cshtml")]
    public class Views_Home__PartialInstruments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Portal.Models.modelPackage>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/bootstrap/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(60, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5a338324d56e43ba8a42e4f3e65b5014", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(133, 182, true);
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>ADDRESS</th>\r\n            <th>NAME</th>\r\n            <th>STATUS</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 15 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
         foreach (modelInstruments instrument in Model.instruments)
        {
            if (!instrument.status.Equals("OFFLINE"))
            {

#line default
#line hidden
            BeginContext(465, 162, true);
            WriteLiteral("                <tr>\r\n                    <td><div class=\"spinner-border-sm spinner-border text-primary\"></div>&nbsp;&nbsp;<i class=\"fas fa-hdd\"></i>&nbsp; &nbsp;");
            EndContext();
            BeginContext(628, 23, false);
#line 20 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                                                                       Write(instrument.localAddress);

#line default
#line hidden
            EndContext();
            BeginContext(651, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(683, 15, false);
#line 21 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                   Write(instrument.name);

#line default
#line hidden
            EndContext();
            BeginContext(698, 102, true);
            WriteLiteral("</td>\r\n                    <td style=\"color: #007bff;\">&nbsp; &nbsp;<i class=\"fa fa-check\"></i>&nbsp; ");
            EndContext();
            BeginContext(801, 17, false);
#line 22 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                          Write(instrument.status);

#line default
#line hidden
            EndContext();
            BeginContext(818, 221, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        <div class=\"btn-group\" role=\"group\"></div><button class=\"btn btn-outline-primary\" type=\"button\">Suspend</button>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 27 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1087, 181, true);
            WriteLiteral("                <tr style=\"color: grey;\">\r\n                    <td><div class=\"spinner-border-sm spinner-border text-muted\"></div>&nbsp;&nbsp;<i class=\"fas fa-hdd\"></i>&nbsp; &nbsp;");
            EndContext();
            BeginContext(1269, 23, false);
#line 31 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                                                                     Write(instrument.localAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1292, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1324, 15, false);
#line 32 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                   Write(instrument.name);

#line default
#line hidden
            EndContext();
            BeginContext(1339, 141, true);
            WriteLiteral("</td>\r\n                    <td style=\"color: #fd7e14;font-weight: bold;font-style: normal;\">&nbsp; &nbsp;<i class=\"fa fa-warning\"></i>&nbsp; ");
            EndContext();
            BeginContext(1481, 17, false);
#line 33 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                                                                 Write(instrument.status);

#line default
#line hidden
            EndContext();
            BeginContext(1498, 221, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        <div class=\"btn-group\" role=\"group\"></div><button class=\"btn btn-outline-primary\" type=\"button\">Suspend</button>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 38 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(1745, 24, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>");
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