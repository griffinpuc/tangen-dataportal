#pragma checksum "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4801ddfb5dd162c3427af61dcbdecbbfcf43df73"
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
#line 2 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
using Portal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4801ddfb5dd162c3427af61dcbdecbbfcf43df73", @"/Views/Home/_PartialInstruments.cshtml")]
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(60, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "021d138372e944aba0f4821eec56e556", async() => {
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
            BeginContext(133, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(139, 2193, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35d7ad55d674431a9606079b1a410f27", async() => {
                BeginContext(145, 217, true);
                WriteLiteral("\r\n\r\n    <script>\r\n\r\n        function RemoveInstrument(elem)\r\n        {\r\n            var instrumentID = elem;\r\n            //var instrumentID = $(elem).data(\'assigned-ID\');\r\n            $.ajax({\r\n                url: \'");
                EndContext();
                BeginContext(363, 38, false);
#line 16 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                 Write(Url.Action("removeInstrument", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(401, 334, true);
                WriteLiteral(@"',
                data: { instrumentID }
            });
        }

    </script>

    <table class=""table"">
        <thead>
            <tr>
                <th></th>
                <th>ADDRESS</th>
                <th>NAME</th>
                <th>STATUS</th>
            </tr>
        </thead>

        <tbody>
");
                EndContext();
#line 34 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
             foreach (modelInstruments instrument in Model.instruments)
            {

                if (!instrument.status.Equals("OFFLINE"))
                {

#line default
#line hidden
                BeginContext(903, 140, true);
                WriteLiteral("                    <tr>\r\n                        <td>&nbsp;&nbsp;<i class=\"fas fa-hdd\"></i></td>\r\n                        <td>&nbsp; &nbsp;");
                EndContext();
                BeginContext(1044, 23, false);
#line 41 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                    Write(instrument.localAddress);

#line default
#line hidden
                EndContext();
                BeginContext(1067, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1103, 15, false);
#line 42 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                       Write(instrument.name);

#line default
#line hidden
                EndContext();
                BeginContext(1118, 106, true);
                WriteLiteral("</td>\r\n                        <td style=\"color: #007bff;\">&nbsp; &nbsp;<i class=\"fa fa-check\"></i>&nbsp; ");
                EndContext();
                BeginContext(1225, 17, false);
#line 43 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                              Write(instrument.status);

#line default
#line hidden
                EndContext();
                BeginContext(1242, 157, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            <div class=\"btn-group\" role=\"group\"></div><button class=\"btn btn-outline-dark\" type=\"button\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 1399, "\"", 1441, 3);
                WriteAttributeValue("", 1409, "RemoveInstrument(", 1409, 17, true);
#line 45 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
WriteAttributeValue("", 1426, instrument.ID, 1426, 14, false);

#line default
#line hidden
                WriteAttributeValue("", 1440, ")", 1440, 1, true);
                EndWriteAttribute();
                BeginContext(1442, 78, true);
                WriteLiteral(">Remove</button>\r\n                        </td>\r\n\r\n                    </tr>\r\n");
                EndContext();
#line 49 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(1580, 161, true);
                WriteLiteral("                    <tr style=\"color: grey;\">\r\n                        <td>&nbsp;&nbsp;<i class=\"fas fa-hdd\"></i></td>\r\n                        <td>&nbsp; &nbsp;");
                EndContext();
                BeginContext(1742, 23, false);
#line 54 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                    Write(instrument.localAddress);

#line default
#line hidden
                EndContext();
                BeginContext(1765, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1801, 15, false);
#line 55 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                       Write(instrument.name);

#line default
#line hidden
                EndContext();
                BeginContext(1816, 145, true);
                WriteLiteral("</td>\r\n                        <td style=\"color: #fd7e14;font-weight: bold;font-style: normal;\">&nbsp; &nbsp;<i class=\"fa fa-warning\"></i>&nbsp; ");
                EndContext();
                BeginContext(1962, 17, false);
#line 56 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                                                                                                                                     Write(instrument.status);

#line default
#line hidden
                EndContext();
                BeginContext(1979, 157, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            <div class=\"btn-group\" role=\"group\"></div><button class=\"btn btn-outline-dark\" type=\"button\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 2136, "\"", 2178, 3);
                WriteAttributeValue("", 2146, "RemoveInstrument(", 2146, 17, true);
#line 58 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
WriteAttributeValue("", 2163, instrument.ID, 2163, 14, false);

#line default
#line hidden
                WriteAttributeValue("", 2177, ")", 2177, 1, true);
                EndWriteAttribute();
                BeginContext(2179, 76, true);
                WriteLiteral(">Remove</button>\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 61 "C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\Views\Home\_PartialInstruments.cshtml"
                }
            }

#line default
#line hidden
                BeginContext(2289, 36, true);
                WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
