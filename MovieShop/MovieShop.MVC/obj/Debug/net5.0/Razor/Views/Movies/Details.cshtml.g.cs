#pragma checksum "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e57bbb5b1607dfd1701ae45dc0f47dcbe6b1ef65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e57bbb5b1607dfd1701ae45dc0f47dcbe6b1ef65", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.Response.MovieDetailsResponseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("badge badge-pill badge-dark ml-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Genre", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"bg-image\"");
            BeginWriteAttribute("style", " style=\"", 89, "\"", 144, 4);
            WriteAttributeValue("", 97, "background-image:", 97, 17, true);
            WriteAttributeValue(" ", 114, "url(", 115, 5, true);
#nullable restore
#line 3 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 119, Model.Movie.BackdropUrl, 119, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 143, ")", 143, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3 offset-2\">\r\n\r\n            <!-- Movie Card row -->\r\n            <div>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 292, "\"", 320, 1);
#nullable restore
#line 10 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 298, Model.Movie.PosterUrl, 298, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" />\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <div class=\"row mt-2\">\r\n                <div class=\"col-12\">\r\n                    <h1 class=\"text-white\">\r\n                        ");
#nullable restore
#line 18 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.Movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                    <small class=\"text-muted\"> ");
#nullable restore
#line 20 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                          Write(Model.Movie.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </small>\r\n                </div>\r\n\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-4 text-secondary font-weight-bold mt-2\">\r\n                    ");
#nullable restore
#line 27 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Movie.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m | ");
#nullable restore
#line 27 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                        Write(Model.Movie.ReleaseDate.Value.Date.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-8\">\r\n\r\n");
#nullable restore
#line 31 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                     foreach (var genre in Model.Genres)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e57bbb5b1607dfd1701ae45dc0f47dcbe6b1ef656978", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 34 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                       Write(genre.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                                                         WriteLiteral(genre.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 36 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-4 mt-3\">\r\n                    <h4>\r\n                        <span class=\"badge badge-warning\">\r\n                            ");
#nullable restore
#line 44 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                       Write(Model.Movie.Rating?.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </h4>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-12 text-light mt-2\">\r\n                    ");
#nullable restore
#line 52 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Movie.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
        </div>

        <div class=""col-md-2 mt-4 offset-1"">
            <ul class=""list-group"">
                <li class=""list-group-item"">


                </li>
                <li class=""list-group-item"">
                    <button type=""button""
                            class=""btn btn-outline-light btn-lg btn-block btn-sm"">
                        <i class=""far fa-edit mr-1""></i>
                        REVIEW
                    </button>
                </li>
                <li class=""list-group-item"">
                    <button type=""button""
                            class=""btn btn-outline-light btn-lg btn-block btn-sm"">
                        <i class=""fas fa-play mr-1""></i> TRAILER
                    </button>
                </li>

                <li class=""list-group-item"">
                    <a class=""btn btn-light btn-lg btn-block btn-sm"">
                        BUY ");
#nullable restore
#line 79 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                       Write(Model.Movie.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </a>

                    <a class=""btn btn-light btn-lg btn-block btn-sm"">
                        WATCH MOVIE
                    </a>
                </li>
            </ul>
        </div>

    </div>
</div>


<div class=""row mt-4"">
    <div class=""col-4 moviefacts"">
        <h5>MOVIE FACTS</h5>
        <hr>
        <ul class=""list-group list-group-flush"">
            <li class=""list-group-item"">
                <i class=""far fa-calendar-alt mr-2""></i>Release Date
                <span class=""badge badge-pill badge-dark"">");
#nullable restore
#line 100 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                     Write(Model.Movie.ReleaseDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </li>\r\n\r\n            <li class=\"list-group-item\">\r\n                <i class=\"fas fa-hourglass-half mr-2\"></i>Run Time\r\n                <span class=\"badge badge-pill badge-dark\">");
#nullable restore
#line 105 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                     Write(Model.Movie.RunTime.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m</span>\r\n            </li>\r\n            <li class=\"list-group-item\">\r\n                <i class=\"far fa-money-bill-alt\"></i> Box Office\r\n                <span class=\"badge badge-pill badge-pill badge-dark\">\r\n                    ");
#nullable restore
#line 110 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Movie.Revenue?.ToString("C0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </span>\r\n            </li>\r\n\r\n            <li class=\"list-group-item\">\r\n                <i class=\"fas fa-dollar-sign mr-2\"></i> Budget\r\n                <span class=\"badge badge-pill badge-dark\">\r\n                    ");
#nullable restore
#line 117 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Movie.Budget?.ToString("C0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </span>\r\n            </li>\r\n\r\n            <li class=\"list-group-item\">\r\n                <i class=\"fab fa-imdb\"></i>\r\n\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 4311, "\"", 4338, 1);
#nullable restore
#line 124 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 4318, Model.Movie.ImdbUrl, 4318, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                   class=""text-dark ml-3""
                   target=""_blank"">
                    <i class=""fas fa-share-square mr-2""></i>
                </a>
            </li>

        </ul>
    </div>

    <div class=""col-4 offset-1"">
        <h5>CAST</h5>

        <table class=""table"">

            <tbody>


");
#nullable restore
#line 142 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                 foreach (var cast in Model?.Casts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 4832, "\"", 4855, 1);
#nullable restore
#line 146 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 4838, cast.ProfilePath, 4838, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                 class=\"rounded-circle cast-small-img\"");
            BeginWriteAttribute("alt", "\r\n                                 alt=\"", 4928, "\"", 4978, 1);
#nullable restore
#line 148 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 4968, cast.Name, 4968, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                        <td> ");
#nullable restore
#line 150 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                        Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td> ");
#nullable restore
#line 151 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                        Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 153 "D:\Job\(2)Antra-FullStack\HW\AntraGit\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.Response.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
