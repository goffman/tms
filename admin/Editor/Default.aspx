<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Editor_Default" MasterPageFile="../Editor.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <script type="text/javascript"> 
function disableSelection(target){ 
if (typeof target.onselectstart!="undefined") //IE route 
target.onselectstart=function(){return false} 
else if (typeof target.style.MozUserSelect!="undefined") //Firefox route 
target.style.MozUserSelect="none" 
else //All other route (ie: Opera) 
target.onmousedown=function(){return false} 
target.style.cursor = "default" 
}

disableSelection(document.body);
</script>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= RadGrid1.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("EditModal.aspx?id_voprosy=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("EditForm_csharp.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("EditModal.aspx?id_voprosy=" + eventArgs.getDataKeyValue("id_voprosy"), "UserListDialog");
            }
          

        </script>

    </telerik:RadCodeBlock>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    
         <div class="control-group">
                                <label class="control-label" for="DropNaprav">
                                    Специальность</label>
                                <div class="controls">
                                    <asp:DropDownList AppendDataBoundItems="true" ID="DropNaprav" runat="server"  CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="gruppa" DataValueField="ID" placeholder="Должность" Width="45%" OnSelectedIndexChanged="DropNaprav_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0" Text="Выберите группу специальностей..."></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [gruppa], [ID] FROM [gruppa_dolzhnost] ORDER BY [gruppa]"></asp:SqlDataSource>

                                    <asp:DropDownList ID="Dropspec" runat="server"  CssClass="form-control" DataSourceID="SqlDataSource4" DataTextField="dolzhnost" DataValueField="ID" placeholder="Должность" Width="45%" OnDataBinding="Dropspec_DataBinding" AutoPostBack="True" OnSelectedIndexChanged="Dropspec_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <div class="alert alert-error" role="alert" runat="server" id="DropNapravAlert" visible="False">
                                        <asp:Label ID="DropNapravLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT     dolzhnost.dolzhnost, dolzhnost.ID, COUNT(*) AS Expr1
FROM         dolzhnost INNER JOIN
                      [dolzhnost-specialnost] ON dolzhnost.ID = [dolzhnost-specialnost].dolzhnost
WHERE     (dolzhnost.gruppa = @ID_Group)
GROUP BY dolzhnost.dolzhnost, dolzhnost.ID
ORDER BY dolzhnost.dolzhnost">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropNaprav" DefaultValue="0" Name="ID_Group" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        voprosy.id_voprosy, voprosy.vopros
FROM            [dolzhnost-specialnost] INNER JOIN
                         voprosy ON [dolzhnost-specialnost].specialnost = voprosy.specialnost
WHERE        ([dolzhnost-specialnost].dolzhnost = @Dolz)"
        DeleteCommand="DELETE FROM voprosy
WHERE        (id_voprosy = @id_voprosy)"
        UpdateCommand="UPDATE       voprosy
SET                vopros = @vopros
WHERE        (id_voprosy = @id_voprosy)" ProviderName="System.Data.SqlClient">
        <DeleteParameters>
            <asp:Parameter Name="id_voprosy" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="Dolz" QueryStringField="D" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="vopros" />
            <asp:Parameter Name="id_voprosy" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        id , otvet, vernyj 
FROM            otveti
WHERE        (ID_voprosy = @ID_voprosy)"
        DeleteCommand="DELETE FROM otveti
WHERE        (id = @id)"
        UpdateCommand="UPDATE       otveti
SET                otvet = @otvet, vernyj = @vernyj
WHERE        (id = @id)">
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="ID_voprosy" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="otvet" />
            <asp:Parameter Name="vernyj" />
            <asp:Parameter Name="id" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Специальность: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;(<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    )<telerik:RadGrid ID="RadGrid1" runat="server" Culture="ru-RU" DataSourceID="SqlDataSource1" GroupPanelPosition="Top" ShowFooter="True" EnableHeaderContextMenu="True" ShowStatusBar="True" CellSpacing="-1" GridLines="Both">
        <ExportSettings>
            <Pdf PageWidth="">
            </Pdf>
        </ExportSettings>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id_voprosy" DataSourceID="SqlDataSource1" ClientDataKeyNames="id_voprosy" EnableHeaderContextMenu="False">

            <DetailTables>
                <telerik:GridTableView runat="server" DataSourceID="SqlDataSource2" HierarchyDefaultExpanded="True" HierarchyLoadMode="Client" EnableHeaderContextMenu="False">
                    <ParentTableRelation>
                        <telerik:GridRelationFields DetailKeyField="id_voprosy" MasterKeyField="id_voprosy" />
                    </ParentTableRelation>
                </telerik:GridTableView>
            </DetailTables>

            <Columns>
                <telerik:GridBoundColumn DataField="id_voprosy" DataType="System.Int32" FilterControlAltText="Filter id_voprosy column" HeaderText="ID вопроса" ReadOnly="True" SortExpression="id_voprosy" UniqueName="id_voprosy">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="vopros" FilterControlAltText="Filter vopros column" HeaderText="Вопрос" SortExpression="vopros" UniqueName="vopros">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ConfirmDialogType="RadWindow" FilterControlAltText="Filter column column" UniqueName="column">
                </telerik:GridButtonColumn>
            </Columns>

        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true"></Selecting>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>
    </telerik:RadGrid>
      
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True" AutoSize="True" MaxWidth="500px" MinHeight="500px">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Редактирования вопроса" Height="500px"
                Width="310px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" MaxWidth="500px" MinHeight="500px">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>

