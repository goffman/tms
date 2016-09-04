<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="admin_users_search" Title="Аттестуемые" MasterPageFile="mz.master"  %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <script>
  $('#RemoveResultTest').modal({
   
      backdrop:true
        })
    </script>
 <%--   Модальные окна--%>

    <%--  Обнуление результатов тестирования--%>
  <%--  <div class="modal fade" id="RemoveResultTest" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="z-index: 99999999">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Обнуление результатов тестирования</h4>
                </div>
                <div class="modal-body">
                    Причина аннулирование теста
                    
                    <asp:TextBox ID="ReasonsRemovalTests" runat="server" Width="97%" Rows="3"></asp:TextBox>
                    <a href="javascript:void(0)" onclick="TagRomove()">Приказ МЗ</a>
                    <br />
                    <br />
                    <telerik:RadCaptcha ID="RadCaptcha1" runat="server" CaptchaTextBoxLabel="Введите код с картинки"></telerik:RadCaptcha>

                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
                    <asp:Button ID="SaveRemoveResult" runat="server" OnClick="OK_Click" Text="Обнулить" CssClass="btn btn-primary" />

                </div>
            </div>
        </div>
    </div>--%>



    <%--    Метка "На удаление"--%>
  <%--  <div class="modal fade" id="BlackList" tabindex="-1" role="dialog" aria-labelledby="BlackList" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Заблокировать учетную запись</h4>
                </div>
                <div class="modal-body">
                    <h3>Причина</h3>
                    <asp:DropDownList ID="DropDownListBlockReasons" runat="server" Width="100%" DataSourceID="GuideBlockReasons" AppendDataBoundItems="True" DataTextField="Reasons" DataValueField="Reasons">
                        <asp:ListItem Selected="True" Value="" Text=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="GuideBlockReasons" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [GuideBlockReasons]"></asp:SqlDataSource>
                    <h3>Произвольный текст</h3>
                    <asp:TextBox ID="BlockPrichina" runat="server" TextMode="MultiLine" Width="97%" Rows="2"></asp:TextBox>

                    <telerik:RadCaptcha ID="RadCaptcha2" runat="server" CaptchaTextBoxLabel="Введите код с картинки"></telerik:RadCaptcha>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
                    <asp:Button ID="BlackListButton" runat="server" Text="Заблокировать" CssClass="btn btn-primary" OnClick="BlackListButton_Click" />

                </div>
            </div>
        </div>
    </div>--%>

    <%--    Изменении специальности--%>
  <%--  <div class="modal fade" id="ChangeSpecialty" tabindex="-1" role="dialog" aria-labelledby="ChangeSpecialty" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Изменении специальности</h4>
                </div>
                <div class="modal-body">
                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                        <asp:DropDownList ID="DropChangeGroup" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="gruppa" DataValueField="ID"></asp:DropDownList>
                        <asp:DropDownList ID="DropChangeSpec" runat="server" DataSourceID="SqlDataSource3" DataTextField="dolzhnost" DataValueField="ID"></asp:DropDownList>
                    </telerik:RadAjaxPanel>

                    <telerik:RadCaptcha ID="ChangeSpecialtyCaptcha" runat="server" CaptchaTextBoxLabel="Введите код с картинки"></telerik:RadCaptcha>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
                    <asp:Button ID="ChangeSpecialtyButton" runat="server" Text="Изменить" CssClass="btn btn-primary" OnClick="ChangeSpecialtyButton_Click" />

                </div>
            </div>
        </div>
    </div>--%>


    <%--Конец модальных окон--%>
    <div class="alert alert-success" id="alert" runat="server" visible="False">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4>
            <asp:Label ID="AlertTitle" runat="server" Text=""></asp:Label></h4>
        <asp:Label ID="AlertText" runat="server" Text=""></asp:Label>
    </div>

    <script type="text/javascript" language="javascript">
        function OnConfirm() {
            if (confirm('Удалить запись?')) return true;
            return false;
        }
    </script>

  <%--  <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function RowSelected(sender, args) {
                var UserNameSelected = document.getElementById("<%= UserName.ClientID %>");
                var IDAccountSelected = document.getElementById("<%= IDAccount.ClientID %>");
                var telefonSelected = document.getElementById("<%= telefon.ClientID %>");
                var emailSelected = document.getElementById("<%= email.ClientID %>");
                var Fam = document.getElementById("<%= F.ClientID %>");
                var Im = document.getElementById("<%= I.ClientID %>");
                var Ot = document.getElementById("<%= O.ClientID %>");
                telefonSelected.value = args.getDataKeyValue("telefon");
                UserNameSelected.value = args.getDataKeyValue("UserName");
                IDAccountSelected.value = args.getDataKeyValue("ID");
                emailSelected.value = args.getDataKeyValue("email");
                Im.value = args.getDataKeyValue("I");
                Fam.value = args.getDataKeyValue("F");
                Ot.value = args.getDataKeyValue("O");
            }

            function TagRomove() {
                var ReasonRemoved = document.getElementById("<%= ReasonsRemovalTests.ClientID %>");
                ReasonRemoved.value = "Согласно письму МЗ № от ";

            }



        </script>
    </telerik:RadCodeBlock>--%>



    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


    <asp:Panel ID="Panel1" runat="server">
        <div class="row-fluid">


            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">Фамилия человека</div>
                </div>
                <div class="block-content collapse in">
                    <div class="form-inline" style="z-index: -999;">
                        <asp:TextBox ID="SearchTextBox" CssClass="span12" runat="server" OnTextChanged="SearchTextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </div>
                </div>
            </div>



            <!-- block -->

            <!-- /block -->


            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">Результат</div>
                </div>
                <div class="block-content collapse in">
                    <telerik:RadGrid ID="RadGrid1" runat="server" Culture="ru-RU" DataSourceID="SqlDataSource2" AllowSorting="True" AllowPaging="True" AllowMultiRowEdit="True" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" CellSpacing="-1" Skin="MetroTouch">
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource2"  GroupLoadMode="Client" NoMasterRecordsText="Нет записей" DataKeyNames="ID" HierarchyLoadMode="Client">
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
                                <telerik:GridBoundColumn DataField="rezultat" DataType="System.Int32" FilterControlAltText="Filter rezultat column" HeaderText="Результат" SortExpression="rezultat" UniqueName="rezultat">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Процент" DataType="System.Decimal" FilterControlAltText="Filter Процент column" HeaderText="Процент" SortExpression="Процент" UniqueName="Процент" ReadOnly="True">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="data" FilterControlAltText="Filter data column" HeaderText="Дата" SortExpression="data" UniqueName="data" DataType="System.DateTime">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column" HeaderText="Статус" SortExpression="status" UniqueName="status" ReadOnly="True">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="gruppa" FilterControlAltText="Filter gruppa column" HeaderText="Группа" SortExpression="gruppa" UniqueName="gruppa" ReadOnly="True">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="proba_test" FilterControlAltText="Filter proba_test column" HeaderText="Пробное" SortExpression="proba_test" UniqueName="proba_test" ReadOnly="True">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="on_delete" FilterControlAltText="Filter on_delete column" HeaderText="Блокирован" ReadOnly="True" SortExpression="on_delete" UniqueName="on_delete">
                                    <ColumnValidationSettings>
                                        <ModelErrorMessage Text="" />
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="otpravlen" FilterControlAltText="Filter otpravlen column" HeaderText="Отправлен в МЗ" ReadOnly="True" SortExpression="otpravlen" UniqueName="otpravlen">
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
                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                            <Selecting AllowRowSelect="true" />
                            <ClientEvents OnRowSelected="RowSelected" />
                        </ClientSettings>
                        <HeaderStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Top" />
                    </telerik:RadGrid>
                </div>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        [l-kabinet].ID, [l-kabinet].F, [l-kabinet].I, [l-kabinet].O, dolzhnost.dolzhnost, lpu.lpu, prohozhdenie_testa.rezultat, prohozhdenie_testa.data, ROUND(CONVERT(money, 
                         prohozhdenie_testa.rezultat) / 70 * 100, 0) AS Процент, 
                         CASE WHEN [l-kabinet].proba_test = 0 THEN N'Не пройдено' WHEN [l-kabinet].proba_test = 1 THEN N'Пройдено' END AS proba_test, 
                         CASE WHEN [l-kabinet].on_delete = 0 THEN N'' WHEN [l-kabinet].on_delete = 1 THEN N'Да' END AS on_delete, 
                         CASE WHEN prohozhdenie_testa.status = 1 THEN N'Завершено' END AS status, CASE WHEN prohozhdenie_testa.otpravlen = 1 THEN N'Да' END AS otpravlen, 
						  CASE WHEN  dolzhnost.gruppa = 5 THEN N'Средний МП' WHEN dolzhnost.gruppa = 3 THEN N'Врачи' END AS gruppa
                        
FROM            [l-kabinet] INNER JOIN
                         dolzhnost ON [l-kabinet].ID_dolzhnost = dolzhnost.ID LEFT OUTER JOIN
                         prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj INNER JOIN
                         lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                         users ON [l-kabinet].ID = users.ID_l_kabinet
 WHERE ([l-kabinet].F LIKE @FIO)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="FIO" />
                    </SelectParameters>
                </asp:SqlDataSource>







            </div>

        </div>

    </asp:Panel>

<%--    <asp:Panel ID="Panel3" runat="server" Visible="False">

        <asp:Button ID="OK" runat="server" Text="Сбросить" OnClick="OK_Click" />

        <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Отмена" />

    </asp:Panel>--%>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
    </telerik:RadWindowManager>
   <%-- <asp:HiddenField runat="server" ID="UserName" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="F" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="I" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="O" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>

    <asp:HiddenField runat="server" ID="IDAccount" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>

    <asp:HiddenField runat="server" ID="telefon" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>

    <asp:HiddenField runat="server" ID="email" OnValueChanged="Unnamed1_ValueChanged"></asp:HiddenField>--%>

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="300px">
        <telerik:RadNotification ID="RadNotification1" runat="server" Position="Center"
            Width="330" Height="130" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
            Style="z-index: 35000" Skin="MetroTouch">
        </telerik:RadNotification>
    </telerik:RadAjaxPanel>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>


    

<%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [gruppa_dolzhnost]"></asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [ID], [dolzhnost] FROM [dolzhnost] WHERE ([gruppa] = @gruppa)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropChangeGroup" DefaultValue="0" Name="gruppa" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>--%>


   <%-- <div class="navbar">
        <div class="navbar-inner navbar-fixed-bottom">
            <ul class="nav">
                <li>
                    <asp:LinkButton ID="parol" runat="server" OnClick="parol_Click" OnClientClick="return confirm('Вы точно хотите изменить пароль?');"><i class="icon-eye-close" ></i> Изменить пароль</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="result" runat="server" OnClick="result_Click" OnClientClick="return confirm('Вы точно хотите пересчитать результаты?');"><i class="icon-refresh"></i> Пересчитать результаты</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="dellresult" runat="server" PostBackUrl="#RemoveResultTest" data-toggle="modal" data-target="#RemoveResultTest"><i class="icon-remove-circle" ></i> Обнулить результаты</asp:LinkButton>
                </li>
                <li class="dropdown">

                    <a href="#" data-toggle="dropdown" class="dropdown-toggle"><i class="icon-warning-sign"></i>Блокировка <b class="caret"></b>

                    </a>
                    <ul class="dropdown-menu" id="menu1">
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="#BlackList" data-toggle="modal" data-target="#BlackList"><i class="icon-fire"></i> Заблокировать </asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton2_Click" OnClientClick="return confirm('Вы точно хотите снять блокировку?');"> <i class="icon-leaf"></i>Снять блокировку</asp:LinkButton>
                        </li>
                    </ul>
                </li>

                <li></li>
                <li>
                    <asp:LinkButton ID="ChangeSpec" runat="server" PostBackUrl="#ChangeSpecialty" data-toggle="modal" data-target="#ChangeSpecialty"><i class="icon-briefcase"></i> Изменить специальность</asp:LinkButton>

                </li>

            </ul>
        </div>
    </div>--%>


</asp:Content>




