<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Grafik.aspx.cs" Inherits="admin_Grafik" MasterPageFile="~/AdminMasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <div class="row">
        <div class="col-xs-6 col-md-5">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [dolzhnost], [ID] FROM [dolzhnost] WHERE ([gruppa] = @gruppa)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" Name="gruppa" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [ID], [gruppa] FROM [gruppa_dolzhnost]"></asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="gruppa" DataValueField="ID" CssClass="dropdown-header" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="100%">
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" CssClass="dropdown-header" DataSourceID="SqlDataSource1" DataTextField="dolzhnost" DataValueField="ID">
            </asp:DropDownList>
            <asp:Calendar ID="Calendar1" runat="server" CssClass="caption"></asp:Calendar>
            <asp:Button ID="Button1" runat="server" Text="Добавить" CssClass="btn-default" OnClick="Button1_Click" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%" CssClass="text-info"></asp:TextBox>
        </div>
        <div class="col-xs-12 col-md-5">
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        dolzhnost.dolzhnost, attestacija.data, gruppa_dolzhnost.gruppa
FROM            dolzhnost INNER JOIN
                         attestacija ON dolzhnost.ID = attestacija.dolzhnost INNER JOIN
                         gruppa_dolzhnost ON dolzhnost.gruppa = gruppa_dolzhnost.ID"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="100%">
                <Columns>
                    <asp:BoundField DataField="dolzhnost" HeaderText="Должность" SortExpression="dolzhnost" />
                    <asp:BoundField DataField="data" HeaderText="Дата" SortExpression="data" />
                    <asp:BoundField DataField="gruppa" HeaderText="Группа" SortExpression="gruppa" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


