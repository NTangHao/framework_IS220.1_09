#pragma checksum "F:\HTTT tren framework\demomysql\demomysql\Views\Shared\Sidebar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9847fd9b43d16baa35abad7ca1a5f7ca785dd842"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Sidebar), @"mvc.1.0.view", @"/Views/Shared/Sidebar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9847fd9b43d16baa35abad7ca1a5f7ca785dd842", @"/Views/Shared/Sidebar.cshtml")]
    public class Views_Shared_Sidebar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/d2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/d1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/d4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/d5.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/d3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"side-bar col-md-3\">\r\n    <div class=\"search-hotel\">\r\n        <h3 class=\"agileits-sear-head\">Search Here..</h3>\r\n        <form action=\"#\" method=\"post\">\r\n            <input type=\"search\" placeholder=\"Product name...\" name=\"search\"");
            BeginWriteAttribute("required", " required=\"", 367, "\"", 378, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <input type=""submit"" value="" "">
        </form>
    </div>
    <!-- price range -->
    <div class=""range"">
        <h3 class=""agileits-sear-head"">Price range</h3>
        <ul class=""dropdown-menu6"">
            <li>

                <div id=""slider-range""></div>
                <input type=""text"" id=""amount"" style=""border: 0; color: #ffffff; font-weight: normal;"" />
            </li>
        </ul>
    </div>
    <!-- //price range -->
    <!-- food preference -->
    <div class=""left-side"">
        <h3 class=""agileits-sear-head"">Food Preference</h3>
        <ul>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Vegetarian</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Non-Vegetarian</span>
            </li>
        </ul>
    </div>
    <!-- //food preference -->
    <!-- discounts -->
    <div class=""left-side"">
        ");
            WriteLiteral(@"<h3 class=""agileits-sear-head"">Discount</h3>
        <ul>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">5% or More</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">10% or More</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">20% or More</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">30% or More</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">50% or More</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">60% or More</span>
            </li>
        </ul>
    </div>
    <!-- //discounts -->
    <!-- reviews -");
            WriteLiteral(@"->
    <div class=""customer-rev left-side"">
        <h3 class=""agileits-sear-head"">Customer Review</h3>
        <ul>
            <li>
                <a href=""#"">
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <span>5.0</span>
                </a>
            </li>
            <li>
                <a href=""#"">
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <span>4.0</span>
                </");
            WriteLiteral(@"a>
            </li>
            <li>
                <a href=""#"">
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-half-o"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <span>3.5</span>
                </a>
            </li>
            <li>
                <a href=""#"">
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <span>3.0</span>
                </a>
            </li>
            <li>
                <a href=""#"">
                ");
            WriteLiteral(@"    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-half-o"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <i class=""fa fa-star-o"" aria-hidden=""true""></i>
                    <span>2.5</span>
                </a>
            </li>
        </ul>
    </div>
    <!-- //reviews -->
    <!-- cuisine -->
    <div class=""left-side"">
        <h3 class=""agileits-sear-head"">Cuisine</h3>
        <ul>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">South American</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">French</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Greek</span>
            </li>
       ");
            WriteLiteral(@"     <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Chinese</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Japanese</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Italian</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Mexican</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Thai</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span"">Indian</span>
            </li>
            <li>
                <input type=""checkbox"" class=""checked"">
                <span class=""span""> Spanish </span>
            </li>
        </ul>
  ");
            WriteLiteral("  </div>\r\n    <!-- //cuisine -->\r\n    <!-- deals -->\r\n    <div class=\"deal-leftmk left-side\">\r\n        <h3 class=\"agileits-sear-head\">Special Deals</h3>\r\n        <div class=\"special-sec1\">\r\n            <div class=\"col-xs-4 img-deals\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9847fd9b43d16baa35abad7ca1a5f7ca785dd84211978", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-xs-8 img-deal1"">
                <h3>Lay's Potato Chips</h3>
                <a href=""single.html"">$18.00</a>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div class=""special-sec1"">
            <div class=""col-xs-4 img-deals"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9847fd9b43d16baa35abad7ca1a5f7ca785dd84213439", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-xs-8 img-deal1"">
                <h3>Bingo Mad Angles</h3>
                <a href=""single.html"">$9.00</a>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div class=""special-sec1"">
            <div class=""col-xs-4 img-deals"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9847fd9b43d16baa35abad7ca1a5f7ca785dd84214897", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-xs-8 img-deal1"">
                <h3>Tata Salt</h3>
                <a href=""single.html"">$15.00</a>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div class=""special-sec1"">
            <div class=""col-xs-4 img-deals"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9847fd9b43d16baa35abad7ca1a5f7ca785dd84216349", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-xs-8 img-deal1"">
                <h3>Gujarat Dry Fruit</h3>
                <a href=""single.html"">$525.00</a>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div class=""special-sec1"">
            <div class=""col-xs-4 img-deals"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9847fd9b43d16baa35abad7ca1a5f7ca785dd84217810", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-xs-8 img-deal1"">
                <h3>Cadbury Dairy Milk</h3>
                <a href=""single.html"">$149.00</a>
            </div>
            <div class=""clearfix""></div>
        </div>
    </div>
    <!-- //deals -->
</div>");
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