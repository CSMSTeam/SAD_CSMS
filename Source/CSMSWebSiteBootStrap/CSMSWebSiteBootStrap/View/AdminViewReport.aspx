<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewReport.aspx.cs" Inherits="CSMSWebSiteBootStrap.View.AdminViewReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Report</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="shortcut icon" href="images/icons/favicon.ico" />
    <link rel="apple-touch-icon" href="images/icons/favicon.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="images/icons/favicon-72x72.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/icons/favicon-114x114.png" />
    <!--Loading bootstrap css-->
    <link href="../styles/all.css" rel="stylesheet" />
    <link href="../styles/main.css" rel="stylesheet" />
    <link href="../styles/style-responsive.css" rel="stylesheet" />
    <link href="../styles/zabuto_calendar.min.css" rel="stylesheet" />
    <link href="../styles/pace.css" rel="stylesheet" />
    <link href="../styles/jquery.news-ticker.css" rel="stylesheet" />
    <link href="../styles/font-awesome.min.css" rel="stylesheet" />
    <link href="../styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../styles/nestable.css" rel="stylesheet" />
    <link href="../styles/jplist-custom.css" rel="stylesheet" />
    <link href="../styles/introjs.css" rel="stylesheet" />
    <link href="../styles/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />
    <link href="../styles/animate.css" rel="stylesheet" />
    <link href="../styles/private.css" rel="stylesheet" />
    <script src="../Resource/ajaxjs/jquery.min.js"></script>
    <script src="../Resource/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <!--BEGIN BACK TO TOP-->
            <a id="totop" href="#"><i class="fa fa-angle-up"></i></a>
            <!--END BACK TO TOP-->
            <!--BEGIN TOPBAR-->
            <div id="header-topbar-option-demo" class="page-header-topbar">
                <nav id="topbar" role="navigation" style="margin-bottom: 0;" data-step="3" class="navbar navbar-default navbar-static-top">
                    <div class="navbar-header">
                        <button type="button" data-toggle="collapse" data-target=".sidebar-collapse" class="navbar-toggle"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                        <a id="logo" href="index.html" class="navbar-brand"><span class="fa fa-rocket"></span><span class="logo-text">CocShop</span><span style="display: none" class="logo-text-icon">µ</span></a>
                    </div>
                    <div class="topbar-main">
                        <a id="menu-toggle" href="#" class="hidden-xs" style="padding: 13px 20px 10px"><i class="fa fa-bars"></i></a>
                        <label class="pr-welcome">
                            Welcome to CocShop Management
                        </label>
                        <ul class="nav navbar navbar-top-links navbar-right mbn">
                            <li class="dropdown topbar-user">
                                <a data-hover="dropdown" href="#" class="dropdown-toggle">
                                    <img src="../Resource/image/me.jpg" alt="" class="img-responsive img-circle" />
                                    <span class="hidden-xs">
                                        <asp:Label Style="vertical-align: middle" ID="lblUsername" runat="server" Text=""></asp:Label>
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a style="padding: 0px" href="#">
                                    <asp:Button ID="btnLogout" runat="server" CssClass="pr-btn-logout" Text="Log Out" OnClick="btnLogout_Click" />
                                    <i style="margin: 0 0 0 -10px; vertical-align: middle;" class="fa fa-sign-out"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
            <!--END TOPBAR-->
            <div id="wrapper">
                <!--BEGIN SIDEBAR MENU-->
                <nav id="sidebar" role="navigation" data-step="2" data-intro="Template has &lt;b&gt;many navigation styles&lt;/b&gt;"
                    data-position="right" class="navbar-default navbar-static-side">
                    <div class="sidebar-collapse menu-scroll">
                        <ul id="side-menu" class="nav">
                            <div class="clearfix"></div>
                        <li><a href="ManageAcount.aspx"><i class="fa fa-th-list fa-fw">
                            <div class="icon-bg bg-blue"></div>
                        </i><span class="menu-title">Account</span></a>
                        </li>
                            <li class="active"><a href="AdminViewReport.aspx"><i class="fa fa-bar-chart-o fa-fw">
                                <div class="icon-bg bg-orange"></div>
                            </i><span class="menu-title">Report</span></a>
                        </ul>
                    </div>
                </nav>
                <div id="page-wrapper">
                    <!--BEGIN TITLE & BREADCRUMB PAGE-->
                    <div id="title-breadcrumb-option-demo" class="pr-title-content page-title-breadcrumb">
                        <div class="page-header pull-left">
                            <div class="page-title">
                                Report
                            </div>
                        </div>
                        <ol class="breadcrumb page-breadcrumb pull-right">
                            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.html">Home</a>&nbsp;&nbsp;<i class="fa fa-angle-right"></i>&nbsp;&nbsp;</li>
                            <li class="hidden"><a href="#">Report</a>&nbsp;&nbsp;<i class="fa fa-angle-right"></i>&nbsp;&nbsp;</li>
                            <li class="active">Report</li>
                        </ol>
                        <div class="clearfix">
                        </div>
                    </div>
                    <!--END TITLE & BREADCRUMB PAGE-->
                    <!--BEGIN CONTENT-->
                    <div class="page-content">
                        <div id="tab-general">
                            <div class="row mbl">
                                <div class="col-lg-12">

                                    <div class="col-md-12">
                                        <div id="area-chart-spline" style="width: 100%; height: 300px; display: none;">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="row">
                                        <!-- Update/Delete Modal Dialog -->
                                        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="modal-body">
                                                            <!--Table Order Detail -->
                                                            <div class="col-lg-12">
                                                                <div class="panel panel-yellow">
                                                                    <div class="panel-heading">
                                                                        Report
                                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <table class="table table-hover">
                                                                            <asp:GridView ID="grvOrderDetail" runat="server" class="table table-bordered"
                                                                                AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="orderid" HeaderText="Order ID" HtmlEncode="true" />
                                                                                    <asp:BoundField DataField="productid" HeaderText="Product ID" HtmlEncode="true" />
                                                                                    <asp:BoundField DataField="productname" HeaderText="Product Name" HtmlEncode="true" />
                                                                                    <asp:BoundField DataField="quantity" HeaderText="Quantity" HtmlEncode="true" />
                                                                                    <asp:BoundField DataField="unitprice" HeaderText="Price" HtmlEncode="true" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                            <strong>
                                                                                <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label></strong>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--End Table Order Detail -->
                                                        </div>
                                                        <div class="modal-footer">
                                                            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn btn-info" data-dismiss="modal" aria-hidden="true" />
                                                        </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- End model -->
                                        <!--Table Order Pending -->
                                        <div class="col-lg-12">
                                            <div class="panel panel-yellow">
                                                <div class="panel-heading">Report</div>
                                                <div class="panel-body">
                                                    <table class="table table-hover">
                                                        <asp:GridView ID="grvReport" runat="server" class="table table-bordered"
                                                            AutoGenerateColumns="false" AllowPaging="true" PageSize="20" OnSelectedIndexChanged="grvReport_SelectedIndexChanged">
                                                            <Columns>
                                                                <asp:BoundField DataField="orderid" HeaderText="ID" HtmlEncode="true" />
                                                                <asp:BoundField DataField="empname" HeaderText="Employee" HtmlEncode="true" />
                                                                <asp:BoundField DataField="orderdate" HeaderText="Time" HtmlEncode="true" />
                                                                <asp:BoundField DataField="total" HeaderText="Total" HtmlEncode="true" />
                                                                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" ControlStyle-CssClass="btn-primary" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <!--End Table Order Pending -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--END CONTENT-->
                <!--BEGIN FOOTER-->
                <div id="footer">
                </div>
                <!--END FOOTER-->
            </div>
            <!--END PAGE WRAPPER-->
        </div>
        <script src="script/jquery-1.10.2.min.js"></script>
        <script src="script/jquery-migrate-1.2.1.min.js"></script>
        <script src="script/jquery-ui.js"></script>
        <script src="script/bootstrap.min.js"></script>
        <script src="script/bootstrap-hover-dropdown.js"></script>
        <script src="script/html5shiv.js"></script>
        <script src="script/respond.min.js"></script>
        <script src="script/jquery.metisMenu.js"></script>
        <script src="script/jquery.slimscroll.js"></script>
        <script src="script/jquery.cookie.js"></script>
        <script src="script/icheck.min.js"></script>
        <script src="script/custom.min.js"></script>
        <script src="script/jquery.news-ticker.js"></script>
        <script src="script/jquery.menu.js"></script>
        <script src="script/pace.min.js"></script>
        <script src="script/holder.js"></script>
        <script src="script/responsive-tabs.js"></script>
        <script src="script/jquery.flot.js"></script>
        <script src="script/jquery.flot.categories.js"></script>
        <script src="script/jquery.flot.pie.js"></script>
        <script src="script/jquery.flot.tooltip.js"></script>
        <script src="script/jquery.flot.resize.js"></script>
        <script src="script/jquery.flot.fillbetween.js"></script>
        <script src="script/jquery.flot.stack.js"></script>
        <script src="script/jquery.flot.spline.js"></script>
        <script src="script/zabuto_calendar.min.js"></script>
        <script src="script/index.js"></script>
        <!--LOADING SCRIPTS FOR CHARTS-->
        <script src="script/highcharts.js"></script>
        <script src="script/data.js"></script>
        <script src="script/drilldown.js"></script>
        <script src="script/exporting.js"></script>
        <script src="script/highcharts-more.js"></script>
        <script src="script/charts-highchart-pie.js"></script>
        <script src="script/charts-highchart-more.js"></script>
        <!--CORE JAVASCRIPT-->
        <script src="script/main.js"></script>
        <script>        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
            a = s.createElement(o),
            m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
            ga('create', 'UA-145464-12', 'auto');
            ga('send', 'pageview');


        </script>
    </form>
</body>
</html>
