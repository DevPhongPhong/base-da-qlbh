#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6b2aef6813db8eb9f311cb3bda3c523776f9bf1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Roles_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Roles/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6b2aef6813db8eb9f311cb3bda3c523776f9bf1", @"/Areas/Administrator/Views/Roles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Roles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Models.Roles>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
  
    ViewData["Title"] = "Danh sách quyền hệ thống";
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 304, "\"", 332, 1);
#nullable restore
#line 11 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
WriteAttributeValue("", 311, Url.Action("Create"), 311, 21, false);

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
                        <div class=""col-md-12"">
                            <table id=""example1"" class=""table table-bordered table-striped dataTable dtr-inline"" role=""grid"" aria-describedby=""example1_info"">
                                <thead>
                                    <tr role=""row"">
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width: 80px; text-align:center"">Id</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Tên quyền</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width: 80px; te");
            WriteLiteral("xt-align:center\">Thao tác</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 27 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
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
            WriteLiteral("                                                <tr role=\"row\">\r\n                                                    <td style=\"width: 80px; text-align:center\">");
#nullable restore
#line 35 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
                                                                                          Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 36 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
                                                   Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td style=\"width: 80px; text-align:center\">\r\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 2297, "\"", 2344, 1);
#nullable restore
#line 38 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
WriteAttributeValue("", 2304, Url.Action("Edit", new { id = item.Id}), 2304, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                            <i class=""fa fa-edit""></i>
                                                        </a>
                                                        &nbsp;
                                                        <a onclick=""return confirm('Bạn có muốn xóa dữ liệu không?')""");
            BeginWriteAttribute("href", " href=\"", 2679, "\"", 2728, 1);
#nullable restore
#line 42 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
WriteAttributeValue("", 2686, Url.Action("Delete", new { id = item.Id}), 2686, 42, false);

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
#line 47 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Roles\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Models.Roles>> Html { get; private set; }
    }
}
#pragma warning restore 1591
