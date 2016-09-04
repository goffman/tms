<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="admin_users_result" MasterPageFile="~/admin/Admin.master" Title="Результаты теста"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">



    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            //<![CDATA[
            function openWin() {
                var oWnd = radopen("../modalPopup/metkaOtpravlen.aspx", "RadWindow1");
            }

            function OnClientClose(oWnd, args) {
                //get the transferred arguments
                var arg = args.get_argument();
                if (arg) {
                    var cityName = arg.cityName;
                    var seldate = arg.selDate;
                    $get("order").innerHTML = "You chose to fly to <strong>" + cityName + "</strong> on <strong>" + seldate + "</strong>";
                }
            }
            //]]>
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="False"
        ReloadOnShow="True" runat="server" EnableShadow="True" Skin="Metro">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Behaviors="Close" OnClientClose="OnClientClose" NavigateUrl="../modalPopup/metkaOtpravlen.aspx" Title="Отметить как отправленные в МЗ">
            </telerik:RadWindow>
        </Windows>


    </telerik:RadWindowManager>

    <div class="accordion" id="accordion2">
        <div class="accordion-group">
            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapseOne">Врачи
                </a>
            </div>
            <div id="collapseOne" class="accordion-body collapse">
                <div class="accordion-inner">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CssClass="table " BorderStyle="None">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="Фамилия" HeaderText="Фамилия" SortExpression="Фамилия" />
                            <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
                            <asp:BoundField DataField="Отчество" HeaderText="Отчество" SortExpression="Отчество" />
                            <asp:BoundField DataField="Должность" HeaderText="Должность" SortExpression="Должность" />
                            <asp:BoundField DataField="Стаж" HeaderText="Стаж" SortExpression="Стаж" />
                            <asp:BoundField DataField="Место работы" HeaderText="Место работы" SortExpression="Место работы" />
                            <asp:BoundField DataField="Дата тестирования" HeaderText="Дата тестирования" SortExpression="Дата тестирования" />
                            <asp:BoundField DataField="Результат" HeaderText="Результат" SortExpression="Результат" />
                            <asp:BoundField DataField="Процент" HeaderText="Процент" ReadOnly="True" SortExpression="Процент" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT     [l-kabinet].ID, [l-kabinet].F AS Фамилия, [l-kabinet].I AS Имя, [l-kabinet].O AS Отчество, dolzhnost.dolzhnost AS Должность, [l-kabinet].stazh AS Стаж, lpu.lpu AS [Место работы], 
                      prohozhdenie_testa.data AS [Дата тестирования], prohozhdenie_testa.rezultat AS Результат,ROUND( (convert(money, prohozhdenie_testa.rezultat)/70*100),0) as Процент
FROM         dolzhnost INNER JOIN
                      [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost INNER JOIN
                      lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                      prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj
WHERE     (prohozhdenie_testa.otpravlen = 0) AND (dolzhnost.gruppa = 3)
GROUP BY [l-kabinet].ID, [l-kabinet].F,[l-kabinet].I,[l-kabinet].O, dolzhnost.dolzhnost, [l-kabinet].stazh, lpu.lpu, prohozhdenie_testa.data, prohozhdenie_testa.rezultat
HAVING      (prohozhdenie_testa.rezultat &gt; 0) AND (prohozhdenie_testa.data IS NOT NULL)"></asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div class="accordion-group">
            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo">Средний мед. персонал
                </a>
            </div>
            <div id="collapseTwo" class="accordion-body collapse">
                <div class="accordion-inner">
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" CssClass="table">
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT     [l-kabinet].ID,  [l-kabinet].F AS Фамилия, [l-kabinet].I AS Имя, [l-kabinet].O AS Отчество, dolzhnost.dolzhnost AS Должность, [l-kabinet].stazh AS Стаж, lpu.lpu AS [Место работы], 
                      prohozhdenie_testa.data AS [Дата тестирования], prohozhdenie_testa.rezultat AS Результат,ROUND( (convert(money, prohozhdenie_testa.rezultat)/70*100),0) as Процент
FROM         dolzhnost INNER JOIN
                      [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost INNER JOIN
                      lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                      prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj
WHERE     (prohozhdenie_testa.otpravlen = 0) AND (dolzhnost.gruppa = 5)
GROUP BY [l-kabinet].ID, [l-kabinet].F,[l-kabinet].I,[l-kabinet].O, dolzhnost.dolzhnost, [l-kabinet].stazh, lpu.lpu, prohozhdenie_testa.data, prohozhdenie_testa.rezultat
HAVING      (prohozhdenie_testa.rezultat &gt; 0) AND (prohozhdenie_testa.data IS NOT NULL)"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>


    <div class="navbar">
        <div class="navbar-inner navbar-fixed-bottom">
            <ul class="nav">
                <li>
                    <asp:LinkButton ID="VR" runat="server" OnClick="VR_Click"><i class="icon-download" ></i> Результаты врачей</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="SMP" runat="server" OnClick="SMP_Click"><i class="icon-download"></i> Результаты среднего медицинского персонала</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="Send" runat="server" OnClientClick="openWin(); return false;"><i class="icon-ok" ></i> Метка "Отправленные"</asp:LinkButton>
                </li>
            </ul>
        </div>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>

    </div>
</asp:Content>


