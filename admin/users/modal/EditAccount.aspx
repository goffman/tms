<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="admin_users_modal_EditAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <br />
            <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label" for="inputEmail">Фамилия</label>
                    <div class="controls">
                        <asp:TextBox ID="F" runat="server"></asp:TextBox>

                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">Имя</label>
                    <div class="controls">
                        <asp:TextBox ID="I" runat="server"></asp:TextBox>

                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">Отчество</label>
                    <div class="controls">
                        <asp:TextBox ID="O" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">Стаж</label>
                    <div class="controls">
                        <asp:TextBox ID="Sazh" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                 <div class="control-group">
                    <label class="control-label" for="inputPassword">ЛПУ</label>
                    <div class="controls">
                        <asp:TextBox ID="LPU" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                 <div class="control-group">
                    <label class="control-label" for="inputPassword">Электронный адрес</label>
                    <div class="controls">
                        <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                 <div class="control-group">
                    <label class="control-label" for="inputPassword">Телефон</label>
                    <div class="controls">
                        <asp:TextBox ID="telefon" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                 
                <div class="control-group">
                    <div class="controls">
                        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="returnToParent('Отмена','Действие отменино'); return false;">Закрыть</button>
                    <asp:Button ID="ChangeSpecialtyButton" runat="server" Text="Изменить" CssClass="btn btn-primary" OnClick="ChangeSpecialtyButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
