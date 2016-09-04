<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpisokAttestuemyh.aspx.cs" Inherits="admin_SpisokAttestuemyh" MasterPageFile="../AdminMasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <div class="form-horizontal" role="form">
           <div class="form-group">
               <div class="col-sm-6">
        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="gruppa" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [gruppa_dolzhnost]"></asp:SqlDataSource>
                   </div>
                <div class="col-sm-6">
        <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="dolzhnost" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT dolzhnost, ID FROM dolzhnost WHERE (gruppa = @gruppa) ORDER BY dolzhnost">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="gruppa" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
                    </div>
            </div>
    </div>
    <div class="form-horizontal" role="form">
        <div class="form-group">
            <label for="F" class="col-sm-2 control-label">Фамилия</label>
            <div class="col-sm-10">
                <asp:TextBox ID="F" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="I" class="col-sm-2 control-label">Имя</label>
            <div class="col-sm-10">
                <asp:TextBox ID="I" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="O" class="col-sm-2 control-label">Отчество</label>
            <div class="col-sm-10">
                <asp:TextBox ID="O" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="LPU" class="col-sm-2 control-label">МО</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="LPU" runat="server" CssClass="form-control" DataSourceID="SqlDataSource3" DataTextField="lpu" DataValueField="ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [lpu] ORDER BY [lpu]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
        <asp:Button ID="Add" runat="server" Text="Добавить" class="btn btn-default" OnClick="Add_Click"/>
    </div>
  </div>
    </div>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />

    <asp:GridView ID="GridView1" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource4">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="F" HeaderText="F" SortExpression="F" />
            <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" />
            <asp:BoundField DataField="O" HeaderText="O" SortExpression="O" />
            <asp:BoundField DataField="gruppa" HeaderText="gruppa" SortExpression="gruppa" />
            <asp:BoundField DataField="dolzhnost" HeaderText="dolzhnost" SortExpression="dolzhnost" />
            <asp:BoundField DataField="lpu" HeaderText="lpu" SortExpression="lpu" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT SpisokAttestuemyh.ID, SpisokAttestuemyh.F, SpisokAttestuemyh.I, SpisokAttestuemyh.O, gruppa_dolzhnost.gruppa, dolzhnost.dolzhnost, lpu.lpu FROM lpu INNER JOIN SpisokAttestuemyh ON lpu.ID = SpisokAttestuemyh.LPUID INNER JOIN gruppa_dolzhnost INNER JOIN dolzhnost ON gruppa_dolzhnost.ID = dolzhnost.gruppa ON SpisokAttestuemyh.DolzhnostID = dolzhnost.ID"></asp:SqlDataSource>

    <br />
</asp:Content>

