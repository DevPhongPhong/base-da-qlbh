#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ed2c7f21ea6912acfe7b523b3133f1833377943"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
#line 1 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ed2c7f21ea6912acfe7b523b3133f1833377943", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.DTOs.AccountLoginDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("subscribe-popup-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Đăng nhập";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<span></span>
<div class=""login-register-area mb-60px mt-53px"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-7 col-md-12 mx-auto"">
                <div class=""login-register-wrapper"">
                    <div class=""login-register-tab-list nav"">
                        <button class=""btn btn-primary"" data-bs-toggle=""tab"" href=""#"" style=""background:#ffffff;color:red"">
                            <h6>Đăng nhập</h6>
                        </button>
                        <a class=""btn btn-primary"" data-bs-toggle=""tab""");
            BeginWriteAttribute("href", " href=\"", 702, "\"", 743, 1);
#nullable restore
#line 16 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
WriteAttributeValue("", 709, Url.Action("Register", "Account"), 709, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <h6>Đăng ký</h6>\r\n                        </a>\r\n                    </div>\r\n");
#nullable restore
#line 20 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
                     if (ViewData["Error"] != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <hr />\r\n                        <div class=\"alert alert-danger p-2 mb-2\">");
#nullable restore
#line 23 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
                                                            Write(ViewData["Error"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 24 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""tab-content"">
                        <div id=""lg1"" class=""tab-pane active"">
                            <div class=""login-form-container"">
                                <div class=""login-register-form"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ed2c7f21ea6912acfe7b523b3133f18333779436245", async() => {
                WriteLiteral("\r\n                                        <input id=\"usernameLogin\" name=\"username\"");
                BeginWriteAttribute("required", " required=\"", 1551, "\"", 1562, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" placeholder=\"Email hoặc sô điện thoại\">\r\n                                        <input id=\"passwordLogin\" name=\"password\"");
                BeginWriteAttribute("required", " required=\"", 1698, "\"", 1709, 0);
                EndWriteAttribute();
                WriteLiteral(@" type=""password"" placeholder=""Mật khẩu"">
                                        <div class=""form-check text-left"">
                                            <label>
                                                Nhớ mật khẩu
                                                <input id=""savePassLogin"" class=""defult-check"" type=""checkbox""");
                BeginWriteAttribute("checked", " checked=\"", 2053, "\"", 2063, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <span class=\"checkmark\"></span>\r\n                                            </label>\r\n                                            <!--<a href=\"");
#nullable restore
#line 38 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
                                                    Write(Url.Action("Forget","Account"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" class=""forgot-password float-right"">Quên mật khẩu ?</a>-->
                                        </div>
                                        <div class=""text-center"">
                                            <button class=""btn btn-primary"" type=""submit"" onclick=""saveLogin()""><span>Đăng nhập</span></button>
                                        </div>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
AddHtmlAttributeValue("", 1419, Url.ActionLink("Login"), 1419, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
#nullable restore
#line 29 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Account\Login.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">
    if (localStorage[""username""] != null && localStorage[""username""] != undefined && localStorage[""password""] != null && localStorage[""password""] != undefined) {
        var u = document.getElementById(""usernameLogin"");
        var p = document.getElementById(""passwordLogin"");
        u.value = localStorage[""username""];
        p.value = localStorage[""password""];
        localStorage.removeItem(""username"");
        localStorage.removeItem(""password"");
    }
    function saveLogin() {
        var check = document.getElementById(""savePassLogin"")
        var checkvalue = check.checked;
        if (checkvalue === true) {
            var u = document.getElementById(""usernameLogin"");
            var p = document.getElementById(""passwordLogin"");
          ");
            WriteLiteral("  localStorage[\"username\"] = u.value;\r\n            localStorage[\"password\"] = p.value;\r\n        }\r\n    }\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.DTOs.AccountLoginDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
