#pragma checksum "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0716ae94872e7fcb4d621236be68b76decdfd1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CourseGroupComponent_CourseGroup), @"mvc.1.0.view", @"/Views/Shared/Components/CourseGroupComponent/CourseGroup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0716ae94872e7fcb4d621236be68b76decdfd1a", @"/Views/Shared/Components/CourseGroupComponent/CourseGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CourseGroupComponent_CourseGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TopLearn.DataLayer.Entities.Course.CourseGroup>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"main-menu\">\r\n    <div class=\"container\">\r\n        <nav>\r\n            <span class=\"responsive-sign\"><i class=\"zmdi zmdi-menu\"></i></span>\r\n            <ul>\r\n");
#nullable restore
#line 7 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                 foreach (var group in Model.Where(g => g.ParentId == null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 385, "\"", 429, 2);
            WriteAttributeValue("", 392, "/Course?selectedGroups=", 392, 23, true);
#nullable restore
#line 10 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
WriteAttributeValue("", 415, group.GroupId, 415, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 10 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                                                    Write(group.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n");
#nullable restore
#line 11 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                         if (Model.Any(g => g.ParentId == group.GroupId))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n");
#nullable restore
#line 14 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                 foreach (var sub in Model.Where(g => g.ParentId == group.GroupId))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li><a");
            BeginWriteAttribute("href", " href=\"", 770, "\"", 812, 2);
            WriteAttributeValue("", 777, "/Course?selectedGroups=", 777, 23, true);
#nullable restore
#line 16 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
WriteAttributeValue("", 800, sub.GroupId, 800, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 16 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                                                                  Write(sub.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></li>\r\n");
#nullable restore
#line 17 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 19 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 21 "D:\C#\TopLearn\TopLearn\Toplearn.Web\Views\Shared\Components\CourseGroupComponent\CourseGroup.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ul>\r\n        </nav>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TopLearn.DataLayer.Entities.Course.CourseGroup>> Html { get; private set; }
    }
}
#pragma warning restore 1591
