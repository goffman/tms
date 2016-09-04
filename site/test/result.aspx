<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="site_result" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <p class="text-center">&nbsp;Вы завершили тест и правильно ответили на:</p>
    <br />
    <p class="text-center">
        <span>

            <asp:Label ID="result" runat="server" Text="100%" CssClass="btn btn-success" Font-Size="XX-Large"></asp:Label>

        </span>

    </p>
    <br />
    <div class="text-center">
        <asp:Label ID="ResultTestText" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div id="info" runat="server" visible="False" class="text-info">
        Согласно пункта 25 <a href="http://docs.pravo.ru/document/view/45143850/51451949/">Приказа Министерства здравоохранения РФ от 23 апреля 2013 г. N 240н
"О Порядке и сроках прохождения медицинскими работниками и фармацевтическими работниками аттестации для получения квалификационной категории"</a>: Тестовый контроль знаний предусматривает выполнение специалистом тестовых заданий и признается пройденным при условии успешного выполнения не менее 70% общего объема тестовых заданий.
    </div>
    <p class="text">
        Результаты автоматически отправляются в Министерство здравоохранения Республики Хакасия и на указанный при регистрации электронный адрес.
       
    </p>
    <br />

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="SidebarContent">
    <asp:HyperLink ID="HyperLink1" runat="server">На главную</asp:HyperLink>
</asp:Content>


