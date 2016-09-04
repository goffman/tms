<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result2.aspx.cs" Inherits="Test_result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
         .anibar { height: 1.6em; }
    .anibar .ui-progressbar-value { background-image: url(/images/pbar-ani.gif); }
        </style>
    
    <link href="../js/toastmessage/src/main/resources/css/jquery.toastmessage.css" rel="stylesheet" />
    <script src="../js/toastmessage/src/test/javascript/lib/jquery-1.5.min.js"></script>
    <script src="../js/toastmessage/src/main/javascript/jquery.toastmessage.js"></script>
</head>
<body>
    <%string ate = "sdfkjsfjshd"; %>
    <form id="form1" runat="server">
    <script type="text/javascript">
    function showSuccessToast(text2) {
        $().toastmessage('showNoticeToast', text2);
    }
    function showStickySuccessToast() {
        $().toastmessage('showToast', {
            text: 'adasd',
            sticky   : true,
            position : 'top-right',
            type     : 'success',
            closeText: '',
            close    : function () {
                console.log("toast is closed ...");
            }
        });

    }
    function showNoticeToast() {
        $().toastmessage('showNoticeToast', "Notice  Dialog which is fading away ...");
    }
    function showStickyNoticeToast() {
        $().toastmessage('showToast', {
             text     : 'Notice Dialog which is sticky',
             sticky   : true,
             position : 'top-right',
             type     : 'notice',
             closeText: '',
             close    : function () {console.log("toast is closed ...");}
        });
    }
    function showWarningToast() {
        $().toastmessage('showWarningToast', "Warning Dialog which is fading away ...");
    }
    function showStickyWarningToast() {
        $().toastmessage('showToast', {
            text     : 'Warning Dialog which is sticky',
            sticky   : true,
            position : 'top-right',
            type     : 'warning',
            closeText: '',
            close    : function () {
                console.log("toast is closed ...");
            }
        });
    }
    function showErrorToast() {
        $().toastmessage('showErrorToast', "Error Dialog which is fading away ...");
    }
    function showStickyErrorToast() {
        $().toastmessage('showToast', {
            text     : 'Error Dialog which is sticky',
            sticky   : true,
            position : 'top-right',
            type     : 'error',
            closeText: '',
            close    : function () {
                console.log("toast is closed ...");
            }
        });
    }
    </script>
        <div>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td colspan="2">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button" runat="server" Height="23px" OnClick="Button_Click" Text="NEXT" Width="109px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/img/294.gif" />
                                    &nbsp;загрузка...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">Правильных ответов: </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:TextBox ID="TextBox1" runat="server" Height="100%" TextMode="MultiLine" Width="100%" BorderStyle="Dashed" Rows="3"></asp:TextBox>
    
        <br />
    
    </div>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="завершить" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="запуск" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
        </asp:CheckBoxList>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        Специальность <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="naimenovanie" DataValueField="id_specialnost" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [specialnost]"></asp:SqlDataSource>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="588px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="dolzhnost" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [dolzhnost], [ID] FROM [dolzhnost]"></asp:SqlDataSource>
        <br />
       
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
        <asp:TextBox ID="TextBox5" runat="server" Width="926px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox4" runat="server" Height="170px" TextMode="MultiLine" Width="568px"></asp:TextBox>
       
        <asp:TextBox ID="TextBox6" runat="server" Height="172px" TextMode="MultiLine" Width="253px"></asp:TextBox>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
       
        <br />
       &nbsp;<%%><asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
      
        <br />
        <asp:Button ID="Button1" runat="server" Text="Создать специальности из папки" OnClick="Button1_Click1" />
    </form>
</body>
</html>
