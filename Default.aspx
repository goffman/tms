<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="suite_Default" MasterPageFile="~/MasterPage.master" Title="Главная" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <style>
        .center {
            display: block;
            margin: 0 auto;
        }
    </style>

 
   
    <div id="Alert" runat="server" visible="false">
        <asp:Label ID="lblNotification" runat="server"></asp:Label>
    </div>

    <div class="row-fluid">
          <div class="span5  offset2" style="margin-top: 20px">

        <div class="text-center">
           <p> <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-large" PostBackUrl="~/registration.aspx">Регистрация</asp:LinkButton></p>
            <p>для прохождения тестирования.</p>
                
        </div>
        <p>
       <%--  <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info">  <strong> Восстановить пароль</strong>   </asp:LinkButton>, если вы забыли пароль от своей учетной записи.--%>
              <hr />
            <telerik:RadTicker ID="News" runat="server" AutoStart="True" DataSourceID="SQLNews" DataTextField="News" Loop="True" TickSpeed="60"></telerik:RadTicker>
              <asp:SqlDataSource ID="SQLNews" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT       ( CONVERT (varchar(104), data, 104) +': ' + news) as News 
FROM            s_news
WHERE        (data &gt; GETDATE() - 30)"></asp:SqlDataSource>
        </p>
              
              


    </div>

        <div class="span5" >
            <div class="text-center">
         <%--       <div class="text-right"><a href="#">Открыть график аттестации</a></div>--%>
                <h5 align="center">График медицинского и фармацевтического персонал</h5>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        dolzhnost.dolzhnost, attestacija.data FROM            attestacija INNER JOIN dolzhnost ON attestacija.dolzhnost = dolzhnost.ID WHERE        (dolzhnost.gruppa = 3) AND (attestacija.data &gt; GETDATE()) AND (attestacija.data &lt; GETDATE() + 14)"></asp:SqlDataSource>

                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CssClass="table  table-striped" GridLines="None" ShowHeader="False" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="dolzhnost" HeaderText="dolzhnost" SortExpression="dolzhnost" />
                        <asp:BoundField DataField="data" HeaderText="data" SortExpression="data" DataFormatString="{0:d}" />
                    </Columns>
                    <HeaderStyle BorderStyle="None" />
                </asp:GridView>
                <hr/>
               <h5 align="center">График среднего медицинского персонала</h5>
                <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" CssClass="table  table-striped" GridLines="None" ShowHeader="False" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="dolzhnost" HeaderText="dolzhnost" SortExpression="dolzhnost" />
                        <asp:BoundField DataField="data" HeaderText="data" SortExpression="data" DataFormatString="{0:d}" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT        dolzhnost.dolzhnost, attestacija.data FROM            attestacija INNER JOIN dolzhnost ON attestacija.dolzhnost = dolzhnost.ID WHERE        (dolzhnost.gruppa = 5) AND (attestacija.data > GETDATE()) AND (attestacija.data < GETDATE() + 30)"></asp:SqlDataSource>
                <br />
            </div>
        </div>

  
    </div>


</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="SidebarContent">
    
    <%--              </ContentTemplate>
       
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>--%>
   <%--              </ContentTemplate>
       
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>--%>

        
        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <h2>Авторизация</h2>
        <div class="input-prepend">
            <span class="add-on"><i class="icon-user"></i></span>
            <asp:TextBox runat="server" ID="txtloginusername" placeholder="Логин" Font-Size="Medium" CssClass="input-block-level" />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtloginusername"
                ErrorMessage="Вы не указали логин пользователя..." Display="Dynamic" ValidationGroup="login" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="input-prepend">
            <span class="add-on"><i class=" icon-eye-close"></i></span>
            <asp:TextBox runat="server" ID="txtloginpass" placeholder="Пароль" Font-Size="Medium" CssClass="input-block-level" TextMode="Password" />
            <br />
            <asp:RequiredFieldValidator ID="ErrorPassword" runat="server"
                ControlToValidate="txtloginpass" ErrorMessage="Вы не ввели пароль..." Display="Dynamic" ValidationGroup="login" ForeColor="#CC0000"></asp:RequiredFieldValidator>

        </div>
        <br />
             <telerik:RadNotification ID="Notification" runat="server" Position="Center"   Width="330" Height="130" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
               Style="z-index: 35000" Skin="MetroTouch"></telerik:RadNotification>
  <%--              </ContentTemplate>
       
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>--%>
       
<%--    </asp:UpdatePanel>--%>
        <asp:Button ID="LoginBtn" runat="server" Text="Вход" CssClass="btn btn-primary btn-large" ValidationGroup="login" OnClick="Button1_Click" />


           
             

    </telerik:RadAjaxPanel>
        <telerik:RadAjaxLoadingPanel ID="LoadingPanel" runat="server" Skin="Metro" BackgroundTransparency="100"></telerik:RadAjaxLoadingPanel>
        
</asp:Content>



