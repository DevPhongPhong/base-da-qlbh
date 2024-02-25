#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ceeb14e18b2e0662447c137844f3a1362aec9a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_ProductCategory_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/ProductCategory/Index.cshtml")]
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
#line 1 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ceeb14e18b2e0662447c137844f3a1362aec9a5", @"/Areas/Administrator/Views/ProductCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_ProductCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.DTOs.ProductCategoryViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
  
    ViewData["Title"] = "Danh sách danh mục sản phẩm";
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 322, "\"", 350, 1);
#nullable restore
#line 11 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 329, Url.Action("Create"), 329, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success float-right"">Thêm mới</a>
            </div>
            <!-- /.card-header -->
            <div class=""card-body"">
                <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <table id=""example1"" class=""table table-bordered table-striped dataTable dtr-inline"" role=""grid"" aria-describedby=""example1_info"">
                                <thead>
                                    <tr role=""row"">
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Id</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""min-width: 300px;"">Tên danh mục</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""max-width: 50px;"">Tin hot");
            WriteLiteral(@"</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""max-width: 50px;"">Hiển thị trang chủ</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thứ tự</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thao tác</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 30 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                     if (Model != null)
                                    {
                                        if (Model.Count() > 0)
                                        {
                                            var id = 1;
                                            foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr role=\"row\">\r\n                                                    <td>");
#nullable restore
#line 38 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                   Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 39 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 40 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                     if (item.IsHot == true)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Có</td>\r\n");
#nullable restore
#line 43 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Không</td>\r\n");
#nullable restore
#line 47 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                     if (item.IsHome == true)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Có</td>\r\n");
#nullable restore
#line 51 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Không</td>\r\n");
#nullable restore
#line 55 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>");
#nullable restore
#line 56 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                   Write(item.CategoryOrder);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>\r\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 3737, "\"", 3784, 1);
#nullable restore
#line 58 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 3744, Url.Action("Edit", new { id = item.Id}), 3744, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                            <i class=""fa fa-edit""></i>
                                                        </a>
                                                        &nbsp;
                                                        <a onclick=""return confirm('Bạn có muốn xóa dữ liệu không?')""");
            BeginWriteAttribute("href", " href=\"", 4119, "\"", 4168, 1);
#nullable restore
#line 62 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 4126, Url.Action("Delete", new { id = item.Id}), 4126, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                            <i class=""fa fa-trash""></i>
                                                        </a>
                                                    </td>
                                                </tr>
");
#nullable restore
#line 67 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\ProductCategory\Index.cshtml"
                                                id++;
                                            }
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
    </div>
    <!-- /.col -->
</div>

<!-- Page specific script -->
<script>
    $(function () {
        $(""#example1"").DataTable({
            ""paging"": true,
            ""lengthChange"": false,
            ""searching"": true,
            ""ordering"": true,
            ""info"": true,
            ""autoWidth"": false,
            ""responsive"": true,
            ""buttons"": [""copy"", ""csv"", ""excel"", ""pdf"", ""print"", ""colvis""]
        }).buttons().container().appendTo('#example1 .col-md-6:eq(0)');
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.DTOs.ProductCategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
