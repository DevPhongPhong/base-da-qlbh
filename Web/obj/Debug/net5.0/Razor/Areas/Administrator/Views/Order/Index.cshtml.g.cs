#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a841b594c58406e3e3c2b7173091f446c84899cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Order/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a841b594c58406e3e3c2b7173091f446c84899cf", @"/Areas/Administrator/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.DTOs.OrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
  
    ViewData["Title"] = ViewBag.TitleForm;
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";
    int currentStatus = (int)ViewBag.CurrentStatus;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <button class=""btn btn-success float-left"" onclick=""exportExcel()"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-file-earmark-spreadsheet"" viewBox=""0 0 16 16"">
                        <path d=""M14 14V4.5L9.5 0H4a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2zM9.5 3A1.5 1.5 0 0 0 11 4.5h2V9H3V2a1 1 0 0 1 1-1h5.5v2zM3 12v-2h2v2H3zm0 1h2v2H4a1 1 0 0 1-1-1v-1zm3 2v-2h3v2H6zm4 0v-2h3v1a1 1 0 0 1-1 1h-2zm3-3h-3v-2h3v2zm-7 0v-2h3v2H6z"" />
                    </svg>
                    &nbsp;
                    Xuất Excel
                </button>

            </div>
            <!-- /.card-header -->
            <div class=""card-body"">
                <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
");
            WriteLiteral(@"                            <table id=""example1"" class=""table table-bordered table-striped dataTable dtr-inline"" role=""grid"" aria-describedby=""example1_info"">
                                <thead>
                                    <tr role=""row"">
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Id</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Mã đơn</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Người đặt</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Ngày đặt</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">SDT</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1""");
            WriteLiteral(@" rowspan=""1"" colspan=""1"">Địa chỉ</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Tổng tiền</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Trạng thái</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thao tác</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 41 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
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
#line 49 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 50 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.OrderCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 51 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.CustomerFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 52 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.CreatedDate?.ToString("hh:mm:ss, dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 53 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.CustomerPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 54 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 55 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 56 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(item.OrderStatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>\r\n                                                        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 4105, "\"", 4189, 1);
#nullable restore
#line 58 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 4112, Url.Action("Details", new { id = item.Id, current = ViewBag.CurrentStatus }), 4112, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                            Chi tiết\r\n                                                        </a>\r\n");
#nullable restore
#line 61 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                         if (item.OrderStatusId == 1)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <span>\r\n                                                                <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 4629, "\"", 4731, 1);
#nullable restore
#line 64 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 4636, Url.Action("ChangeStatus", new {order = item.Id, status = 2, current = ViewBag.CurrentStatus}), 4636, 95, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                                    Xác nhận
                                                                </a>
                                                                &nbsp;
                                                                <a class=""btn btn-danger""");
            BeginWriteAttribute("href", " href=\"", 5044, "\"", 5148, 1);
#nullable restore
#line 68 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 5051, Url.Action("ChangeStatus", new { order = item.Id, status = -1, current = ViewBag.CurrentStatus}), 5051, 97, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                    Hủy đơn\r\n                                                                </a>\r\n                                                            </span>\r\n");
#nullable restore
#line 72 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                        }
                                                        else if (item.OrderStatusId == 2)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <span>\r\n                                                                <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 5735, "\"", 5838, 1);
#nullable restore
#line 76 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 5742, Url.Action("ChangeStatus", new { order = item.Id, status = 3, current = ViewBag.CurrentStatus}), 5742, 96, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                    Xuất kho đi giao\r\n                                                                </a>\r\n                                                            </span>\r\n");
#nullable restore
#line 80 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                        }
                                                        else if (item.OrderStatusId == 3)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <span>\r\n                                                                <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 6434, "\"", 6537, 1);
#nullable restore
#line 84 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 6441, Url.Action("ChangeStatus", new { order = item.Id, status = 4, current = ViewBag.CurrentStatus}), 6441, 96, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                    Giao thành công\r\n                                                                </a>\r\n                                                                <a class=\"btn btn-warning\"");
            BeginWriteAttribute("href", " href=\"", 6786, "\"", 6890, 1);
#nullable restore
#line 87 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
WriteAttributeValue("", 6793, Url.Action("ChangeStatus", new { order = item.Id, status = -2, current = ViewBag.CurrentStatus}), 6793, 97, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                    Giao thất bại\r\n                                                                </a>\r\n                                                            </span>\r\n");
#nullable restore
#line 91 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 94 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                id++;
                                            }
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>

                            <script>
                                function exportExcel() {
                                    $.ajax({
                                        data: { status: ");
#nullable restore
#line 104 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                                   Write(currentStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(" },\r\n                                        url: \'");
#nullable restore
#line 105 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Order\Index.cshtml"
                                         Write(Url.Action("ExportExcel"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                                        dataType: 'json',
                                        type: 'POST',
                                        success: function (res) { window.location.href = res.filePath},
                                    });
                                }
                            </script>
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
        }).buttons().container().appendTo('#example1 .col-md-6:eq(0)');");
            WriteLiteral("\r\n    });\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.DTOs.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
