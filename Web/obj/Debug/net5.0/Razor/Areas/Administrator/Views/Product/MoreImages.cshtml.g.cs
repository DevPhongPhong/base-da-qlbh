#pragma checksum "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "213fe56d1310e67629642d29a7c023f5d101245b2a07872c6c0db20ebc954bd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Product_MoreImages), @"mvc.1.0.view", @"/Areas/Administrator/Views/Product/MoreImages.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"213fe56d1310e67629642d29a7c023f5d101245b2a07872c6c0db20ebc954bd9", @"/Areas/Administrator/Views/Product/MoreImages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ae2cbd1f2459a79592bd1e63ebce111aab44cf44a2b13f55722d0ca8b9a364e0", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_Product_MoreImages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Models.ProductImages>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
  
    ViewData["Title"] = "Danh sách hình ảnh sản phẩm";
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
  
    var currentId = (int)ViewBag.CurrentId;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://cdn.ckeditor.com/4.15.1/standard/ckeditor.js""></script>
<!-- Fine Uploader New/Modern CSS file
    ====================================================================== -->
<link href=""/lib/fine-uploader/fine-uploader-new.css"" rel=""stylesheet"">

<!-- Fine Uploader JS file
====================================================================== -->
<script src=""/lib/fine-uploader/fine-uploader.js""></script>

<!-- Fine Uploader Thumbnails template w/ customization
====================================================================== -->
<script type=""text/template"" id=""qq-template-manual-trigger"">
    <div class=""qq-uploader-selector qq-uploader"" qq-drop-area-text=""Drop files here"">
        <div class=""qq-total-progress-bar-container-selector qq-total-progress-bar-container"">
            <div role=""progressbar"" aria-valuenow=""0"" aria-valuemin=""0"" aria-valuemax=""100"" class=""qq-total-progress-bar-selector qq-progress-bar qq-total-progress-bar""></div>
        </div>
        <div class=""qq-uplo");
            WriteLiteral(@"ad-drop-area-selector qq-upload-drop-area"" qq-hide-dropzone>
            <span class=""qq-upload-drop-area-text-selector""></span>
        </div>
        <div class=""buttons"">
            <div class=""qq-upload-button-selector qq-upload-button"">
                <div>Select files</div>
            </div>
            <button type=""button"" id=""trigger-upload"" class=""btn btn-primary"">
                <i class=""icon-upload icon-white""></i> Upload
            </button>
        </div>
        <span class=""qq-drop-processing-selector qq-drop-processing"">
            <span>Processing dropped files...</span>
            <span class=""qq-drop-processing-spinner-selector qq-drop-processing-spinner""></span>
        </span>
        <ul class=""qq-upload-list-selector qq-upload-list"" aria-live=""polite"" aria-relevant=""additions removals"">
            <li>
                <div class=""qq-progress-bar-container-selector"">
                    <div role=""progressbar"" aria-valuenow=""0"" aria-valuemin=""0"" aria-valuemax=""100"" class=""qq-pr");
            WriteLiteral(@"ogress-bar-selector qq-progress-bar""></div>
                </div>
                <span class=""qq-upload-spinner-selector qq-upload-spinner""></span>
                <img class=""qq-thumbnail-selector"" qq-max-size=""100"" qq-server-scale>
                <span class=""qq-upload-file-selector qq-upload-file""></span>
                <span class=""qq-edit-filename-icon-selector qq-edit-filename-icon"" aria-label=""Edit filename""></span>
                <input class=""qq-edit-filename-selector qq-edit-filename"" tabindex=""0"" type=""text"">
                <span class=""qq-upload-size-selector qq-upload-size""></span>
                <button type=""button"" class=""qq-btn qq-upload-cancel-selector qq-upload-cancel"">Cancel</button>
                <button type=""button"" class=""qq-btn qq-upload-retry-selector qq-upload-retry"">Retry</button>
                <button type=""button"" class=""qq-btn qq-upload-delete-selector qq-upload-delete"">Delete</button>
                <span role=""status"" class=""qq-upload-status-text-selector qq-upload");
            WriteLiteral(@"-status-text""></span>
            </li>
        </ul>

        <dialog class=""qq-alert-dialog-selector"">
            <div class=""qq-dialog-message-selector""></div>
            <div class=""qq-dialog-buttons"">
                <button type=""button"" class=""qq-cancel-button-selector"">Close</button>
            </div>
        </dialog>

        <dialog class=""qq-confirm-dialog-selector"">
            <div class=""qq-dialog-message-selector""></div>
            <div class=""qq-dialog-buttons"">
                <button type=""button"" class=""qq-cancel-button-selector"">No</button>
                <button type=""button"" class=""qq-ok-button-selector"">Yes</button>
            </div>
        </dialog>

        <dialog class=""qq-prompt-dialog-selector"">
            <div class=""qq-dialog-message-selector""></div>
            <input type=""text"">
            <div class=""qq-dialog-buttons"">
                <button type=""button"" class=""qq-cancel-button-selector"">Cancel</button>
                <button type=""button"" class=""qq-ok-button-s");
            WriteLiteral(@"elector"">Ok</button>
            </div>
        </dialog>
    </div>
</script>

<style>
    #trigger-upload {
        color: white;
        background-color: #00ABC7;
        font-size: 14px;
        padding: 7px 20px;
        background-image: none;
    }

    #fine-uploader-manual-trigger .qq-upload-button {
        margin-right: 15px;
    }

    #fine-uploader-manual-trigger .buttons {
        width: 36%;
    }

    #fine-uploader-manual-trigger .qq-uploader .qq-total-progress-bar-container {
        width: 60%;
    }
</style>

<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-body"">
                <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div class=""card card-success"">
                                <div class=""card-body"">
                                    <div class=""row"">
                                        <");
            WriteLiteral(@"div class=""col-md-12"">
                                            <label class=""control-label"">Ảnh sản phẩm</label>
                                            <div id=""fine-uploader-manual-trigger""></div>
                                            <script>
                                                var manualUploader = new qq.FineUploader({
                                                    element: document.getElementById('fine-uploader-manual-trigger'),
                                                    template: 'qq-template-manual-trigger',
                                                    request: {
                                                        endpoint: '");
#nullable restore
#line 124 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
                                                              Write(Url.Action("UploadImages", new { id = currentId}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                                                    },
                                                    thumbnails: {
                                                        placeholders: {
                                                            waitingPath: '/lib/fine-uploader/placeholders/waiting-generic.png',
                                                            notAvailablePath: '/lib/fine-uploader/placeholders/not_available-generic.png'
                                                        }
                                                    },
                                                    autoUpload: false,
                                                    debug: false,
                                                    params: {
                                                        id: 1
                                                    },
                                                    callbacks: {
                                                        onSubmit: fun");
            WriteLiteral("ction () {\n                                                            finalParams = {\n                                                                id: ");
#nullable restore
#line 140 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
                                                               Write(currentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                            };
                                                            this.setParams(finalParams);
                                                        },
                                                        onAllComplete: function () {
                                                            alert(""Tải lên thành công"");
                                                            window.location.href = """);
#nullable restore
#line 146 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
                                                                               Write(Url.Action("MoreImages", new { id = currentId}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
                                                        }
                                                    }
                                                });

                                                qq(document.getElementById(""trigger-upload"")).attach(""click"", function () {
                                                    manualUploader.uploadStoredFiles();
                                                });
                                            </script>
                                        </div>
                                    </div>
                                </div>
                                <div class=""card-body"">
                                    <div class=""row"">
                                        <div class=""col-md-12"">
                                            <a style=""margin-right: 10px;""");
            BeginWriteAttribute("href", " href=\"", 8656, "\"", 8683, 1);
#nullable restore
#line 161 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
WriteAttributeValue("", 8663, Url.Action("Index"), 8663, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-secondary float-right"">Quay lại danh sách sản phẩm</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-8"">
                            <table id=""example1"" class=""table table-bordered table-striped dataTable dtr-inline"" role=""grid"" aria-describedby=""example1_info"">
                                <thead>
                                    <tr role=""row"">
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Id</th>
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""min-width: 300px;"">Hình ảnh
                                        <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"">Thao tác</th>
                                    <");
            WriteLiteral("/tr>\n                                </thead>\n                                <tbody>\n");
#nullable restore
#line 177 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
                                     if (Model != null)
                                    {
                                        if (Model?.Count() > 0)
                                        {
                                            var id = 1;
                                            foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr role=\"row\">\n                                                    <td>");
#nullable restore
#line 185 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
                                                   Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                    <td><img style=\"height: 200px; width: 200px\"");
            BeginWriteAttribute("src", " src=\"", 10393, "\"", 10415, 1);
#nullable restore
#line 186 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
WriteAttributeValue("", 10399, item.ThumbImage, 10399, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\n                                                    <td>\n                                                        <a onclick=\"return confirm(\'Bạn có muốn xóa dữ liệu không?\')\"");
            BeginWriteAttribute("href", " href=\"", 10599, "\"", 10684, 1);
#nullable restore
#line 188 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
WriteAttributeValue("", 10606, Url.Action("ProductImagesDelete", new { id = item.Id, productid = currentId}), 10606, 78, false);

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
#line 193 "D:\PJs\base-da-qlbh\Web\Areas\Administrator\Views\Product\MoreImages.cshtml"
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
            <!-- /.card-body
                                    </div>
                                    <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Models.ProductImages>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
