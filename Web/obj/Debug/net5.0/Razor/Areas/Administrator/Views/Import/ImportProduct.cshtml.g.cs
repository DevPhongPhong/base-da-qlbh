#pragma checksum "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bbc52096c19dc8273b7fa564f5b405dc104e321"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Import_ImportProduct), @"mvc.1.0.view", @"/Areas/Administrator/Views/Import/ImportProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bbc52096c19dc8273b7fa564f5b405dc104e321", @"/Areas/Administrator/Views/Import/ImportProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Import_ImportProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
  
    ViewData["Title"] = "Nhập hàng";
    Layout = "~/Areas/Administrator/Views/Shared/_Layout.cshtml";
    var listCode = (List<Entities.DTOs.ImportProductViewModel?>)ViewBag.ListImportProduct;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- /.card-header -->
<div class=""card-body"">
    <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <table class=""table table-bordered"">
                    <thead>
                        <tr>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:5%"">STT</th>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:10%"">Mã SP</th>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:5%"">ID</th>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:40%"">Tên SP</th>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:10%"">Đơn giá (kĐ)</th>
                       ");
            WriteLiteral(@"     <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:10%"">Số lượng</th>
                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" style=""width:10%"">Thao tác</th>
                        </tr>
                    </thead>
                    <tbody id=""importProductTableBody"">
                    </tbody>
                    <tfoot>
                        <tr id=""thisRow"" style=""background-color: #dbdbdb"">
                            <td></td>
                            <td class=""codeProduct"">
                                <input list=""listCode"" id=""waitKeycode"" placeholder=""---Nhập mã sản phẩm"" onkeyup=""searchByKeyCode(this.value,waitId,waitName)"" style=""width: 100%; padding: 5px; display: inline-block; border: 1px solid #ccc; border-radius: 5px; box-sizing: border-box;"" />
                                <datalist id=""listCode"">
");
#nullable restore
#line 31 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
                                     foreach (var item in listCode)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bbc52096c19dc8273b7fa564f5b405dc104e3216041", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
                                           WriteLiteral(item.Code);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </datalist>
                            </td>
                            <td id=""waitId"" class=""idProduct""></td>
                            <td id=""waitName"" class=""nameProduct""></td>
                            <td><input id=""waitPrice"" value=""0"" min=""0"" type=""number"" style=""width: 100%; padding: 5px; display: inline-block; border: 1px solid #ccc; border-radius: 5px; box-sizing: border-box;"" /></td>
                            <td><input id=""waitQuantity"" value=""0"" type=""number"" min=""0"" style=""width: 100%; padding: 5px; display: inline-block; border: 1px solid #ccc; border-radius: 5px; box-sizing: border-box;"" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><button id=""addItem"" class=""btn btn-primary"" style=""width:100%"" onclick=""addMoreRow(waitKeycode, waitId, waitName, waitQuantity,waitPrice)"">Thêm</button></td>
                            <td colspan=""5"" id=""mes"" style=""color");
            WriteLiteral(@":red""></td>
                            <td>
                                <button class=""btn btn-success"" onclick=""sendReq()"">
                                    Nhập hàng
                                </button>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</div>
<!-- /.card-body -->
<script type=""text/javascript"">
    var count = 1;
    function addMoreRow(k, i, n, q,p) {
        if (k.value == """" || i.innerHTML == """" || n.innerHTML == """") {
            document.getElementById(""mes"").innerHTML = ""Thông tin nhập hàng chưa đủ"";
        }
        else if (q.value <= 0) {
            document.getElementById(""mes"").innerHTML = ""Nhập số lượng"";
        }
        else if (p.value<=0)
        {
            document.getElementById(""mes"").innerHTML = ""Nhập đơn giá"";
        }
        else
        {
            var tableBody = document.getElementById(""importProductTabl");
            WriteLiteral(@"eBody"");
            var row = document.createElement('tr');
            row.id = k.value;
            row.innerHTML = `<tr>
                            <td contenteditable=""false"">`+ count + `</td>
                            <td contenteditable=""false"">`+ k.value + `</td>
                            <td contenteditable=""false"">`+ i.innerHTML + `</td>
                            <td contenteditable=""false"">`+ n.innerHTML + `</td>
                            <td contenteditable=""false"" type=""number""><input value=""`+ p.value + `"" min=""0"" type=""number"" style=""width: 100%; padding: 5px; display: inline-block; border: 1px solid #ccc; border-radius: 5px; box-sizing: border-box;""/></td>
                            <td contenteditable=""false"" type=""number""><input value=""`+ q.value + `"" min=""0"" type=""number"" style=""width: 100%; padding: 5px; display: inline-block; border: 1px solid #ccc; border-radius: 5px; box-sizing: border-box;""/></td>
                        </tr>`;
            tableBody.innerHTML = ta");
            WriteLiteral(@"bleBody.innerHTML + row.innerHTML;
            count++;
            i.innerHTML = n.innerHTML = """";
            k.value = """"; q.value = 0; p.value = 0;
        }
    }

    function deleteImportItem(obj) {
       obj.parentElement.parentElement.remove();
    }

    function searchByKeyCode(value,i,n) {
        $.ajax({
            url: """);
#nullable restore
#line 98 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
             Write(Url.Action("SearchProductByKeyCode", "Product"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: { keyCode: value },
            type: 'POST',
            dataType: 'json',
            success: function (res) {

                if (res.status == true) {
                    i.innerHTML = res.obj.ProductID;
                    n.innerHTML = res.obj.Name;
                    document.getElementById(""mes"").innerHTML = """";
                }
                else {
                    i.innerHTML = """";
                    n.innerHTML = """";
                    document.getElementById(""mes"").innerHTML = res.message;
                }
            }
        });
    }

    function sendReq() {
        document.getElementById(""mes"").innerHTML = 'Sau khi nhập hành thành công, hệ thống sẽ gửi file Excel nhập hàng!';
        var listObj = [];
        var list = document.getElementById(""importProductTableBody"").rows;
        var length = list.length;
        for (i = 0; i < length; i++) {
            var obj = {};
            obj.ProductID = parseInt(list[i].cells[2].innerH");
            WriteLiteral(@"TML);
            obj.Quantity = parseInt(list[i].cells[5].children[0].value);
            obj.Code = list[i].cells[1].innerHTML;
            obj.Name = list[i].cells[3].innerHTML;
            obj.Price = parseInt(list[i].cells[4].children[0].value+""000"");
            listObj.push(obj);
        };
        $.ajax({
            url: """);
#nullable restore
#line 133 "F:\ProgramingPJ\dotnetPJ\qlbh\Web\Areas\Administrator\Views\Import\ImportProduct.cshtml"
             Write(Url.Action("ImportProduct","Import"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: { jsonString: JSON.stringify(listObj) },
            type: ""POST"",
            dataType: ""json"",
            success: function (res) {
                if (res.status == true) {
                    window.location.href = res.filePath;
                }
                else {
                    alert(""Có lỗi xảy ra vui lòng nhập hàng lại"")
                }
            }
        });
    }
</script>");
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
