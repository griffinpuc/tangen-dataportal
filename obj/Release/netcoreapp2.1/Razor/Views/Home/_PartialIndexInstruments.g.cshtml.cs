#pragma checksum "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1be174f87699c2aa8fb69c22ceea6ce85589367"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__PartialIndexInstruments), @"mvc.1.0.view", @"/Views/Home/_PartialIndexInstruments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_PartialIndexInstruments.cshtml", typeof(AspNetCore.Views_Home__PartialIndexInstruments))]
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
#line 2 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
using Portal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1be174f87699c2aa8fb69c22ceea6ce85589367", @"/Views/Home/_PartialIndexInstruments.cshtml")]
    public class Views_Home__PartialIndexInstruments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Portal.Models.modelPackage>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/bootstrap/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/bootstrap/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(60, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e29277d22fbb4bc982ed3cf60ed8ff3c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(122, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(124, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb78b5b1f57941bc9360e33432feb23e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(197, 332, true);
            WriteLiteral(@"

<div style=""text-align: center;""class=""card-header"" role=""tab"">


    <div class=""row"" style=""margin-bottom: 5vh; font-size: 14pt;"">
        <div class=""col"">
            <div>
                <i class=""fas fa-signal"" style=""color: #007bff""></i>
                Status: <span style=""color: #007bff; font-weight: bolder;"">");
            EndContext();
            BeginContext(530, 26, false);
#line 14 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                      Write(Model.connectedInstruments);

#line default
#line hidden
            EndContext();
            BeginContext(556, 94, true);
            WriteLiteral("</span>\r\n                connected out of <span style=\"color: #007bff; font-weight: bolder; \">");
            EndContext();
            BeginContext(651, 22, false);
#line 15 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                                Write(Model.totalInstruments);

#line default
#line hidden
            EndContext();
            BeginContext(673, 450, true);
            WriteLiteral(@"</span> instruments
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col"">
            <table class=""table"" align=""center"" style=""text-align: center;"">
                <thead>
                    <tr>
                        <th>ADDRESS</th>
                        <th>NAME</th>
                        <th>STATUS</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 31 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                     foreach (modelInstruments instrument in Model.instruments)
                    {
                        if (!instrument.status.Equals("OFFLINE"))
                        {

#line default
#line hidden
            BeginContext(1321, 109, true);
            WriteLiteral("                            <tr>\r\n                                <td><i class=\"fas fa-hdd\"></i>&nbsp; &nbsp;");
            EndContext();
            BeginContext(1431, 23, false);
#line 36 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                      Write(instrument.localAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1454, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1498, 15, false);
#line 37 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                               Write(instrument.name);

#line default
#line hidden
            EndContext();
            BeginContext(1513, 114, true);
            WriteLiteral("</td>\r\n                                <td style=\"color: #007bff;\">&nbsp; &nbsp;<i class=\"fa fa-check\"></i>&nbsp; ");
            EndContext();
            BeginContext(1628, 17, false);
#line 38 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                                                      Write(instrument.status);

#line default
#line hidden
            EndContext();
            BeginContext(1645, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 40 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1771, 129, true);
            WriteLiteral("                            <tr style=\"color: gray\">\r\n                                <td><i class=\"fas fa-hdd\"></i>&nbsp; &nbsp;");
            EndContext();
            BeginContext(1901, 23, false);
#line 44 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                      Write(instrument.localAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1924, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1968, 15, false);
#line 45 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                               Write(instrument.name);

#line default
#line hidden
            EndContext();
            BeginContext(1983, 128, true);
            WriteLiteral("</td>\r\n                                <td style=\"color: #fd7e14;\">&nbsp; &nbsp;<i class=\"fas fa-exclamation-circle\"></i>&nbsp; ");
            EndContext();
            BeginContext(2112, 17, false);
#line 46 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                                                                                                                    Write(instrument.status);

#line default
#line hidden
            EndContext();
            BeginContext(2129, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 48 "C:\Users\griff\Documents\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialIndexInstruments.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(2221, 86, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n</div>");
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
