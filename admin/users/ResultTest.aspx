<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultTest.aspx.cs" Inherits="admin_users_ResultTest" MasterPageFile="~/AdminMasterPage.master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="BodyContent">
    <label class="control-label" for="UserID">ID Пользователя</label>
    <asp:TextBox ID="UserID" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="table" Width="100%">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Теста" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="ID_testiruemyj" HeaderText="ID Пользователя" SortExpression="ID_testiruemyj" />
            <asp:BoundField DataField="F" HeaderText="Фамилия" SortExpression="F" />
            <asp:BoundField DataField="I" HeaderText="Имя" SortExpression="I" />
            <asp:BoundField DataField="O" HeaderText="Отчество" SortExpression="O" />
            <asp:BoundField DataField="stazh" HeaderText="Стаж" SortExpression="stazh" />
            <asp:BoundField DataField="lpu" HeaderText="МО" SortExpression="lpu" />
            <asp:BoundField DataField="kategoria" HeaderText="Категория" SortExpression="kategoria" />
            <asp:BoundField DataField="dolzhnost" HeaderText="Должность" SortExpression="dolzhnost" />
            <asp:BoundField DataField="rezultat" HeaderText="Результат" SortExpression="rezultat" />
            <asp:BoundField DataField="data" HeaderText="Дата тестирования" SortExpression="data" />
            <asp:BoundField DataField="status" HeaderText="Статус" SortExpression="status" />
            <asp:BoundField DataField="gruppa" HeaderText="Группа" SortExpression="gruppa" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        prohozhdenie_testa.ID, prohozhdenie_testa.ID_testiruemyj, [l-kabinet].F, [l-kabinet].I, [l-kabinet].O, [l-kabinet].stazh, lpu.lpu, [l-kabinet].kategoria, 
                         dolzhnost.dolzhnost, prohozhdenie_testa.rezultat, prohozhdenie_testa.data, prohozhdenie_testa.status, gruppa_dolzhnost.gruppa
FROM            dolzhnost INNER JOIN
                         [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost INNER JOIN
                         lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                         prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj INNER JOIN
                         gruppa_dolzhnost ON dolzhnost.gruppa = gruppa_dolzhnost.ID
WHERE        (prohozhdenie_testa.ID_testiruemyj = @UserID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="UserID" DefaultValue="0" Name="UserID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CssClass="table">
        <Columns>
            <asp:BoundField DataField="ID_vopros" HeaderText="ID Вопроса" SortExpression="ID_vopros" />
            <asp:BoundField DataField="ID_otvet" HeaderText="ID Ответа" SortExpression="ID_otvet" />
            <asp:BoundField DataField="vopros" HeaderText="Вопрос" SortExpression="vopros" />
            <asp:BoundField DataField="otvet" HeaderText="Ответ" SortExpression="otvet" />
            <asp:BoundField DataField="vernyj" HeaderText="Верный" SortExpression="vernyj" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        testirovanie.ID_vopros, testirovanie.ID_otvet, voprosy.vopros, otveti.otvet, otveti.vernyj
FROM            testirovanie INNER JOIN
                         voprosy ON testirovanie.ID_vopros = voprosy.id_voprosy INNER JOIN
                         otveti ON testirovanie.ID_otvet = otveti.id
WHERE        (testirovanie.ID_testiruemyj = @UserID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="UserID" DefaultValue="0" Name="UserID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

