<%@ Page Language="C#" AutoEventWireup="true" CodeFile="removeResult.aspx.cs" Inherits="admin_users_modal_removeResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="/admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="/admin/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" media="screen">
    
    <script>
        
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function TagRomove() {
            var ReasonRemoved = document.getElementById("<%= ReasonsRemovalTests.ClientID %>");
            ReasonRemoved.value = "Согласно письму МЗ № от ";

        function returnToParent(t, m) {
            //create the argument that will be returned to the parent page
            var oArg = new Object();

            //get a reference to the current RadWindow
            var oWnd = GetRadWindow();

            oArg.title = t;
            oArg.ms = m;


            //Close the RadWindow and send the argument to the parent page
            if (oArg.title && oArg.ms) {
                oWnd.close(oArg);
            }
            else {
                alert("Please fill both fields");
            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Причина аннулирование теста
                    
                    <asp:TextBox ID="ReasonsRemovalTests" runat="server" Width="97%" Rows="3"></asp:TextBox>
                    <a href="javascript:void(0)" onclick="TagRomove()">Приказ МЗ</a>
                    <br />
                    <br />
                    <telerik:RadCaptcha ID="RadCaptcha1" runat="server" CaptchaTextBoxLabel="Введите код с картинки"></telerik:RadCaptcha>

    </div>
    </form>
</body>
</html>
