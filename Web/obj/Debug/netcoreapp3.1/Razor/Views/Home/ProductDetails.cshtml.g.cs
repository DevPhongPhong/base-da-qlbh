#pragma checksum "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "615c0460e862ea8a15b87a2eb94067c06ce648d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductDetails), @"mvc.1.0.view", @"/Views/Home/ProductDetails.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"615c0460e862ea8a15b87a2eb94067c06ce648d1", @"/Views/Home/ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"243bef8901b38e9eef9e38f8c66b8f401f171c9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.DTOs.ProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
   ViewData["Title"] = Model.Name;
    Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
  
    var chooseColor = (int)ViewBag.ChooseColor;
    var chooseLength = (int)ViewBag.ChooseLength;
    var chooseProduct = (int)ViewBag.ChooseProduct;
    var chooseQuantity = (int)ViewBag.ChooseQuantity;
    var message = (string)TempData["sentContact"];
    var listFeedback = (List<Entities.Models.Feedback>)ViewBag.ListFeedback;
    var listRelativeProduct = (List<Entities.DTOs.ProductViewModel>)ViewBag.RelativeProduct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- shop-details Area Start-->
<div class=""shop-details-area pd-top-100"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-6"">
                <div class=""sticy-product"">
                    <div class=""product-thumbnail-wrapper"">
                        <div class=""single-thumbnail-slider"">
                            <div class=""slider-item"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 1065, "\"", 1092, 1);
#nullable restore
#line 24 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 1071, Model.MainImageThumb, 1071, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"item\" style=\"max-width:300px\">\r\n                            </div>\r\n");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                             foreach (var item in Model.ProductImages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"slider-item\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 1369, "\"", 1391, 1);
#nullable restore
#line 29 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 1375, item.LargeImage, 1375, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"item\" style=\"max-width:300px\">\r\n                                </div>");
#nullable restore
#line 30 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"product-thumbnail-carousel\">\r\n                            <div class=\"single-thumbnail-item\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1670, "\"", 1697, 1);
#nullable restore
#line 34 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 1676, Model.MainImageThumb, 1676, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"item\" style=\"max-width: 100px\">\r\n                            </div>\r\n");
#nullable restore
#line 36 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                             foreach (var item in Model.ProductImages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"single-thumbnail-item\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 1985, "\"", 2007, 1);
#nullable restore
#line 39 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 1991, item.LargeImage, 1991, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"item\" style=\"max-width: 100px\">\r\n                                </div>");
#nullable restore
#line 40 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6"">
                <div class=""shop-item-details"">
                    <nav>
                        <ul class=""breadcrumb"">
                            <li class=""breadcrumb-item""><a href=""/"">Trang chủ</a></li>
                            <li class=""breadcrumb-item""><a");
            BeginWriteAttribute("href", " href=\"", 2499, "\"", 2582, 1);
#nullable restore
#line 50 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 2506, Url.Action("Product","Home",new { id = Model.ProductCategory.Id, page = 1}), 2506, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                                                                          Write(Model.ProductCategory.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 51 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        </ul>\r\n                    </nav>\r\n                    <h2 class=\"entry-title\">");
#nullable restore
#line 54 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <hr />\r\n                    <div class=\"row\">\r\n");
#nullable restore
#line 70 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                         if (Model.PromotionPrice.HasValue)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"row\" style=\"margin:10px\">\r\n                                <h5 class=\"price\"><b style=\"color:red\">Giá gốc:&nbsp;</b> <del>");
#nullable restore
#line 73 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                          Write(Model.Price?.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ </del></h5>\r\n                            </div>\r\n                            <div class=\"row\" style=\"margin:10px\">\r\n                                <h5 class=\"price\"><b style=\"color: #fdc913\">Giá hiện tại:&nbsp; ");
#nullable restore
#line 76 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                           Write(Model.PromotionPrice?.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</b></h5>\r\n                            </div>\r\n");
#nullable restore
#line 78 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5 class=\"price\">\r\n                                <b style=\"color: #fdc913\">");
#nullable restore
#line 82 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                     Write(Model.Price?.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</b>\r\n                            </h5>\r\n");
#nullable restore
#line 84 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <hr />\r\n");
            WriteLiteral("\r\n                    <ul class=\"cat\">\r\n                        <li> Mã sản phẩm: ");
#nullable restore
#line 121 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                     Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li>Danh mục: <a");
            BeginWriteAttribute("href", " href=\"", 6903, "\"", 6986, 1);
#nullable restore
#line 122 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 6910, Url.Action("Product","Home",new { id = Model.ProductCategory.Id, page = 1}), 6910, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 122 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                                                        Write(Model.ProductCategory.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>  </li>\r\n                    </ul>\r\n");
#nullable restore
#line 124 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                     if (Model.Quantity > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" class=\"btn btn-secondary float-left\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7214, "\"", 7244, 3);
            WriteAttributeValue("", 7224, "addToCart(", 7224, 10, true);
#nullable restore
#line 126 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 7234, Model.Id, 7234, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7243, ")", 7243, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Thêm vào giỏ</button>\r\n");
#nullable restore
#line 127 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"btn btn-secondary\">Bánh này đã hết</div>\r\n");
#nullable restore
#line 131 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <hr />
                    <div class=""shop-tabs"">
                        <ul class=""nav nav-pills"" id=""pills-tab"" role=""tablist"">
                            <li class=""nav-item"" role=""presentation"">
                                <button class=""nav-link active"" id=""pills-home-tab"" data-bs-toggle=""pill"" data-bs-target=""#pills-home"" type=""button"" role=""tab"" aria-controls=""pills-home"" aria-selected=""true"">Chi tiết sản phẩm</button>
                            </li>
                        </ul>
                        <div class=""tab-content"" id=""pills-tabContent"">
                            <div class=""tab-pane fade show active"" id=""pills-home"" role=""tabpanel"" aria-labelledby=""pills-home-tab"">
                                ");
#nullable restore
#line 141 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                           Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- shop-details Area End -->
<!-- related-product Area Start-->
<section class=""related-product-area pd-top-120"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-lg-12"">
                <div class=""section-title mb-0"">
                    <h2 class=""title"">Sản phẩm liên quan</h2>
                </div>
                <div class=""related-product-slider owl-carousel style-2"">
");
#nullable restore
#line 160 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                     foreach (var item in listRelativeProduct)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"item\">\r\n                            <div class=\"single-item-wrap\">\r\n                                <div class=\"thumb\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 9146, "\"", 9172, 1);
#nullable restore
#line 165 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 9152, item.MainImageThumb, 9152, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"img\">\r\n");
            WriteLiteral("                                </div>\r\n                                <div class=\"wrap-details\">\r\n                                    <h5><a");
            BeginWriteAttribute("href", " href=\"", 9431, "\"", 9528, 1);
#nullable restore
#line 169 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 9438, Url.Action("ProductDetails","Home", new { id = item.Id,color = 1, length =1, quantity=1}), 9438, 90, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 169 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n                                    <div class=\"wrap-footer\">\r\n                                        <h6 class=\"price \">\r\n");
#nullable restore
#line 172 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                             if (item.PromotionPrice.HasValue)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <del>");
#nullable restore
#line 174 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                Write(item.Price?.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ </del>\r\n");
#nullable restore
#line 175 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                           Write(item.PromotionPrice?.ToString("N0"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 175 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                                     }
                                            else
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 178 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                           Write(item.Price?.ToString("N0"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 178 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                                                                           
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            đ
                                        </h6>
                                    </div>
                                </div>
                                <div class=""btn-area"">
                                    <button class=""btn btn-secondary"" type=""button""");
            BeginWriteAttribute("onclick", " onclick=\"", 10519, "\"", 10548, 3);
            WriteAttributeValue("", 10529, "addToCart(", 10529, 10, true);
#nullable restore
#line 185 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 10539, item.Id, 10539, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10547, ")", 10547, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Thêm vào giỏ</button>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 189 "C:\Users\Admin\source\repos\base-da-qlbh\Web\Views\Home\ProductDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</section>
<!-- related-product Area End -->
<script>
    $(""#dec"").click(function () {
                        var crdt = $(""#quantity"").val();
                        if (crdt > 0) {
                            crdt--;
                        }
        $(""#quantity"").val(crdt);
                    });
    $(""#inc"").click(function () {
        var crdt = $(""#quantity"").val();
        crdt++;
        $(""#quantity"").val(crdt);
    });
");
            WriteLiteral("</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.DTOs.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
