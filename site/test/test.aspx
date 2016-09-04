<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="site_test_test" MasterPageFile="~/MasterPage.master" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="SidebarContent">

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="300px" Height="200px">
        <asp:Panel ID="Panel24" runat="server">

            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>



            Время
    <asp:Label ID="txtTimer" runat="server" CssClass="badge badge-info"></asp:Label><br />
            Правильных ответов:
    <asp:Label ID="txtPravelOtv" runat="server" Text="0" CssClass="badge badge-info"></asp:Label><br />
            Вопрос №
    <asp:Label ID="NumberVopros" runat="server" Text="0" CssClass="badge badge-info"></asp:Label>
            из 70
    <br />
            <br />
            <div class="progress progress-striped" style="display: none;">
                <div id="Progress" runat="server" class="bar bar-success"></div>
            </div>
        </asp:Panel>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server"></telerik:RadAjaxLoadingPanel>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="BodyContent">

    <script src="../../js/icheck.js"></script>
    <link href="../../js/skins/line/_all.css" rel="stylesheet" />
    <link href="../../css/cheakbox.css" rel="stylesheet" />
    <script src="http://yandex.st/jquery/2.0.3/jquery.js"></script>
    <script>
        $(document).ready(function () {
            $('CheckGroupOtvet').each(function () {
                var self = $(this),
                  label = self.next(),
                  label_text = label.text();

                label.remove();
                self.iCheck({
                    checkboxClass: 'icheckbox_line',
                    radioClass: 'iradio_line',
                    insert: '<div class="icheck_line-icon"></div>' + label_text
                });
            });
        });
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Panel2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel2" LoadingPanelID="RadAjaxLoadingPanel2"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
            <asp:Label ID="Label1" runat="server"></asp:Label>

            <div class="well">

                <asp:Label ID="LblVopros" runat="server" Style="text-align: center; font-size: large" Width="100%"></asp:Label>
            </div>
            <asp:Label ID="system_info" runat="server" CssClass="text-success"></asp:Label>
            <div class="well">
                <div class="container-fluid">
                    <asp:CheckBoxList ID="CheckGroupOtvet" runat="server" DataSourceID="SqlDataSource1" DataTextField="otvet" DataValueField="id" OnSelectedIndexChanged="CheckGroupOtvet_SelectedIndexChanged" CssClass="left checkbox">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [otvet], [id] FROM [otveti] WHERE ([ID_voprosy] = @ID_voprosy)">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="ID_voprosy" SessionField="vopros" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>

            <asp:Button ID="btnNextVopros" runat="server" Text="Следующий вопрос" CssClass="btn btn-primary btn-large" OnClick="btnNextVopros_Click" />
        <asp:Panel ID="EndTest" runat="server">
        </asp:Panel>
        </telerik:RadAjaxPanel>
    </asp:Panel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>

