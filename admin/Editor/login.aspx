<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_Editor_login" MasterPageFile="../Editor.master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    Авторизация <br />  <br />
 Логин:    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
 
 Пароль:   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Вход" CssClass="btn btn-primary" OnClick="Button1_Click" />
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
</asp:Content>

