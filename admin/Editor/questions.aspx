<%@ Page Language="C#" AutoEventWireup="true" CodeFile="questions.aspx.cs" Inherits="admin_editor_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link href="/resources/css/examples.css" rel="stylesheet" />
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT voprosy.id_voprosy, voprosy.vopros FROM voprosy INNER JOIN [dolzhnost-specialnost] ON voprosy.specialnost = [dolzhnost-specialnost].specialnost WHERE ([dolzhnost-specialnost].dolzhnost = @dolzhnost)" OnInserted="SqlDataSource1_Inserted" UpdateCommand="UPDATE voprosy SET vopros = @vopros WHERE (id_voprosy = @id_voprosy)" OnSelecting="SqlDataSource1_Selecting" DeleteCommand="DELETE FROM voprosy WHERE (id_voprosy = @id_voprosy)" InsertCommand="INSERT INTO voprosy(specialnost, vopros, kategoria) VALUES (@specialnost, @vopros, 1)">
                <DeleteParameters>
                    <asp:Parameter Name="id_voprosy" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="specialnost" />
                    <asp:Parameter Name="vopros" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="dolzhnost" SessionField="spec" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="vopros" />
                    <asp:Parameter Name="id_voprosy" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT id, otvet, vernyj FROM otveti WHERE (ID_voprosy = @ID_voprosy)" UpdateCommand="UPDATE otveti SET otvet = @otvet, vernyj = @vernyj WHERE (id = @id)" DeleteCommand="DELETE FROM otveti WHERE (id = @id)">
                <DeleteParameters>
                    <asp:Parameter Name="id" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="ID_voprosy" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="otvet" />
                    <asp:Parameter Name="vernyj" />
                    <asp:Parameter Name="id" />
                </UpdateParameters>
            </asp:SqlDataSource>

            <%--    Хранилище 2. Для ответов--%>
            <ext:Store
                ID="Store2"
                runat="server"
                AutoLoad="false"
                DataSourceID="SqlDataSource2"
                OnReadData="Store2_Refresh">
                <Model>
                    <ext:Model ID="Model2" runat="server" IDProperty="id" Name="id">
                        <Fields>
                            <ext:ModelField Name="id" />
                            <ext:ModelField Name="otvet" />
                            <ext:ModelField Name="vernyj" />
                        </Fields>
                    </ext:Model>
                </Model>
                <Reader>
                    <ext:JsonReader IDProperty="id" />
                </Reader>
                <Parameters>
                    <ext:StoreParameter
                        Name="id_voprosy"
                        Value="#{GridPanel1}.getSelectionModel().hasSelection() ? #{GridPanel1}.getSelectionModel().getSelection()[0].data.id_voprosy : -1"
                        Mode="Raw" />
                </Parameters>
                <Listeners>
                    <Exception Handler="Ext.Msg.alert('Вопросы', operation.getError());" />
                    <Write Handler="Ext.Msg.alert('Ответы', 'Данные успешно сохранены');" />
                </Listeners>
            </ext:Store>

            <%--    Хранище 1. Для вопросов--%>
            <ext:Store
                ID="Store1"
                runat="server"
                DataSourceID="SqlDataSource1"
                ShowWarningOnFailure="false"
                OnAfterDirectEvent="Store1_AfterDirectEvent"
                OnBeforeDirectEvent="Store1_BeforeDirectEvent"
                OnBeforeRecordInserted="Store1_BeforeRecordInserted"
                OnAfterRecordInserted="Store1_AfterRecordInserted"
                OnReadData="Store1_RefershData">
                <Model>
                    <ext:Model ID="Model1" runat="server" IDProperty="id_voprosy" Name="id_voprosy">
                        <Fields>
                            <ext:ModelField Name="id_voprosy" Type="Int" />
                            <ext:ModelField Name="vopros" />
                        </Fields>
                    </ext:Model>
                </Model>
                <Sorters>
                    <ext:DataSorter Property="id_voprosy" Direction="ASC" />
                </Sorters>
                <Listeners>
                    <Exception Handler="Ext.Msg.alert('Ошибка!', operation.getError());" />
                    <Write Handler="Ext.Msg.alert('Вопросы', 'Данные успешно сохранены');" />
                </Listeners>
            </ext:Store>


            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
                <Items>

                    <%--            Описание формы--%>
                    <ext:Panel ID="Panel1"
                        runat="server"
                        Region="North"
                        Title="Описание"
                        Height="100"
                        BodyPadding="5"
                        Frame="true"
                        Icon="Information"
                        MarginsSummary="5 5 5 5">
                        <Content>

                            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" />

                        </Content>
                    </ext:Panel>

                    <%--            Грид отображающий вопросы--%>
                    <ext:Panel ID="Panel2" runat="server" Region="Center" Height="300" Header="false" Layout="Fit" MarginsSummary="0 5 0 5">
                        <Items>
                            <ext:GridPanel
                                ID="GridPanel1"
                                runat="server"
                                Title="Вопросы"
                                StoreID="Store1"
                                Border="false">
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column1" runat="server" DataIndex="id_voprosy" Text="ID" />
                                        <ext:Column ID="Column2" runat="server" DataIndex="vopros" Text="Вопрос" Flex="1">
                                            <Editor>
                                                <ext:TextField ID="TextField2" runat="server" />
                                            </Editor>
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" Mode="Multi">
                                        <Listeners>
                                            <Select Handler="if (#{pnlSouth}.isVisible()) {#{Store2}.reload();}" Buffer="250">
                                            </Select>
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1"
                                        runat="server"
                                        StoreID="Store1"
                                        DisplayInfo="false" />
                                </BottomBar>
                                <Plugins>
                                    <ext:CellEditing ID="CellEditing1" runat="server" />
                                </Plugins>
                            </ext:GridPanel>
                        </Items>
                        <Buttons>
                            <ext:Button ID="btnSave" runat="server" Text="Сохранить" Icon="Disk">
                                <Listeners>
                                    <Click Handler="#{Store1}.sync();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnDelete" runat="server" Text="Удалить выбранный вопрос" Icon="Delete">
                               
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.deleteSelected();">
                                     
                                    </Click>
                                </Listeners>
                                   
                            </ext:Button>
                          <%--  <ext:Button ID="btnInsert" runat="server" Text="Добавть новый вопрос" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{Store2}.insert(0, new Supplier());#{GridPanel2}.editingPlugin.startEditByPosition({row:0, column:0});" />
                                </Listeners>
                            </ext:Button>--%>
                            <ext:Button ID="btnRefresh" runat="server" Text="Обновить" Icon="ArrowRefresh">
                                <Listeners>
                                    <Click Handler="#{Store1}.reload({params:{EmulateError: 0}});" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>

                    <ext:Panel
                        ID="pnlSouth"
                        runat="server"
                        Region="South"
                        Title="Ответы"
                        Height="200"
                        Layout="Fit"
                        Collapsible="true"
                        Split="true"
                        MarginsSummary="0 5 5 5">
                        <Items>
                            <ext:GridPanel
                                ID="GridPanel2"
                                runat="server"
                                Border="false"
                                StoreID="Store2">
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column3" runat="server" DataIndex="id" Text="ИД" />
                                        <ext:Column ID="Column4" runat="server" DataIndex="otvet" Text="Ответ" Flex="1">
                                            <Editor>
                                                <ext:TextField ID="TextField1" runat="server" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ID="Column5" runat="server" DataIndex="vernyj" Text="Верный">
                                            <Editor>
                                                <ext:TextField ID="TextField3" runat="server" />
                                            </Editor>
                                        </ext:Column>

                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" Mode="Multi" />
                                </SelectionModel>
                                <%-- <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar2"
                                runat="server"
                                StoreID="Store1"
                                DisplayInfo="false" />
                        </BottomBar>--%>
                                <Plugins>
                                    <ext:CellEditing ID="CellEditing2" runat="server" />
                                </Plugins>
                            </ext:GridPanel>
                        </Items>
                        <Listeners>
                            <Expand Handler="#{Store2}.reload();" />
                        </Listeners>

                        <Buttons>
                            <ext:Button ID="Button1" runat="server" Text="Сохранить" Icon="Disk">
                                <Listeners>
                                    <Click Handler="#{Store2}.sync();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button3" runat="server" Text="Удалить выбранный ответ" Icon="Delete">
                                <Listeners>
                                    <Click Handler="#{GridPanel2}.deleteSelected();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button4" runat="server" Text="Добавть ответ" Icon="Add" OnDirectClick="Button6_Click" Hidden="true">
                                <%-- <Listeners>
                            <Click Handler="#{Store2}.insert(0, new id());#{GridPanel2}.editingPlugin.startEditByPosition({row:0, column:0});" />
                        </Listeners>--%>
                            </ext:Button>
                            <ext:Button ID="Button5" runat="server" Text="Обновить" Icon="ArrowRefresh">
                                <Listeners>
                                    <Click Handler="#{Store2}.reload({params:{EmulateError: 0}});" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>

                </Items>
            </ext:Viewport>
            <ext:Window
                ID="Window1"
                runat="server"
                Title="Добавить ответ"
                Icon="Application"
                Hidden="true"
                Height="185"
                Width="350"
                BodyStyle="background-color: #fff;"
                BodyPadding="5"
                Modal="true">
                <Content>
                    <div>
                      <%--  <ext:Label runat="server" Text="Text" ID="sel"></ext:Label>--%>
                        <ext:TextField runat="server" ID="sel" FieldLabel="ID вопроса" ReadOnly="true"></ext:TextField>
                    </div>

                    <ext:TextField runat="server" ID="txtNewOtvet" FieldLabel="Ответ"></ext:TextField>
                    <ext:ComboBox runat="server" ID="chkMark" FieldLabel="Правильный">
                        <SelectedItems>
                            <ext:ListItem Value="0" />
                        </SelectedItems>
                        <Items>
                            <ext:ListItem Text="Да" Value="1" />
                            <ext:ListItem Text="Нет" Value="0" />
                        </Items>
                    </ext:ComboBox>
                    <ext:Button runat="server" ID="btnAddNewOtvet" Text="Добавить" Icon="Add">
                        <DirectEvents>
                    <Click OnEvent="Button7_Click">
                         <EventMask ShowMask="true" Msg="Обработка..." MinDelay="500" />
                        </Click>
                            </DirectEvents>
                    </ext:Button>
                </Content>
            </ext:Window>
          <%--  <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />--%>
        </div>
    </form>
</body>
</html>

