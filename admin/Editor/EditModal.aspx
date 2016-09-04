<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditModal.aspx.cs" Inherits="admin_Editor_EditModal" %>

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
    <script src="../admin/vendors/modernizr-2.6.2-respond-1.1.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
            function CancelEdit() {
                GetRadWindow().close();
            }

        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
                 <h3>Вопрос</h3>
            <div role="form">
                <div class="form-group">
                   
                    <asp:TextBox ID="Vorpos" runat="server" Width="100%" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" DeleteCommand="DELETE FROM otveti
WHERE        (id = @id)"
                InsertCommand="INSERT INTO otveti
                         (otvet, vernyj, ID_voprosy)
VALUES        (@otvet,@vernyj,@ID_voprosy)"
                SelectCommand="SELECT otvet, vernyj, id FROM otveti WHERE (ID_voprosy = @ID_voprosy)" UpdateCommand="UPDATE       otveti
SET                otvet = @otvet, vernyj = @vernyj
WHERE        (id = @id)">
                <DeleteParameters>
                    <asp:Parameter Name="id" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="otvet" />
                    <asp:Parameter Name="vernyj" />
                    <asp:Parameter Name="ID_voprosy" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="id_voprosy" QueryStringField="id_voprosy" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="otvet" />
                    <asp:Parameter Name="vernyj" />
                    <asp:Parameter Name="id" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <hr/>
            <h3>Ответы</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="100%" CssClass="table" GridLines="None">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="otvet" HeaderText="Ответ" SortExpression="otvet" />
                    <asp:BoundField DataField="vernyj" HeaderText="Верный" SortExpression="vernyj" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="False" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="Button1" runat="server" Text="Добавить ответ" CssClass="btn" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="form-group has-warning" Visible="False">
                <div class="form-group has-warning">
                    <div class="form-inline" role="form">
                        <div class="form-group">
                            <label for="TextBox1">Ответ</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="CheckBox1">Верный</label>
                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-control" />
                        </div>
                        <asp:Button ID="SaveNew" runat="server" Text="Добавить" OnClick="SaveNew_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Отмена" OnClick="Button2_Click" />

                        

                    </div>

                </div>
            </asp:Panel>
            <hr/>
            <asp:Button ID="Save" CssClass="btn btn-primary" runat="server" Text="Сохранить и закрыть" OnClick="Save_Click" />
            <asp:Button ID="Close" runat="server" CssClass="btn" Text="Отмена" OnClick="Close_Click" />
        </div>
    </form>
</body>
</html>
