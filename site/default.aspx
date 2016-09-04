<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="suite_Default" MasterPageFile="~/MasterPage.master" Title="Личный кабинет" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <script type="text/javascript">
        function reloadPage() {
            window.location.reload();
        }
    </script>

    <div class="alert alert-danger" id="alertblock" runat="server" visible="False">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4>
            <asp:Label ID="AlertTitle" runat="server" Text=""></asp:Label></h4>
        <asp:Label ID="AlertText" runat="server" Text=""></asp:Label>
    </div>
    <div class="alert alert-info" id="alertmoder" runat="server" visible="False">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4>
            <asp:Label ID="alertmodertitle" runat="server" Text=""></asp:Label></h4>
        <asp:Label ID="alertmodertext" runat="server" Text=""></asp:Label>
    </div>

    <asp:Panel ID="Test" runat="server">


        <div class="offset1">
            <div class="row">

                <h3>Специальность:
                <span style="text-transform: uppercase;">
                    <asp:Label ID="NameTestLabel" runat="server" CssClass="text-success"></asp:Label></span>,
              <span style="text-transform: lowercase;">
                  <asp:Label ID="Group" runat="server"></asp:Label></span></h3>
            </div>
            <div class="row">
                <div class="span12">
                    Пробный тест
                        <asp:LinkButton ID="TrialTestingGO" runat="server" PostBackUrl="~/site/test/pilot/pilot_instruction.aspx" OnClick="TrialTestingGO_Click">Начать <i class="icon-circle-arrow-right"></i> </asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="span12">
                    Квалификационные тест
                        <asp:LinkButton ID="QualificationTestingGO" runat="server" OnClick="Button3_Click">Начать <i class="icon-circle-arrow-right"></i></asp:LinkButton>
                </div>
            </div>



        </div>


        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT naimenovanie_testa, status, data FROM prohozhdenie_testa WHERE (ID_testiruemyj = @ID_testiruemyj) AND (status = 0) AND (data IS NULL)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="ID_testiruemyj" SessionField="UserID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    </asp:Panel>

    <asp:Panel ID="TestComfirm" runat="server" Visible="False">
        <div class="container">
            <h3>Внимание, Вы не проходили пробное тестирование! Вы можете открыть пробное тестирование или приступить к прохождению квалификационного теста. </h3>
            <div class="btn-group">
                <asp:Button ID="PilotTest" runat="server" Text="Пройти пробное тестирование" CssClass="btn btn-success" OnClick="PilotTest_Click" />
                <asp:Button ID="KvalifTest" runat="server" Text="Пройти квалификационные тест" CssClass="btn btn-info" OnClick="KvalifTest_Click" />
                <asp:Button ID="Cansel" runat="server" Text="Закрыть" CssClass="btn " OnClick="Cansel_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Activ" runat="server" Visible="False">
        Активируйте учетную запись. Код активации отправлен на Вашу электронную почту, указаный при регистрации.<br />
        <br />
        <div class="form-horizontal">

            <label class="control-label" for="InputAktivKod">Код активации:</label>

            <asp:TextBox ID="InputAktivKod" runat="server" placeholder="Код активации"></asp:TextBox>


            <asp:Button ID="Button1" runat="server" Text="Активация" CssClass="btn" OnClick="Button1_Click" />

        </div>
    </asp:Panel>

    <asp:Panel ID="Moderacija" runat="server">
        <h2>
            <asp:Label ID="OtvetModerator" runat="server" CssClass="text-info"></asp:Label></h2>


    </asp:Panel>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="SidebarContent">
    <ul class="nav nav-list">
        <li class="nav-header">
            <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
                <EditItemTemplate>
                    F:
          <asp:TextBox ID="FTextBox" runat="server" Text='<%# Bind("F") %>' />
                    <br />
                    I:
          <asp:TextBox ID="ITextBox" runat="server" Text='<%# Bind("I") %>' />
                    <br />
                    O:
          <asp:TextBox ID="OTextBox" runat="server" Text='<%# Bind("O") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Обновить" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Отмена" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    F:
          <asp:TextBox ID="FTextBox" runat="server" Text='<%# Bind("F") %>' />
                    <br />
                    I:
          <asp:TextBox ID="ITextBox" runat="server" Text='<%# Bind("I") %>' />
                    <br />
                    O:
          <asp:TextBox ID="OTextBox" runat="server" Text='<%# Bind("O") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Вставка" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Отмена" />
                </InsertItemTemplate>
                <ItemTemplate>
                    &nbsp;<asp:Label ID="FLabel" runat="server" Text='<%# Bind("F") %>' />
                    &nbsp;<asp:Label ID="ILabel" runat="server" Text='<%# Bind("I") %>' />
                    &nbsp;<asp:Label ID="OLabel" runat="server" Text='<%# Bind("O") %>' />
                    <br />
                </ItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [F], [I], [O] FROM [l-kabinet] WHERE ([ID] = @ID)">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="UserID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </li>
        <li class="divider"></li>
        <%-- <li><a href="#"><i class="icon-user"></i>Профиль</a></li>--%>
        <li><a href="../Default.aspx"><i class="icon-remove"></i>Выход</a></li>
    </ul>
</asp:Content>

