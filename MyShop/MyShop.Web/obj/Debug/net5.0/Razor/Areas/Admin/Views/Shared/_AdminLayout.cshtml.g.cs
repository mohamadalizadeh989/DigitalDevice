#pragma checksum "G:\AspNetCor\MyShop\MyShop\MyShop.Web\Areas\Admin\Views\Shared\_AdminLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b54cd4e4810b6d20cf07247c6ade48c897e1b02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__AdminLayout), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_AdminLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b54cd4e4810b6d20cf07247c6ade48c897e1b02", @"/Areas/Admin/Views/Shared/_AdminLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__AdminLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition skin-blue sidebar-mini"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b54cd4e4810b6d20cf07247c6ade48c897e1b023923", async() => {
                WriteLiteral("\n    <meta charset=\"utf-8\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n    <title>");
#nullable restore
#line 7 "G:\AspNetCor\MyShop\MyShop\MyShop.Web\Areas\Admin\Views\Shared\_AdminLayout.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"">
    <!-- Bootstrap 3.3.7 -->
    <link rel=""stylesheet"" href=""/admin/dist/css/bootstrap-theme.css"">
    <!-- Bootstrap rtl -->
    <link rel=""stylesheet"" href=""/admin/dist/css/rtl.css"">
    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""/admin/bower_components/font-awesome/css/font-awesome.min.css"">
    <!-- Ionicons -->
    <link rel=""stylesheet"" href=""/admin/bower_components/Ionicons/css/ionicons.min.css"">
    <!-- jvectormap -->
    <link rel=""stylesheet"" href=""/admin/bower_components/jvectormap/jquery-jvectormap.css"">
    <!-- Theme style -->
    <link rel=""stylesheet"" href=""/admin/dist/css/AdminLTE.css"">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel=""stylesheet"" href=""/admin/dist/css/skins/_all-skins.min.css"">

    ");
#nullable restore
#line 26 "G:\AspNetCor\MyShop\MyShop\MyShop.Web\Areas\Admin\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("Styles", false));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src=""https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js""></script>
    <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
    <![endif]-->
    <!-- Google Font -->
    <link rel=""stylesheet""
          href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"">
    <!-- customize adminlte -->
    <link rel=""stylesheet"" href=""/admin/dist/css/customize-adminlte.css"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b54cd4e4810b6d20cf07247c6ade48c897e1b027171", async() => {
                WriteLiteral(@"
    <div class=""wrapper"">

        <header class=""main-header"">
            <!-- Logo -->
            
            <!-- Header Navbar: style can be found in header.less -->
            <nav class=""navbar navbar-static-top"">
                <!-- Sidebar toggle button-->
                <a href=""#"" class=""sidebar-toggle"" data-toggle=""push-menu"" role=""button"">
                    <span class=""sr-only"">Toggle navigation</span>
                </a>

                <div class=""navbar-custom-menu"">
                    <ul class=""nav navbar-nav"">
                        <!-- Messages: style can be found in dropdown.less-->
                        <li class=""dropdown messages-menu"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
                                <i class=""fa fa-envelope-o""></i>
                                <span class=""label label-success"">4</span>
                            </a>
                            <ul class=""dropdown-menu"">
                       ");
                WriteLiteral(@"         <li class=""header"">۴ پیام خوانده نشده</li>
                                <li>
                                    <!-- inner menu: contains the actual data -->
                                    <ul class=""menu"">
                                        <li>
                                            <!-- start message -->
                                            <a href=""#"">
                                                <div class=""pull-right"">
                                                    <img src=""/admin/dist/img/user2-160x160.jpg"" class=""img-circle"" alt=""User Image"">
                                                </div>
                                                <h4>
                                                    علیرضا
                                                    <small><i class=""fa fa-clock-o""></i> ۵ دقیقه پیش</small>
                                                </h4>
                                                <p>متن پیام</p>
                             ");
                WriteLiteral(@"               </a>
                                        </li>
                                        <!-- end message -->
                                        <li>
                                            <a href=""#"">
                                                <div class=""pull-right"">
                                                    <img src=""/admin/dist/img/user3-128x128.jpg"" class=""img-circle"" alt=""User Image"">
                                                </div>
                                                <h4>
                                                    نگین
                                                    <small><i class=""fa fa-clock-o""></i> ۲ ساعت پیش</small>
                                                </h4>
                                                <p>متن پیام</p>
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
");
                WriteLiteral(@"                                                <div class=""pull-right"">
                                                    <img src=""/admin/img/user4-128x128.jpg"" class=""img-circle"" alt=""User Image"">
                                                </div>
                                                <h4>
                                                    نسترن
                                                    <small><i class=""fa fa-clock-o""></i> امروز</small>
                                                </h4>
                                                <p>متن پیام</p>
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <div class=""pull-right"">
                                                    <img src=""/admin/img/user3-128x128.jpg"" class=""img-circle"" alt=""User Image"">
                                    ");
                WriteLiteral(@"            </div>
                                                <h4>
                                                    نگین
                                                    <small><i class=""fa fa-clock-o""></i> دیروز</small>
                                                </h4>
                                                <p>متن پیام</p>
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <div class=""pull-right"">
                                                    <img src=""/admin/img/user4-128x128.jpg"" class=""img-circle"" alt=""User Image"">
                                                </div>
                                                <h4>
                                                    نسترن
                                                    <small><i class=""fa fa-clock-o""></i> ۲ روز پیش</small>
  ");
                WriteLiteral(@"                                              </h4>
                                                <p>متن پیام</p>
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                <li class=""footer""><a href=""#"">نمایش تمام پیام ها</a></li>
                            </ul>
                        </li>
                        <!-- Notifications: style can be found in dropdown.less -->
                        <li class=""dropdown notifications-menu"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
                                <i class=""fa fa-bell-o""></i>
                                <span class=""label label-warning"">۱۰</span>
                            </a>
                            <ul class=""dropdown-menu"">
                                <li class=""header"">۱۰ اعلان جدید</li>
                                <li>
         ");
                WriteLiteral(@"                           <!-- inner menu: contains the actual data -->
                                    <ul class=""menu"">
                                        <li>
                                            <a href=""#"">
                                                <i class=""fa fa-users text-aqua""></i> ۵ کاربر جدید ثبت نام کردند
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fa fa-warning text-yellow""></i> اخطار دقت کنید
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fa fa-users text-red""></i> ۴ کاربر جدید ثبت نام کردند
                                            </a>
                      ");
                WriteLiteral(@"                  </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fa fa-shopping-cart text-green""></i> ۲۵ سفارش جدید
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fa fa-user text-red""></i> نام کاربریتان را تغییر دادید
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                <li class=""footer""><a href=""#"">نمایش همه</a></li>
                            </ul>
                        </li>
                        <!-- Tasks: style can be found in dropdown.less -->
                        <li class=""dropdown tasks-menu"">
                         ");
                WriteLiteral(@"   <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
                                <i class=""fa fa-flag-o""></i>
                                <span class=""label label-danger"">۹</span>
                            </a>
                            <ul class=""dropdown-menu"">
                                <li class=""header"">۹ کار برای انجام دارید</li>
                                <li>
                                    <!-- inner menu: contains the actual data -->
                                    <ul class=""menu"">
                                        <li>
                                            <!-- Task item -->
                                            <a href=""#"">
                                                <h3>
                                                    ساخت دکمه
                                                    <small class=""pull-left"">20%</small>
                                                </h3>
                                                <div class=""pro");
                WriteLiteral(@"gress xs"">
                                                    <div class=""progress-bar progress-bar-aqua"" style=""width: 20%"" role=""progressbar""
                                                         aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"">
                                                        <span class=""sr-only"">20% تکمیل شده</span>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <!-- end task item -->
                                        <li>
                                            <!-- Task item -->
                                            <a href=""#"">
                                                <h3>
                                                    ساخت قالب جدید
                                                    <small class=""pull-left"">40%</small>
                   ");
                WriteLiteral(@"                             </h3>
                                                <div class=""progress xs"">
                                                    <div class=""progress-bar progress-bar-green"" style=""width: 40%"" role=""progressbar""
                                                         aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"">
                                                        <span class=""sr-only"">40% تکمیل شده</span>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <!-- end task item -->
                                        <li>
                                            <!-- Task item -->
                                            <a href=""#"">
                                                <h3>
                                                    تبلیغات
                ");
                WriteLiteral(@"                                    <small class=""pull-left"">60%</small>
                                                </h3>
                                                <div class=""progress xs"">
                                                    <div class=""progress-bar progress-bar-red"" style=""width: 60%"" role=""progressbar""
                                                         aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"">
                                                        <span class=""sr-only"">60% تکمیل شده</span>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <!-- end task item -->
                                        <li>
                                            <!-- Task item -->
                                            <a href=""#"">
                                       ");
                WriteLiteral(@"         <h3>
                                                    ساخت صفحه فرود
                                                    <small class=""pull-left"">80%</small>
                                                </h3>
                                                <div class=""progress xs"">
                                                    <div class=""progress-bar progress-bar-yellow"" style=""width: 80%"" role=""progressbar""
                                                         aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100"">
                                                        <span class=""sr-only"">80% تکمیل شده</span>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <!-- end task item -->
                                    </ul>
                                </li>
                        ");
                WriteLiteral(@"        <li class=""footer"">
                                    <a href=""#"">نمایش همه</a>
                                </li>
                            </ul>
                        </li>
                        <!-- User Account: style can be found in dropdown.less -->
                        <li class=""dropdown user user-menu"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
                                <img src=""/admin/img/user2-160x160.jpg"" class=""user-image"" alt=""User Image"">
                                <span class=""hidden-xs"">علیرضا حسینی زاده</span>
                            </a>
                            <ul class=""dropdown-menu"">
                                <!-- User image -->
                                <li class=""user-header"">
                                    <img src=""/admin/img/user2-160x160.jpg"" class=""img-circle"" alt=""User Image"">

                                    <p>
                                        علیرضا حسینی زاده
 ");
                WriteLiteral(@"                                       <small>مدیریت کل سایت</small>
                                    </p>
                                </li>
                                <!-- Menu Body -->
                                <li class=""user-body"">
                                    <div class=""row"">
                                        <div class=""col-xs-4 text-center"">
                                            <a href=""#"">صفحه من</a>
                                        </div>
                                        <div class=""col-xs-4 text-center"">
                                            <a href=""#"">فروش</a>
                                        </div>
                                        <div class=""col-xs-4 text-center"">
                                            <a href=""#"">دوستان</a>
                                        </div>
                                    </div>
                                    <!-- /.row -->
                                </li>
                  ");
                WriteLiteral(@"              <!-- Menu Footer-->
                                <li class=""user-footer"">
                                    <div class=""pull-right"">
                                        <a href=""#"" class=""btn btn-default btn-flat"">پروفایل</a>
                                    </div>
                                    <div class=""pull-left"">
                                        <a href=""#"" class=""btn btn-default btn-flat"">خروج</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <!-- Control Sidebar Toggle Button -->
                        <li>
                            <a href=""#"" data-toggle=""control-sidebar""><i class=""fa fa-gears""></i></a>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <!-- right side column. contains the logo and sidebar -->
        <!-- Content Wrapper. Contains page content -->
 ");
                WriteLiteral("       ");
#nullable restore
#line 309 "G:\AspNetCor\MyShop\MyShop\MyShop.Web\Areas\Admin\Views\Shared\_AdminLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <!-- /.content-wrapper -->
        <footer class=""main-footer text-left"">
            <strong>
                Copyleft &copy; 2021-2022 <a href=""https://alizadeh.com"">Alizzzz</a> & <a href=""http://alizadeh.ir"">Mohammad Alizadeh</a>
            </strong>
        </footer>

        <!-- Control Sidebar -->
        <aside class=""control-sidebar control-sidebar-dark"">
            <!-- Create the tabs -->
            <ul class=""nav nav-tabs nav-justified control-sidebar-tabs"">
                <li><a href=""#control-sidebar-home-tab"" data-toggle=""tab""><i class=""fa fa-home""></i></a></li>
                <li><a href=""#control-sidebar-settings-tab"" data-toggle=""tab""><i class=""fa fa-gears""></i></a></li>
            </ul>
            <!-- Tab panes -->
            <div class=""tab-content"">
                <!-- Home tab content -->
                <div class=""tab-pane"" id=""control-sidebar-home-tab"">
                    <h3 class=""control-sidebar-heading"">فعالیت ها</h3>
                    <ul class=""control-side");
                WriteLiteral(@"bar-menu"">
                        <li>
                            <a href=""javascript:void(0)"">
                                <i class=""menu-icon fa fa-birthday-cake bg-red""></i>

                                <div class=""menu-info"">
                                    <h4 class=""control-sidebar-subheading"">تولد غلوم</h4>

                                    <p>۲۴ مرداد</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href=""javascript:void(0)"">
                                <i class=""menu-icon fa fa-user bg-yellow""></i>

                                <div class=""menu-info"">
                                    <h4 class=""control-sidebar-subheading"">آپدیت پروفایل سجاد</h4>

                                    <p>تلفن جدید (800)555-1234</p>
                                </div>
                            </a>
                        </li>
                        <li>
                  ");
                WriteLiteral(@"          <a href=""javascript:void(0)"">
                                <i class=""menu-icon fa fa-envelope-o bg-light-blue""></i>

                                <div class=""menu-info"">
                                    <h4 class=""control-sidebar-subheading"">نورا به خبرنامه پیوست</h4>

                                    <p>nora@example.com</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href=""javascript:void(0)"">
                                <i class=""menu-icon fa fa-file-code-o bg-green""></i>

                                <div class=""menu-info"">
                                    <h4 class=""control-sidebar-subheading"">کرون جابز اجرا شد</h4>

                                    <p>۵ ثانیه پیش</p>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!-- /.control-sidebar-menu -->

         ");
                WriteLiteral(@"           <h3 class=""control-sidebar-heading"">پیشرفت کارها</h3>
                    <ul class=""control-sidebar-menu"">
                        <li>
                            <a href=""javascript:void(0)"">
                                <h4 class=""control-sidebar-subheading"">
                                    ساخت پوستر های تبلیغاتی
                                    <span class=""label label-danger pull-left"">70%</span>
                                </h4>

                                <div class=""progress progress-xxs"">
                                    <div class=""progress-bar progress-bar-danger"" style=""width: 70%""></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href=""javascript:void(0)"">
                                <h4 class=""control-sidebar-subheading"">
                                    آپدیت رزومه
                                    <span class=""label label-success pul");
                WriteLiteral(@"l-left"">95%</span>
                                </h4>

                                <div class=""progress progress-xxs"">
                                    <div class=""progress-bar progress-bar-success"" style=""width: 95%""></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href=""javascript:void(0)"">
                                <h4 class=""control-sidebar-subheading"">
                                    آپدیت لاراول
                                    <span class=""label label-warning pull-left"">50%</span>
                                </h4>

                                <div class=""progress progress-xxs"">
                                    <div class=""progress-bar progress-bar-warning"" style=""width: 50%""></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href=""java");
                WriteLiteral(@"script:void(0)"">
                                <h4 class=""control-sidebar-subheading"">
                                    بخش پشتیبانی سایت
                                    <span class=""label label-primary pull-left"">68%</span>
                                </h4>

                                <div class=""progress progress-xxs"">
                                    <div class=""progress-bar progress-bar-primary"" style=""width: 68%""></div>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!-- /.control-sidebar-menu -->

                </div>
                <!-- /.tab-pane -->
                <!-- Stats tab content -->
                <div class=""tab-pane"" id=""control-sidebar-stats-tab"">وضعیت</div>
                <!-- /.tab-pane -->
                <!-- Settings tab content -->
                <div class=""tab-pane"" id=""control-sidebar-settings-tab"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b54cd4e4810b6d20cf07247c6ade48c897e1b0231339", async() => {
                    WriteLiteral(@"
                        <h3 class=""control-sidebar-heading"">تنظیمات عمومی</h3>

                        <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                گزارش کنترلر پنل
                                <input type=""checkbox"" class=""pull-left"" checked>
                            </label>

                            <p>
                                ثبت تمامی فعالیت های مدیران
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                ایمیل مارکتینگ
                                <input type=""checkbox"" class=""pull-left"" checked>
                            </label>

                            <p>
                                اجازه به کاربران برای ارسال ایمیل
                            </p>
                        </div>
  ");
                    WriteLiteral(@"                      <!-- /.form-group -->

                        <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                در دست تعمیرات
                                <input type=""checkbox"" class=""pull-left"" checked>
                            </label>

                            <p>
                                قرار دادن سایت در حالت در دست تعمیرات
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <h3 class=""control-sidebar-heading"">تنظیمات گفتگوها</h3>

                        <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                آنلاین بودن من را نشان نده
                                <input type=""checkbox"" class=""pull-left"" checked>
                            </label>
                        </div>
                        <!-- /.form-group -->

                     ");
                    WriteLiteral(@"   <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                اعلان ها
                                <input type=""checkbox"" class=""pull-left"">
                            </label>
                        </div>
                        <!-- /.form-group -->

                        <div class=""form-group"">
                            <label class=""control-sidebar-subheading"">
                                حذف تاریخته گفتگوهای من
                                <a href=""javascript:void(0)"" class=""text-red pull-left""><i class=""fa fa-trash-o""></i></a>
                            </label>
                        </div>
                        <!-- /.form-group -->
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <!-- /.tab-pane -->
            </div>
        </aside>
        <!-- /.control-sidebar -->
        <!-- Add the sidebar's background. This div must be placed
           immediately after the control sidebar -->
        <div class=""control-sidebar-bg""></div>
    </div>
    <!-- ./wrapper -->
    <!-- jQuery 3 -->
    <script src=""/admin/bower_components/jquery/dist/jquery.min.js""></script>
    <!-- Bootstrap 3.3.7 -->
    <script src=""/admin/bower_components/bootstrap/dist/js/bootstrap.min.js""></script>
    <!-- FastClick -->
    <script src=""/admin/bower_components/fastclick/lib/fastclick.js""></script>
    <!-- AdminLTE App -->
    <script src=""/admin/dist/js/adminlte.min.js""></script>
    <!-- Sparkline -->
    <script src=""/admin/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js""></script>
    <!-- jvectormap  -->
    <script src=""/admin/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js""></script>
    <script src=""/admin/plugins/jvectormap/jquery-jvectorm");
                WriteLiteral(@"ap-world-mill-en.js""></script>
    <!-- SlimScroll -->
    <script src=""/admin/bower_components/jquery-slimscroll/jquery.slimscroll.min.js""></script>
    <!-- ChartJS -->
    <script src=""/admin/bower_components/chart.js/Chart.js""></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src=""/admin/dist/js/pages/dashboard2.js""></script>
    <!-- AdminLTE for demo purposes -->
    <script src=""/admin/dist/js/demo.js""></script>

    ");
#nullable restore
#line 534 "G:\AspNetCor\MyShop\MyShop\MyShop.Web\Areas\Admin\Views\Shared\_AdminLayout.cshtml"
Write(await RenderSectionAsync("Scripts", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>");
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
