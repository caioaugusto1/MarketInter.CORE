#pragma checksum "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cbd025f9b4fd2b9bfe368eb0fe5d94a5f04bdbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Details), @"mvc.1.0.view", @"/Views/Student/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Details.cshtml", typeof(AspNetCore.Views_Student_Details))]
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
#line 1 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\_ViewImports.cshtml"
using Inter.Core.Presentation;

#line default
#line hidden
#line 2 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\_ViewImports.cshtml"
using Inter.Core.Presentation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cbd025f9b4fd2b9bfe368eb0fe5d94a5f04bdbd", @"/Views/Student/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66fe88ba958c482ccae365efc3fe99d911c552e1", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inter.Core.Presentation.Models.StudentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(101, 139, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>StudentViewModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(241, 46, false);
#line 14 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerId));

#line default
#line hidden
            EndContext();
            BeginContext(287, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(351, 42, false);
#line 17 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomerId));

#line default
#line hidden
            EndContext();
            BeginContext(393, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(456, 43, false);
#line 20 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.College));

#line default
#line hidden
            EndContext();
            BeginContext(499, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(563, 42, false);
#line 23 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.College.Id));

#line default
#line hidden
            EndContext();
            BeginContext(605, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(668, 44, false);
#line 26 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(712, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(776, 40, false);
#line 29 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(816, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(879, 41, false);
#line 32 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(920, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(984, 37, false);
#line 35 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1021, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1084, 48, false);
#line 38 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1132, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1196, 44, false);
#line 41 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1240, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1303, 50, false);
#line 44 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfBirthday));

#line default
#line hidden
            EndContext();
            BeginContext(1353, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1417, 46, false);
#line 47 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateOfBirthday));

#line default
#line hidden
            EndContext();
            BeginContext(1463, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1526, 43, false);
#line 50 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(1569, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1633, 39, false);
#line 53 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(1672, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1735, 40, false);
#line 56 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1775, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1839, 36, false);
#line 59 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1875, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1938, 43, false);
#line 62 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1981, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2045, 39, false);
#line 65 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(2084, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2147, 47, false);
#line 68 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nationality));

#line default
#line hidden
            EndContext();
            BeginContext(2194, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2258, 43, false);
#line 71 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nationality));

#line default
#line hidden
            EndContext();
            BeginContext(2301, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2364, 51, false);
#line 74 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PassaportNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2415, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2479, 47, false);
#line 77 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.PassaportNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2526, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2589, 48, false);
#line 80 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EnviromentId));

#line default
#line hidden
            EndContext();
            BeginContext(2637, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2701, 44, false);
#line 83 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
       Write(Html.DisplayFor(model => model.EnviromentId));

#line default
#line hidden
            EndContext();
            BeginContext(2745, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2792, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7cbd025f9b4fd2b9bfe368eb0fe5d94a5f04bdbd15680", async() => {
                BeginContext(2838, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "C:\Users\Caio's PC\Documents\Repositories\MarketInter.CORE\INTER.CORE\Inter.Core.Presentation\Views\Student\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2846, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2854, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7cbd025f9b4fd2b9bfe368eb0fe5d94a5f04bdbd18045", async() => {
                BeginContext(2876, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2892, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inter.Core.Presentation.Models.StudentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591