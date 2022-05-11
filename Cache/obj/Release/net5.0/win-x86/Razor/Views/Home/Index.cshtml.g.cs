#pragma checksum "C:\Users\David\Desktop\COMPSCI 711 A1\Cache\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "800acb0a9ae9ee247ca19739b005f198901fd540"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\David\Desktop\COMPSCI 711 A1\Cache\Views\_ViewImports.cshtml"
using Cache;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\David\Desktop\COMPSCI 711 A1\Cache\Views\_ViewImports.cshtml"
using Cache.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"800acb0a9ae9ee247ca19739b005f198901fd540", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b605ccb347b94bbe8784383053e755ec6e225985", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\David\Desktop\COMPSCI 711 A1\Cache\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"" style=""font-family:verdana;font-weight:bold;color:black"">Cache</h1>
    <button id=""updateServer"" onclick=""updateServer()"">Update Server/Cache</button>
    <button id=""refreshCache"" onclick=""refreshCache()"">Refresh Cache View</button>
    <button id=""refreshCache"" onclick=""clearCache()"">Clear Cache</button>
    <button id=""refreshCache"" onclick=""clearCacheLog()"">Clear Cache Log</button>
    <div class=""component-7-2-0qmmjz"" id=""component-7-2"" style=""font-size: 24px; font-family: verdana; font-weight: bold; color: black; padding: 35px; padding-right: 30px; border: 10px solid #000000;"">
        <p>Cache Log</p>
        <p id=""randImage4"" style=""font-size: 16px; font-weight: normal; height: 200px; overflow: auto; word-wrap: break-word;text-align:left"" />
    </div>
    <div class=""component-7-2-0qmmjz"" id=""component-7-2"" style=""font-size: 24px; font-family: verdana; font-weight: bold; color: black; padding: 35px; padding-right: 30px; border: 10px so");
            WriteLiteral(@"lid #353535; "">
        <p>Items on Server</p>
        <p id=""randImage"" style=""font-size: 16px; font-weight: normal; text-align: left "" />
    </div>
    <div class=""component-7-2-0qmmjz"" id=""component-7-2"" style=""font-size: 24px; font-family: verdana; font-weight: bold; color: black; padding: 35px; padding-right: 30px; border: 10px solid #686868; "">
        <p>Items on Cache</p>
        <p id=""randImage2"" style=""font-size: 16px; font-weight: normal; text-align: left "" />
    </div>
    <div class=""component-7-2-0qmmjz"" id=""component-7-2"" style=""font-size: 24px; font-family: verdana; font-weight: bold; color: black; padding: 35px; padding-right: 30px; border: 10px solid #9C9C9C; "">
        <p>Cache Data Inspection</p>
        <p id=""randImage3"" style=""font-size: 16px; font-weight: normal; height: 500px; overflow: auto; word-wrap: break-word; text-align: left"" />
    </div>
    <script>

        let currentInspection = """";

        const itemsOnServer = [];
        let itemsOnServerText = """";");
            WriteLiteral(@"

        const itemsOnCache = [];
        let itemsOnCacheText = """";

        const itemsOnCacheLog = [];
        let itemsOnCacheLogText = """";

        (function runForever() {
            itemsOnServerText = """";
            itemsOnServer.forEach(setServerItem);
            document.getElementById(""randImage"").innerHTML = itemsOnServerText;

            itemsOnCacheText = """";
            itemsOnCache.forEach(setCacheItem);
            document.getElementById(""randImage2"").innerHTML = itemsOnCacheText;

            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    while (itemsOnCacheLog.length > 0) {
                        itemsOnCacheLog.pop();
                    }
                    var ret = this.responseText.split(';').slice(0, -1);
                    ret.forEach(element => itemsOnCacheLog.push(element));
                }
            };
            xht");
            WriteLiteral(@"tp.open(""GET"", ""https://localhost:44349/api/GetAllEvents/"", true);
            xhttp.send();

            itemsOnCacheLogText = """";
            itemsOnCacheLog.forEach(setCacheLogItem);
            document.getElementById(""randImage4"").innerHTML = itemsOnCacheLogText;
            setTimeout(runForever, 1000)
        })()

        function setServerItem(value) {
            var ret = value.split(',').slice(0, -1);
            itemsOnServerText = itemsOnServerText + `<p id=${ret[0]}>Filename: ${ret[0]}, Size in Chunks: ${ret[1]}</p><br>`;
        }

        function setCacheItem(value) {
            var ret = value.split(',').slice(0, -1);
            itemsOnCacheText = itemsOnCacheText + `<p>Filename: ${ret[0]}, File Downloaded: ${((ret[2] / ret[1]) * 100).toFixed(2)}%, Time Downloaded: ${ret[3]} <button onclick='checkChunks(""${ret[0]},${ret[2]},"")'>Inspect</button></p><br>`;
        }

        function setCacheLogItem(value) {
            itemsOnCacheLogText = itemsOnCacheLogText + value +");
            WriteLiteral(@" ""<br>"";
        }

        function checkChunks(value) {
            let temp = """";
            var ret = value.split(',').slice(0, -1);
            currentInspection = ret[0];
            for (let i = 0; i < ret[1]; i++) {
                temp = temp + `<div id=""${i}"">Block: ${i} <button onclick=""getChunk(${i})"">Open Data</button></div><br>`
            }
            document.getElementById(""randImage3"").innerHTML = temp;
        }

        function getChunk(value) {
            document.getElementById(value).innerHTML = """";
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    document.getElementById(value).innerHTML = base64ToHex(this.responseText) + `<br><button onclick=""closeChunk(${value})"">Close Data</button>`;
                }
            };
            xhttp.open(""GET"", ""https://localhost:44349/api/GetData/"" + currentInspection + "","" + value, true);");
            WriteLiteral(@"
            xhttp.send();
        }

        function closeChunk(value) {
            document.getElementById(value).innerHTML = `Block: ${value} <button onclick=""getChunk(${value})"">Open Data</button>`;
        }

        function updateServer() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    refreshCache();
                }
            };
            document.getElementById(""randImage"").innerHTML = """";
            xhttp.open(""GET"", ""https://localhost:44349/api/RefreshCache/"", true);
            xhttp.send();
        }

        function base64ToHex(str) {
            const raw = atob(str);
            let result = '';
            for (let i = 0; i < raw.length; i++) {
                const hex = raw.charCodeAt(i).toString(16);
                result += (hex.length === 2 ? hex : '0' + hex);
            }
            return result.toUpperCase();");
            WriteLiteral(@"
        }

        function refreshCache() {
            while (itemsOnServer.length > 0) {
                itemsOnServer.pop();
            }

            while (itemsOnCache.length > 0) {
                itemsOnCache.pop();
            }

            document.getElementById(""randImage3"").innerHTML = """";

            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var ret = this.responseText.split(';').slice(0, -1);
                    ret.forEach(serverCheck);
                }
            };
            document.getElementById(""randImage"").innerHTML = """";
            xhttp.open(""GET"", ""https://localhost:44349/api/UpdateCache/"", true);
            xhttp.send();
        }

        function serverCheck(value) {
            var ret = value.split(',').slice(0, -1);
            if (ret[2] > 0) {
                itemsOnCache.push(value);
            }
       ");
            WriteLiteral(@"     itemsOnServer.push(value);
        }

        refreshCache();

        function clearCache() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    refreshCache();
                }
            };
            xhttp.open(""GET"", ""https://localhost:44349/api/ClearCache/"", true);
            xhttp.send();
        }

        function clearCacheLog() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {

                }
            };
            xhttp.open(""GET"", ""https://localhost:44349/api/ClearCacheLog/"", true);
            xhttp.send();
        }

    </script>
</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
