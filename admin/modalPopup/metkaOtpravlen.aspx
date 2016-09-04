<%@ Page Language="C#" AutoEventWireup="true" CodeFile="metkaOtpravlen.aspx.cs" Inherits="admin_modalPopup_metkaOtpravlen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="/admin/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" media="screen">
    <link href="/admin/vendors/easypiechart/jquery.easy-pie-chart.css" rel="stylesheet" media="screen">
    <link href="/admin/assets/styles.css" rel="stylesheet" media="screen">
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script src="/admin/assets/scripts.js"></script>
    <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->
    <script src="vendors/modernizr-2.6.2-respond-1.1.0.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <fieldset>
                    <legend>ID теста (список)</legend>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Отметить" OnClick="Button1_Click" CssClass="btn" />
                    <br />
                    <br />
                    <div class="alert alert-success alert-block" runat="server" id="notif" Visible="False">
                        <a class="close" data-dismiss="alert" href="#">×</a>
                        <h4 class="alert-heading">Успех!</h4>
                        <asp:Label ID="Text" runat="server" Text=""></asp:Label>
                    </div>
                </fieldset>
            </div>
           
        </div>
    </form>
</body>
</html>
