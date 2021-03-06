﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="CSMSWebSiteBootStrap.View.ManageProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product</title>
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
                                    <asp:Button runat="server" CssClass="pr-btn-logout" Text="Log Out" ID="btnLogout" OnClick="btnLogout_Click" />
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
                            </li>
                        <li class="active"><a href="ManageProduct.aspx"><i class="fa fa-th-list fa-fw">
                            <div class="icon-bg bg-blue"></div>
                        </i><span class="menu-title">Product</span></a>
                        </li>
                            <li><a href="ManageCategory.aspx"><i class="fa fa-bar-chart-o fa-fw">
                                <div class="icon-bg bg-orange"></div>
                            </i><span class="menu-title">Category</span></a>
                                <li><a href="Tables.html"><i class="fa fa-bar-chart-o fa-fw">
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
                                Product
                            </div>
                        </div>
                        <ol class="breadcrumb page-breadcrumb pull-right">
                            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.html">Home</a>&nbsp;&nbsp;<i class="fa fa-angle-right"></i>&nbsp;&nbsp;</li>
                            <li class="hidden"><a href="#">Tables</a>&nbsp;&nbsp;<i class="fa fa-angle-right"></i>&nbsp;&nbsp;</li>
                            <li class="active">Product</li>
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
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                                <h4 class="modal-title">
                                                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <table align="center">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductID" runat="server" Text="ID:" CssClass="pr-dialog-label form-control-static"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtProductID" runat="server" ReadOnly="true" CssClass="pr-dialog-textbox form form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductName" runat="server" Text="Name: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblCategoryID" runat="server" Text="Category: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCategoryID" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblImportPrice" runat="server" Text="Import Price: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtImportPrice" runat="server" style="" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductQuantity" runat="server" Text="Quantity: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtProductQuantity" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductStatus" runat="server" Text="Status: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="rbtStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radio-filters pr-dialog-textbox">
                                                                                    <asp:ListItem Text="Available" Value="Available"></asp:ListItem>
                                                                                    <asp:ListItem Text="Not Available" Value="Not Available"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                            <div class="modal-footer">
                                                                </script>                                        
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" />
                                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" class="btn btn-danger" />
                                                                <asp:Button ID="btnClose" runat="server" Text="Close" class="btn btn-info" data-dismiss="modal" aria-hidden="true" />
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- End model -->
                                        <!-- New Modal Dialog -->
                                        <div class="modal fade" id="myModal1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <asp:UpdatePanel ID="upModal1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                                <h4 class="modal-title">
                                                                    <asp:Label ID="lblModalTitle1" runat="server" Text=""></asp:Label></h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <table align="center">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductName_" runat="server" Text="Name: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtProductName_" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblCategoryID_" runat="server" Text="Category: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="pr-dialog-textbox"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblImportPrice_" runat="server" Text="Import Price: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtImportPrice_" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblUnitPrice_" runat="server" Text="Unit Price: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtUnitPrice_" runat="server" CssClass="form form-control pr-dialog-textbox" ValidateRequestMode="Enabled"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductQuantity_" runat="server" Text="Quantity: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtProductQuantity_" runat="server" CssClass="form form-control pr-dialog-textbox" ValidationGroup=""></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblProductStatus_" runat="server" Text="Status: " CssClass="form-control-static pr-dialog-label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="rbtStatus_" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radio-filters pr-dialog-textbox">
                                                                                    <asp:ListItem Text="Available" Value="Available"></asp:ListItem>
                                                                                    <asp:ListItem Text="Not Available" Value="Not Available"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                            <div class="modal-footer">
                                                                </script>                                        
                                                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" class="btn btn-success" />
                                                                <asp:Button ID="btnClose1" runat="server" Text="Close" class="btn btn-info" data-dismiss="modal" aria-hidden="true" />
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <!-- End model -->
                                        <div class="col-lg-12">
                                            <div class="panel panel-yellow">
                                                <div class="panel-heading">
                                                    Product
                                                <asp:Button ID="btnShowAddDialog" runat="server" class="btn btn-success" Text="Add New" OnClick="btnShowAddDialog_Click" />
                                                </div>
                                                <div class="panel-body">
                                                    <div class="input-icon right text-white">
                                                        <a href="#"><i class="fa fa-search"></i></a>
                                                        <asp:TextBox ID="txtProductSearch" runat="server" placeholder="Search here..." class="form-control text-black"></asp:TextBox>
                                                    </div>
                                                    <asp:GridView ID="grvProduct" runat="server" class="table table-bordered" AutoGenerateColumns="false" AllowPaging="true"
                                                        PageSize="20" OnSelectedIndexChanged="grvProduct_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="productid" HeaderText="ID" HtmlEncode="true" />
                                                            <asp:BoundField DataField="productname" HeaderText="Name" HtmlEncode="true" />
                                                            <asp:BoundField DataField="categoryid" HeaderText="Category" HtmlEncode="true" />
                                                            <asp:BoundField DataField="importpirce" HeaderText="Import Price" HtmlEncode="true" />
                                                            <asp:BoundField DataField="unitprice" HeaderText="Unit Price" HtmlEncode="true" />
                                                            <asp:BoundField DataField="productquantity" HeaderText="Quantity" HtmlEncode="true" />
                                                            <asp:BoundField DataField="productstatus" HeaderText="Status" HtmlEncode="true" />
                                                            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" ControlStyle-CssClass="btn-primary" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--END CONTENT-->
                <!--BEGIN FOOTER-->
                <div id="footer">
                    <div class="copyright">
                        <a href="http://themifycloud.com">2014 © KAdmin Responsive Multi-Purpose Template</a>
                    </div>
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
