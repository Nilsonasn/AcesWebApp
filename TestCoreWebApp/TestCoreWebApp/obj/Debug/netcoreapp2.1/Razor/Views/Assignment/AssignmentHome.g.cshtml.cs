#pragma checksum "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7985af0c26bfcd9911955b6daab1942f617f24fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assignment_AssignmentHome), @"mvc.1.0.view", @"/Views/Assignment/AssignmentHome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Assignment/AssignmentHome.cshtml", typeof(AspNetCore.Views_Assignment_AssignmentHome))]
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
#line 1 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\_ViewImports.cshtml"
using TestCoreWebApp;

#line default
#line hidden
#line 2 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\_ViewImports.cshtml"
using TestCoreWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7985af0c26bfcd9911955b6daab1942f617f24fb", @"/Views/Assignment/AssignmentHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a4e51b57ee47545e6098fed2956fcede7ec6cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Assignment_AssignmentHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/tablestyles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
  
    var assignments = Model;

#line default
#line hidden
            BeginContext(68, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(97, 164, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf4703f5355e4ee6a90023915dc868eb", async() => {
                BeginContext(103, 97, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Assignemnts</title>\r\n    ");
                EndContext();
                BeginContext(200, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6b6228c196954ce7af4e5c6d34e79ca2", async() => {
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
                BeginContext(252, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(261, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(263, 890, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "982ddc50b18741299c31907fa2672600", async() => {
                BeginContext(269, 42, true);
                WriteLiteral("\r\n    <h1>\r\n        Assignment Scores for ");
                EndContext();
                BeginContext(312, 29, false);
#line 20 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
                         Write(assignments[0].AssignmentName);

#line default
#line hidden
                EndContext();
                BeginContext(341, 344, true);
                WriteLiteral(@"
    </h1>

    <table>
        <tr id=""TableHeader"">
            <th class=""firstcol"">Student Name</th>
            <th>Rating</th>
            <th>Score</th>
            <th>Compiler</th>
            <th>Number of Commits</th>
            <th>Average Time Between</th>
            <th>Standard Dev Commits</th>
        </tr>


");
                EndContext();
#line 35 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
         foreach (var assignment in assignments)
        {

#line default
#line hidden
                BeginContext(746, 47, true);
                WriteLiteral("        <tr>\r\n            <td class=\"firstcol\">");
                EndContext();
                BeginContext(794, 22, false);
#line 38 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
                            Write(assignment.StudentName);

#line default
#line hidden
                EndContext();
                BeginContext(816, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(840, 17, false);
#line 39 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment.Rating);

#line default
#line hidden
                EndContext();
                BeginContext(857, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(881, 28, false);
#line 40 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment._Score.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(909, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(933, 19, false);
#line 41 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment.Compiler);

#line default
#line hidden
                EndContext();
                BeginContext(952, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(976, 21, false);
#line 42 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment.NumCommits);

#line default
#line hidden
                EndContext();
                BeginContext(997, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1021, 24, false);
#line 43 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment.AvgTimeCommit);

#line default
#line hidden
                EndContext();
                BeginContext(1045, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1069, 22, false);
#line 44 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"
           Write(assignment.StDevCommit);

#line default
#line hidden
                EndContext();
                BeginContext(1091, 22, true);
                WriteLiteral("</td>\r\n        </tr>\r\n");
                EndContext();
#line 46 "C:\Users\Andrew\Documents\GitHub\AcesWebApp\TestCoreWebApp\TestCoreWebApp\Views\Assignment\AssignmentHome.cshtml"

        }

#line default
#line hidden
                BeginContext(1126, 20, true);
                WriteLiteral("    </table>\r\n\r\n\r\n\r\n");
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
            BeginContext(1153, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591