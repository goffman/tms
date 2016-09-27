<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search2.aspx.cs" Inherits="admin_users_search2" MasterPageFile="~/admin/Admin.master" Title="Поиск человека" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="form" style="z-index: -999;">
        <asp:TextBox ID="SearchTextBox" CssClass="span12" placeholder="Фамилия человека" runat="server" OnTextChanged="SearchTextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
    </div>
    <telerik:RadGrid ID="RadGrid1" runat="server" Font-Size="10" Culture="ru-RU" DataSourceID="SqlDataSource2" AllowSorting="True" AllowPaging="True" AllowMultiRowEdit="True" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" CellSpacing="-1" Skin="Bootstrap" RenderMode="Auto">
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
        <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource2" ClientDataKeyNames="UserName,telefon,email,ID,F,I,O" GroupLoadMode="Client" NoMasterRecordsText="Нет записей">
            <Columns>

                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="F" FilterControlAltText="Filter F column" HeaderText="Фамилия" SortExpression="F" UniqueName="F">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="I" FilterControlAltText="Filter I column" HeaderText="Имя" SortExpression="I" UniqueName="I">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="O" FilterControlAltText="Filter O column" HeaderText="Отчество" SortExpression="O" UniqueName="O">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dolzhnost" FilterControlAltText="Filter dolzhnost column" HeaderText="Должность" SortExpression="dolzhnost" UniqueName="dolzhnost">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="lpu" FilterControlAltText="Filter lpu column" HeaderText="МО" SortExpression="lpu" UniqueName="lpu">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="email" FilterControlAltText="Filter email column" HeaderText="email" SortExpression="email" UniqueName="email">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="proba_test" DataType="System.Int32" FilterControlAltText="Filter proba_test column" HeaderText="Пробный тест" SortExpression="proba_test" UniqueName="proba_test">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="telefon" FilterControlAltText="Filter telefon column" HeaderText="Телефон" SortExpression="telefon" UniqueName="telefon">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="on_delete" FilterControlAltText="Filter on_delete column" HeaderText="На удаление" SortExpression="on_delete" UniqueName="on_delete">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="rezultat" DataType="System.Int32" FilterControlAltText="Filter rezultat column" HeaderText="Результат" SortExpression="rezultat" UniqueName="rezultat">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Процент" DataType="System.Int32" FilterControlAltText="Filter Процент column" HeaderText="Процент" SortExpression="Процент" UniqueName="Процент">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="data" DataType="System.DateTime" FilterControlAltText="Filter data column" HeaderText="Дата тестирования" SortExpression="data" UniqueName="data">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="status"  FilterControlAltText="Filter status column" HeaderText="Статус" SortExpression="status" UniqueName="status">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
              
                <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter UserName column" HeaderText="Логин" SortExpression="UserName" UniqueName="UserName">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

            </Columns>
        </MasterTableView>
        <ExportSettings>
            <Pdf PageWidth="">
            </Pdf>
        </ExportSettings>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
            <ClientEvents OnRowSelected="RowSelected" />
        </ClientSettings>
        <HeaderStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Top" />
    </telerik:RadGrid>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="
       SELECT [l-kabinet].ID,
       [l-kabinet].F,
       [l-kabinet].I,
       [l-kabinet].O,
       dolzhnost.dolzhnost,
       lpu.lpu,
       [l-kabinet].email,
       [l-kabinet].telefon,
       prohozhdenie_testa.rezultat,
       prohozhdenie_testa.data,
       prohozhdenie_testa.otpravlen,
       CASE
           WHEN [l-kabinet].proba_test = 0 THEN N'Не пройдено'
           WHEN [l-kabinet].proba_test = 1 THEN N'Пройдено'
       END AS proba_test,
       CASE
           WHEN [l-kabinet].on_delete = 0 THEN N'Нет'
           WHEN [l-kabinet].on_delete = 1 THEN N'Да'
       END AS on_delete,
       CASE
           WHEN prohozhdenie_testa.status = 1 THEN N'Завершено'
           WHEN prohozhdenie_testa.status = 0 THEN N'Не завершено'
       END AS status,
       CASE
           WHEN prohozhdenie_testa.otpravlen = 1 THEN N'Да'
           WHEN prohozhdenie_testa.otpravlen = 0 THEN N'Нет'
       END AS otpravlen,
       CASE
           WHEN dolzhnost.gruppa = 5 THEN N'Средний МП'
           WHEN dolzhnost.gruppa = 3 THEN N'Врачи'
       END AS gruppa,
       ROUND(CONVERT(money, prohozhdenie_testa.rezultat) / 70 * 100, 0) AS Процент,
       users.UserName
FROM [l-kabinet]
INNER JOIN dolzhnost ON [l-kabinet].ID_dolzhnost = dolzhnost.ID
LEFT OUTER JOIN prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost
AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj
INNER JOIN lpu ON [l-kabinet].ID_lpu = lpu.ID
INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet
WHERE ([l-kabinet].F LIKE @FIO)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="FIO" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>



