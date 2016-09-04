<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pilot_test.aspx.cs" Inherits="site_test_test" MasterPageFile="~/MasterPage.master" Title="Пробное тестирование"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="SidebarContent">

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="100" OnTick="Timer1_Tick"></asp:Timer>
   


    Время
    <asp:Label ID="txtTimer" runat="server" Text="00:00:00" CssClass="badge badge-info"></asp:Label><br />
    Правильных ответов:
    <asp:Label ID="txtPravelOtv" runat="server" Text="0" CssClass="badge badge-info"></asp:Label><br />
    <asp:Label ID="NumberVopros" runat="server" Text="0" CssClass="badge badge-info" Visible="False"></asp:Label>
    <br />
    <br />
    <div class="progress progress-striped" style="display: none">
        <div id="Progress" runat="server" class="bar bar-success"></div>
    </div>
                    </ContentTemplate>
    </asp:UpdatePanel>
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
    <div class="well">
        <asp:Label ID="LblVopros" runat="server" style="text-align: center; font-size: large" Width="100%"></asp:Label>
    </div>
    <asp:Label ID="system_info" runat="server" CssClass="text-success"></asp:Label>
     <div class="well">
         <div class="container-fluid">
         <asp:CheckBoxList ID="CheckGroupOtvet" runat="server" DataSourceID="SqlDataSource1" DataTextField="otvet" DataValueField="id" OnSelectedIndexChanged="CheckGroupOtvet_SelectedIndexChanged" CssClass="left checkbox" >
         </asp:CheckBoxList>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [otvet], [id] FROM [otveti] WHERE ([ID_voprosy] = @ID_voprosy)">
             <SelectParameters>
                 <asp:ControlParameter ControlID="Label1" DefaultValue="0" Name="ID_voprosy" PropertyName="Text" />
             </SelectParameters>
         </asp:SqlDataSource>
             </div>
         </div>

    <asp:Button ID="btnNextVopros" runat="server" Text="Следующий вопрос" CssClass="btn btn-primary btn-large" OnClick="btnNextVopros_Click"/>
    <asp:Panel ID="EndTest" runat="server">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </asp:Panel>

</asp:Content>

