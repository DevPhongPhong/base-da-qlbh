#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d122b11276aed8a5dade22d82b09690cfd688e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_News), @"mvc.1.0.view", @"/Views/Home/News.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d122b11276aed8a5dade22d82b09690cfd688e4", @"/Views/Home/News.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_News : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("side-newslatter-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
  
    ViewData["Title"] = "Tin tức";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
  
    var newses = (Entities.Common.PaginationModel<List<Entities.DTOs.NewsViewModel>>)ViewBag.ListMainNews;
    
    var countPage = (newses.Pagination.Total % newses.Pagination.Size > 0) ? (newses.Pagination.Total / newses.Pagination.Size +1) : (newses.Pagination.Total / newses.Pagination.Size);
    var currentCategoryId = newses.Data.FirstOrDefault() != null ? newses.Data.FirstOrDefault().currentCategoryId : 1;
    var currentPage = newses.Pagination.Offset + 1;
    bool isNext = (currentPage < countPage);
    bool isPrev = (currentPage > 1);
    string currentOrder = ViewBag.CurrentOrder?.ToString();
    var currentCategory = ViewBag.CurrentCategory.ToString();

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
  
    var listRandomCategoryNews = (List<Entities.DTOs.CategoryNewsViewModel>)ViewBag.ListRandomCategoryNews;
    var listHotNewses = (List<Entities.DTOs.NewsViewModel>)ViewBag.ListHotNewses;
    var listRecentNews = (List<Entities.DTOs.NewsViewModel>)ViewBag.ListRecentNews;
    var listNewsCate = (List<Entities.DTOs.CategoryNewsViewModel>)TempData["newsmenu"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Start Breadcrumbs Section -->
<section class=""breadcrumbs-section background_bg"" data-img-src=""/assets/images/shop-breadcrumbs-img.jpg"" style=""        background: url(&quot;/assets/images/shop-breadcrumbs-img.jpg&quot;) center center / cover;"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""page_title text-center"">
                    <h1>Tin tức</h1>
                    <ul class=""breadcrumb justify-content-center"">
                        <li><a href=""/"">Trang chủ</a></li>
                        <li><span>Tin Tức</span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Header Section -->
<!-- Start Blog Section -->
<section class=""blog-inner-section pt_large pb_large news-style-2"">
    <div class=""container"">
        <div class=""row"">
");
#nullable restore
#line 44 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
             if (newses.Data?.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-xl-9 col-lg-8 col-md-12\">\r\n                    <div class=\"row blog_info\">\r\n");
#nullable restore
#line 48 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                         foreach (var item in newses.Data)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-12\">\r\n                                <div class=\"news-box box-1\">\r\n                                    <div class=\"news-img\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 2505, "\"", 2527, 1);
#nullable restore
#line 52 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 2511, item.ThumbImage, 2511, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"blog_img1\">\r\n                                        <div class=\"news-date-box text-center text-uppercase\">\r\n                                            <h6>");
#nullable restore
#line 54 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                           Write(item.PostedDate.Value.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>");
#nullable restore
#line 54 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                          Write(item.PostedDate.Value.ToString("MMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"news-info\">\r\n                                        <h5><a");
            BeginWriteAttribute("href", " href=\"", 2966, "\"", 3025, 1);
#nullable restore
#line 58 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 2973, Url.Action("NewsDetail","Home",new {id = item.Id }), 2973, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 58 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n                                        <p class=\"comments\">Đăng bởi: <a");
            BeginWriteAttribute("href", " href=\"", 3121, "\"", 3180, 1);
#nullable restore
#line 59 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 3128, Url.Action("NewsDetail","Home",new {id = item.Id }), 3128, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i>");
#nullable restore
#line 59 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                                                                                   Write(item.CreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></a></p>\r\n                                        <p class=\"news-text\">");
#nullable restore
#line 60 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                        Write(item.SubTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3337, "\"", 3396, 1);
#nullable restore
#line 61 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 3344, Url.Action("NewsDetail","Home",new {id = item.Id }), 3344, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"read-more\">Đọc thêm</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>");
#nullable restore
#line 64 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                       
                    </div>
                    <!--Paging area start-->
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <nav>
                                <ul class=""pagination justify-content-center"">
");
#nullable restore
#line 73 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                     if (countPage > 0)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                         for (int i = 1; i <= countPage; i++)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li ");
#nullable restore
#line 77 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                            Write(i == currentPage ? "class=active" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral("><a");
            BeginWriteAttribute("href", " href=\"", 4165, "\"", 4238, 1);
#nullable restore
#line 77 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 4172, Url.Action("News","Home",new { id = currentCategoryId, page = i}), 4172, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 77 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                                                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 78 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </nav>\r\n                        </div>\r\n                    </div>\r\n                    <!--Paging area end-->\r\n                </div>\r\n");
#nullable restore
#line 86 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-xl-3 col-lg-4 col-md-12 order-lg-first mt-4 mt-lg-0\">\r\n                <div class=\"blog-sidebar\">\r\n                    <div class=\"side-quantity-box side-box\">\r\n");
#nullable restore
#line 90 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                         if (listNewsCate?.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"side-box-title\">\r\n                                <h6>Danh mục tin tức</h6>\r\n                            </div>\r\n                            <div class=\"quantity-box-detail\">\r\n                                <ul>\r\n");
#nullable restore
#line 97 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                     foreach (var item in listNewsCate)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 5236, "\"", 5302, 1);
#nullable restore
#line 99 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 5243, Url.Action("News", "Home", new { id = item.Id, page = 1 }), 5243, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 99 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                                                             Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 100 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </div>\r\n");
#nullable restore
#line 103 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""side-newslatter-box side-box"">
                        <div class=""newslatter-inner-box"">
                            <div class=""side-box-title"">
                                <h6>Đăng ký nhận tin</h6>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d122b11276aed8a5dade22d82b09690cfd688e416025", async() => {
                WriteLiteral("\r\n                                <input");
                BeginWriteAttribute("required", " required=\"", 5884, "\"", 5895, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" placeholder=\"Email của bạn ... \"");
                BeginWriteAttribute("value", " value=\"", 5950, "\"", 5958, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"email\" id=\"newsLetter\">\r\n                                <button type=\"button\" class=\"newslatter-bnt\" onclick=\"subs(newsLetter)\"><i class=\"fa fa-envelope\"></i></button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 117 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                     if (listRecentNews?.Count > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""side-quantity-box side-box"">
                            <div class=""side-box-title"">
                                <h6>Tin xem gần đây</h6>
                            </div>
                            <div class=""side-recent-product"">
");
#nullable restore
#line 124 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                 foreach (var item in listRecentNews)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"cart-prodect d-flex\">\r\n                                        <div class=\"cart-img\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 6879, "\"", 6901, 1);
#nullable restore
#line 128 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 6885, item.ThumbImage, 6885, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"recent-product\">\r\n                                        </div>\r\n                                        <div class=\"cart-product\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 7088, "\"", 7147, 1);
#nullable restore
#line 131 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
WriteAttributeValue("", 7095, Url.Action("NewsDetail","Home",new { id = item.Id}), 7095, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 131 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 134 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 137 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Views\Home\News.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- End Blog Section -->\r\n");
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
