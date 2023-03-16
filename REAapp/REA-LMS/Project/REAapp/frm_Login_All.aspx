<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Login_All.aspx.cs" Inherits="frm_Login_All" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Welcom to REA</title>
    <link type="text/css" href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link type="text/css" href="bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link type="text/css" href="css/theme.css" rel="stylesheet">
    <link type="text/css" href="images/icons/css/font-awesome.css" rel="stylesheet">
    <link type="text/css" href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600'
        rel='stylesheet'>
</head>
<body>
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner" style="background-image:url(images/Back.png");">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-inverse-collapse">
                    <i class="icon-reorder shaded"></i></a>
                <div class="nav-collapse collapse navbar-inverse-collapse">
                <img src="images/Headers.png" height="30px" />
                    <ul class="nav pull-right">
                        
                        <li><a href="#">Forgot your password? </a></li>
                    </ul>
                </div>
                <!-- /.nav-collapse -->
            </div>
        </div>
        <!-- /navbar-inner -->
    </div>
    <!-- /navbar -->
    <div class="wrapper">
        <div class="container">
            <div class="row">
                <div class="module module-login span4 offset4">
                    <form class="form-vertical" runat="server">
                    <div class="module-head">
                        <h3>
                            Sign In</h3>
                    </div>
                    <div class="module-body">
                        <div id="divmsg" runat="server">
                            <button type="button" class="close" data-dismiss="alert">
                                &times;</button>
                            <strong>
                                <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                        </div>
                        <div class="control-group">
                            <div class="controls row-fluid">
                                <asp:TextBox ID="txt_UserName" runat="server" CssClass="span12" placeholder="Username"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls row-fluid">
                                <asp:TextBox ID="txt_UserPassword" runat="server" TextMode="Password" CssClass="span12"
                                    placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="module-foot">
                        <div class="control-group">
                            <div class="controls clearfix">
                                <asp:Button ID="btn_Login" runat="server" CssClass="btn btn-primary pull-right" Text="Login"
                                    OnClick="btn_Login_Click" />
                                <label class="checkbox">
                                    <input type="checkbox">
                                    Remember me
                                </label>
                            </div>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!--/.wrapper-->

  <div class="footer">
        <div class="container">
        <center>
            <b class="copyright">&copy; 2015, Royal Educational Academy. All rights reserved. </b> Site Developed by mmR
            </center>
            
            
        </div>
    </div>    <script src="scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
