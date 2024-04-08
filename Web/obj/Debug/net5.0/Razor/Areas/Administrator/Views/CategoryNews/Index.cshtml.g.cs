#pragma checksum "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "af31508a6681d6415c706e90ab2616209f113d5e3aef001e7853f6708bb30c0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_CategoryNews_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/CategoryNews/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"af31508a6681d6415c706e90ab2616209f113d5e3aef001e7853f6708bb30c0d", @"/Areas/Administrator/Views/CategoryNews/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ae2cbd1f2459a79592bd1e63ebce111aab44cf44a2b13f55722d0ca8b9a364e0", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_CategoryNews_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.DTOs.CategoryNewsViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
  
    ViewData["Title"] = "Danh sách Chuyên mục";
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-12\">\n        <div class=\"card\">\n            <div class=\"card-header\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 302, "\"", 330, 1);
#nullable restore
#line 11 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
WriteAttributeValue("", 309, Url.Action("Create"), 309, 21, false);

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
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""min-width: 300px;"">Tên chuyên mục</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""max-width: 50px;"">Tin hot</th>
    ");
            WriteLiteral(@"                                    <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""max-width: 50px;"">Hiển thị trang chủ</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thứ tự</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thao tác</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 30 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
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
            WriteLiteral("                                                <tr role=\"row\">\n                                                    <td>");
#nullable restore
#line 38 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                   Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                    <td>");
#nullable restore
#line 39 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 40 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                     if (item.IsHot == true)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Có</td>\n");
#nullable restore
#line 43 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Không</td>\n");
#nullable restore
#line 47 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                     if (item.IsHome == true)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Có</td>\n");
#nullable restore
#line 51 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Không</td>\n");
#nullable restore
#line 55 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>");
#nullable restore
#line 56 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
                                                   Write(item.CategoryOrder);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                    <td>\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 3672, "\"", 3719, 1);
#nullable restore
#line 58 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
WriteAttributeValue("", 3679, Url.Action("Edit", new { id = item.Id}), 3679, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                            <i class=""fa fa-edit""></i>
                                                        </a>
                                                        &nbsp;
                                                        <a onclick=""return confirm('Bạn có muốn xóa dữ liệu không?')""");
            BeginWriteAttribute("href", " href=\"", 4050, "\"", 4099, 1);
#nullable restore
#line 62 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
WriteAttributeValue("", 4057, Url.Action("Delete", new { id = item.Id}), 4057, 42, false);

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
#line 67 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\CategoryNews\Index.cshtml"
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
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.DTOs.CategoryNewsViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
