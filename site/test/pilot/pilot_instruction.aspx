<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pilot_instruction.aspx.cs" Inherits="site_instruction" MasterPageFile="~/MasterPage.master" Title="Пробное тестирование" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <div style="text-align: center">
        <h2 id="TextTest" runat="server">Пробное тестирование состоит из 15 случайных вопросов по специальности. Цель данного теста - ознакомить пользователя с системой тестирования. Данные по результатам тестирования не сохраняются.</h2>
        <div style="text-align: left">
            Краткая инструкция<br />

            <hr />
            <ol>
              
                <li>Тест состоит из 15 случайных вопросов.</li>
                <li>Возможны вопросы с несколькими вариантами ответов.</li>
                <li>В случае возникновении ошибки, нажмите кнопку F5, либо обновите страницу. Все ответы сохраняются.</li>
            </ol>
        </div>
    </div>
    <div style="text-align: center">
        <asp:Button ID="Button1" runat="server" Text="Начать тест" CssClass="btn btn-large btn-primary" OnClick="Button1_Click" />
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="SidebarContent">
    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            naimenovanie_testa:
            <asp:TextBox ID="naimenovanie_testaTextBox" runat="server" Text='<%# Bind("naimenovanie_testa") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Обновить" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Отмена" />
        </EditItemTemplate>
        <InsertItemTemplate>
            naimenovanie_testa:
            <asp:TextBox ID="naimenovanie_testaTextBox" runat="server" Text='<%# Bind("naimenovanie_testa") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Вставка" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Отмена" />
        </InsertItemTemplate>
        <ItemTemplate>
            Специальность:<br />
            <asp:Label ID="naimenovanie_testaLabel" runat="server" Style="font-weight: 700" Text='<%# Bind("naimenovanie_testa") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [naimenovanie_testa] FROM [prohozhdenie_testa] WHERE ([ID_testiruemyj] = @ID_testiruemyj)">
        <SelectParameters>
            <asp:SessionParameter Name="ID_testiruemyj" SessionField="UserID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


