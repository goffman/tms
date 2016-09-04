<%@ Page Language="C#" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="admin_users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Логин
        <asp:TextBox ID="TextBox1" runat="server" Width="40%"></asp:TextBox>
        <br />
        Пароль
        <asp:TextBox ID="TextBox2" runat="server" Width="40%"></asp:TextBox>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="dolzhnost" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [dolzhnost], [ID] FROM [dolzhnost]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
