<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moderator.aspx.cs" Inherits="admin_users_moderator" MasterPageFile="../Admin.master" Title="Модерация регистрации" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="alert alert-success" id="alert" runat="server" visible="False">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4>
            <asp:Label ID="AlertTitle" runat="server" Text=""></asp:Label></h4>
        <asp:Label ID="AlertText" runat="server" Text=""></asp:Label>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function RowSelected(sender, args) {

                var IDAccountSelected = document.getElementById("<%= IDAccount.ClientID %>");
                var Fam = document.getElementById("<%= F.ClientID %>");
                var Im = document.getElementById("<%= I.ClientID %>");
                var Ot = document.getElementById("<%= O.ClientID %>");
                IDAccountSelected.value = args.getDataKeyValue("ID");
                Im.value = args.getDataKeyValue("I");
                Fam.value = args.getDataKeyValue("F");
                Ot.value = args.getDataKeyValue("O");
            }





        </script>
    </telerik:RadCodeBlock>

    <div class="row-fluid">
        <div class="block">
            <div class="navbar navbar-inner block-header">
                <div class="muted pull-left">Фамилия человека</div>
            </div>
            <div class="block-content collapse in">
                <div class="form-inline" style="z-index: -999;">
                    <telerik:RadAjaxPanel runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" AllowFilteringByColumn="True" AllowSorting="True" AllowPaging="True" Skin="Metro" Culture="ru-RU" CellSpacing="-1" GridLines="Both">
                            <GroupingSettings CaseSensitive="false"></GroupingSettings>
                            <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ID,F,I,O" NoMasterRecordsText="Нет записей">
                                <Columns>

                                    <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" HeaderText="ID" SortExpression="ID" UniqueName="ID" AutoPostBackOnFilter="true" FilterControlWidth="100%" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="F" HeaderText="Фамилия" SortExpression="F" UniqueName="F" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100px">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="I" FilterControlAltText="Filter I column" HeaderText="Имя" SortExpression="I" UniqueName="I" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100px">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="O" FilterControlAltText="Filter O column" HeaderText="Отчество" SortExpression="O" UniqueName="O" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100px">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="lpu" FilterControlAltText="Filter lpu column" HeaderText="Мо" SortExpression="lpu" UniqueName="lpu" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100%">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="gruppa" FilterControlAltText="Filter gruppa column" HeaderText="Группа" SortExpression="gruppa" UniqueName="gruppa" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100%">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="dolzhnost" FilterControlAltText="Filter dolzhnost column" HeaderText="Должность" SortExpression="dolzhnost" UniqueName="dolzhnost" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100%">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="stazh" FilterControlAltText="Filter stazh column" HeaderText="Стаж" SortExpression="stazh" UniqueName="stazh" DataType="System.Int32" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100%">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter UserName column" HeaderText="Имя пользователя" SortExpression="UserName" UniqueName="UserName" AutoPostBackOnFilter="true" FilterDelay="500" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="100%">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>

                                    <telerik:GridDateTimeColumn DataField="date_reg" HeaderText="Дата регистрации" FilterControlWidth="110px"
                                        SortExpression="date_reg" PickerType="DatePicker" EnableTimeIndependentFiltering="true"
                                        DataFormatString="{0:MM/dd/yyyy}">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridDateTimeColumn>


                                </Columns>
                            </MasterTableView>
                            <ExportSettings>
                                <Pdf PageWidth="">
                                </Pdf>
                            </ExportSettings>
                            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                <Selecting AllowRowSelect="true" />
                                <ClientEvents OnRowSelected="RowSelected" />
                                <Scrolling AllowScroll="True" EnableVirtualScrollPaging="True" FrozenColumnsCount="20" />
                                <Animation AllowColumnReorderAnimation="True" AllowColumnRevertAnimation="True" />
                            </ClientSettings>
                            <HeaderStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Top" />
                        </telerik:RadGrid>
                    </telerik:RadAjaxPanel>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [l-kabinet].ID, [l-kabinet].F, [l-kabinet].I, [l-kabinet].O, lpu.lpu, gruppa_dolzhnost.gruppa, dolzhnost.dolzhnost, [l-kabinet].stazh, users.UserName, users.date_reg FROM lpu INNER JOIN users INNER JOIN [l-kabinet] ON users.ID_l_kabinet = [l-kabinet].ID ON lpu.ID = [l-kabinet].ID_lpu INNER JOIN dolzhnost INNER JOIN gruppa_dolzhnost ON dolzhnost.gruppa = gruppa_dolzhnost.ID ON [l-kabinet].ID_dolzhnost = dolzhnost.ID WHERE (users.Moderacija = 0) AND ([l-kabinet].on_delete = 0) ORDER BY users.date_reg DESC"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="F" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="I" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="O" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>

    <asp:HiddenField runat="server" ID="IDAccount" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>

    <div class="navbar">
        <div class="navbar-inner navbar-fixed-bottom">
            <ul class="nav">
                <li>
                    <asp:LinkButton ID="Approve" runat="server" OnClientClick="return confirm('Вы точно хотите одобрить пользователя?');" OnClick="Approve_Click"><i class="icon-ok" ></i> Одобрить</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="Block" runat="server" PostBackUrl="#BlockUsers" data-toggle="modal" data-target="#BlockUsers"><i class="icon-remove"></i> Заблокировать</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="BlockUsersRemove" runat="server" PostBackUrl="#BlockUsersAndRemove" data-toggle="modal" data-target="#BlockUsersAndRemove" OnClick="BlockUsersRemove_Click"><i class="icon-remove"></i> Заблокировать и удалить</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>

    <%--  Модальные окна "Блокировка пользователя"--%>
    <div class="modal fade" id="BlockUsers" tabindex="-1" role="dialog" aria-labelledby="ChangeSpecialty" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Блокировка пользователя</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="BlockText" runat="server" Rows="3" Width="97%" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
                    <asp:Button ID="BlockButton" runat="server" Text="Изменить" CssClass="btn btn-primary" OnClick="BlockButton_Click" />

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="BlockUsersAndRemove" tabindex="-1" role="dialog" aria-labelledby="ChangeSpecialty" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Блокировка и удаление пользователя</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="BlockUsersAndRemoveText" runat="server" Rows="3" Width="97%" TextMode="MultiLine"></asp:TextBox>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
                    <asp:Button ID="BlockUsersAndRemoveButton" runat="server" Text="Изменить" CssClass="btn btn-primary" OnClick="BlockUsersAndRemoveButton_Click" />

                </div>
            </div>
        </div>
    </div>
    <%--   Конец--%>
</asp:Content>




