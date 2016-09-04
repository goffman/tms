<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changeSpecialty.aspx.cs" Inherits="admin_users_modal_changeSpecialty" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="container">
     <h4 class="modal-title" id="myModalLabel">Изменении специальности</h4>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [gruppa_dolzhnost]"></asp:SqlDataSource>
          <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [ID], [dolzhnost] FROM [dolzhnost] WHERE ([gruppa] = @gruppa)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropChangeGroup" DefaultValue="0" Name="gruppa" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
            <asp:DropDownList ID="DropChangeGroup" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="gruppa" DataValueField="ID" Width="100%"></asp:DropDownList> <br/>
                        <asp:DropDownList ID="DropChangeSpec" runat="server" CssClass="form-control" DataSourceID="SqlDataSource3" DataTextField="dolzhnost" DataValueField="ID" Width="100%"></asp:DropDownList>
                    </telerik:RadAjaxPanel>
        <div class="center">
                    <telerik:RadCaptcha ID="ChangeSpecialtyCaptcha" runat="server" CaptchaTextBoxLabel="Введите код с картинки"></telerik:RadCaptcha>
            </div>
        
          <button type="button" class="btn btn-default" data-dismiss="modal" onclick="returnToParent('Отмена','Действие отменино'); return false;">Закрыть</button>
                    <asp:Button ID="ChangeSpecialtyButton" runat="server" Text="Изменить" CssClass="btn btn-primary" OnClick="ChangeSpecialtyButton_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
