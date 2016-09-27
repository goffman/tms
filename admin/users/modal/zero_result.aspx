<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zero_result.aspx.cs" Inherits="admin_users_modal_zero_result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="/admin/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" media="screen">
    <title></title>
    <script language="javascript">
         function TagRomove() {
                var ReasonRemoved = document.getElementById("<%= ReasonsRemovalTests.ClientID %>");
                ReasonRemoved.value = "Согласно письму МЗ № от ";

         }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }


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

        <div class="container">
            <h4 class="modal-title" id="myModalLabel">Обнуление результатов тестирования</h4>
            Причина аннулирование теста
                    
                    <asp:TextBox ID="ReasonsRemovalTests" runat="server" Width="97%" Rows="3"></asp:TextBox>
             <a href="javascript:void(0)" onclick="TagRomove()">Приказ МЗ</a>
            <hr/>
             <button type="button" class="btn btn-default" data-dismiss="modal" onclick="returnToParent('Отмена','Действие отменино'); return false;">Закрыть</button>
                    <asp:Button ID="SaveRemoveResult" runat="server" OnClick="OK_Click" Text="Обнулить" CssClass="btn btn-primary" />
        </div>
    </form>
</body>
</html>
