#pragma checksum "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aae27cb8676209d93638694178769b98a65fec34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_ShowComment), @"mvc.1.0.view", @"/Views/Course/ShowComment.cshtml")]
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
#line 1 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
using TopLearn.Core.Convertors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
using TopLearn.DataLayer.Entities.Course;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aae27cb8676209d93638694178769b98a65fec34", @"/Views/Course/ShowComment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_ShowComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<TopLearn.DataLayer.Entities.Course.CourseComment>, int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
 foreach (var item in Model.Item1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- row -->\r\n    <div class=\"comment-row\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 282, "\"", 321, 2);
            WriteAttributeValue("", 288, "/UserAvatar/", 288, 12, true);
#nullable restore
#line 13 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
WriteAttributeValue("", 300, item.User.UserAvatar, 300, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"left-col\">\r\n            <h3> ");
#nullable restore
#line 15 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
            Write(item.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n            <span>");
#nullable restore
#line 16 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
             Write(item.CreateDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <p>\r\n                ");
#nullable restore
#line 18 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
           Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <!-- /row -->\r\n");
#nullable restore
#line 23 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<nav aria-label=\"Page navigation\">\r\n    <ul class=\"pagination justify-content-center\">\r\n\r\n");
#nullable restore
#line 28 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
         for (int i = 1 ; i <= Model.Item2 ; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("onclick", " onclick=\"", 779, "\"", 804, 3);
            WriteAttributeValue("", 789, "pageComment(", 789, 12, true);
#nullable restore
#line 30 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
WriteAttributeValue("", 801, i, 801, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 803, ")", 803, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 30 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 31 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Course\ShowComment.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </ul>\r\n</nav>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<TopLearn.DataLayer.Entities.Course.CourseComment>, int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
