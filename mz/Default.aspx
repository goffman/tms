<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="mz_Default" MasterPageFile="mz.master" Title="Рабочий стол" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="span12" id="content">
        <div class="row-fluid">

          <%--  <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">График аттестации</div>
                </div>

                <div class="block-content collapse in">
                    
                </div>

            </div>--%>
            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">График аттестации</div>
                </div>

                <div class="block-content collapse in">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="table" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="dolzhnost" HeaderText="Должность" SortExpression="dolzhnost" />
                            <asp:BoundField DataField="data" DataFormatString="{0:d}" HeaderText="Дата" SortExpression="data" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT dolzhnost.dolzhnost, attestacija.data FROM attestacija INNER JOIN dolzhnost ON attestacija.dolzhnost = dolzhnost.ID WHERE (attestacija.data &gt; GETDATE()) ORDER BY dolzhnost.gruppa, attestacija.data"></asp:SqlDataSource>

                </div>
            </div>

        </div>
    </div>

</asp:Content>


