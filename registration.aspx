<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" MasterPageFile="~/MasterPage.master" Title="Регистрация" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RegistrationButton">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Wizard1" LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" DisplaySideBar="False" EnableTheming="True">
            <FinishNavigationTemplate>
            </FinishNavigationTemplate>
            <HeaderTemplate>
            </HeaderTemplate>
            <StartNavigationTemplate>
            </StartNavigationTemplate>
            <StepNavigationTemplate>
            </StepNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep runat="server" Title="Персональные данные" AllowReturn="True">
                    <div class="text-left">
                        <h2>Согласие на обработку персональных данных</h2>
                        <ol>
                            <li style="text-align: justify;">Я, именуемый(ая) в дальнейшем Субъект, в соответствии с требованиями статьи 9 Федерального закона от 27.07.2006 № 152-ФЗ &laquo;О персональных данных&raquo; подтверждаю свое согласие на обработку ГКУЗ РХ &laquo;МИАЦ&raquo; (далее &ndash; Оператор) моих персональных данных, представляемых для внесения в реестр сведений для регистрации на сайте Оператора, включающих: фамилию, имя, отчество; контактный номер телефона, адрес электронной почты, специальность, место работы, должность, стаж работы.</li>
                            <li style="text-align: justify;">Предоставляю Оператору право осуществлять все действия (операции) с моими персональными данными, включая сбор, систематизацию, накопление, хранение, обновление, изменение, использование, обезличивание, блокирование, уничтожение. Оператор вправе обрабатывать мои персональные данные посредством внесения их в электронную базу данных, включения в списки (реестры) и отчетные формы, предусмотренные документами, регламентирующими предоставление отчетных данных (документов).</li>
                            <li style="text-align: justify;">Оператор имеет право на обмен (прием и передачу) моими персональными данными с использованием машинных носителей или по каналам связи, с соблюдением мер, обеспечивающих их защиту от несанкционированного доступа, при условии, что их прием и обработка будут осуществляться лицом, обязанным сохранять профессиональную тайну.</li>
                            <li style="text-align: justify;">Настоящее согласие действует 5 лет в соотвествии перечнем типовых управленческих архивных документов, образующихся в процессе деятельности государственных органов, органов местного самоуправления и организаций, с указанием сроков хранения</li>
                            <li style="text-align: justify;">В соответствии с п.4 ст. 14 Федерального закона &laquo;О персональных данных&raquo; от 27.06.2006 г. №152 Субъект персональных данных по письменному запросу имеет право на получение информации, касающейся обработки его персональных данных.</li>
                            <li style="text-align: justify;">Обработка персональных данных, не включенных в общедоступные источники, прекращается при поступлении Оператору письменного заявления Субъекта о расторжении Согласия.</li>
                            <li style="text-align: justify;">При поступлении Оператору письменного заявления Субъекта о прекращении действия Согласия, персональные данные деперсонализируются в 15-дневый срок.</li>
                        </ol>
                        <div class="form-inline">

                            <asp:CheckBox ID="PersonalnyeDannyeTrue" runat="server" AutoPostBack="True" Text="Я согласен (-а)" CssClass="checkbox inline" OnCheckedChanged="PersonalnyeDannyeTrue_CheckedChanged" />
                            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Далее" Enabled="False" OnClick="Button1_Click" />
                        </div>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Регистрация" AllowReturn="False">



                    <div class="text-left">
                        <div class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label" for="txtF">
                                    Фамилия</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtF" runat="server" placeholder="Фамилия"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Поле не заполнено" ControlToValidate="txtF" ForeColor="Red" ValidationGroup="Users"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtI">
                                    Имя</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtI" runat="server" placeholder="Имя"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" Поле не заполнено" ControlToValidate="txtI" ForeColor="Red" ValidationGroup="Users"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtO">
                                    Отчество</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtO" runat="server" placeholder="Отчество"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Поле не заполнено" ControlToValidate="txtO" ForeColor="Red" ValidationGroup="Users"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="DropNaprav">
                                    Специальность</label>
                                <div class="controls">
                                    <asp:DropDownList AppendDataBoundItems="true" ID="DropNaprav" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="gruppa" DataValueField="ID" placeholder="Должность" Width="45%" OnSelectedIndexChanged="DropNaprav_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0" Text="Выберите группу специальностей..."></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT [gruppa], [ID] FROM [gruppa_dolzhnost] ORDER BY [gruppa]"></asp:SqlDataSource>

                                    <asp:DropDownList ID="Dropspec" runat="server" DataSourceID="SqlDataSource2" DataTextField="dolzhnost" DataValueField="ID" placeholder="Должность" Width="45%" OnDataBinding="Dropspec_DataBinding">
                                    </asp:DropDownList>
                                    <div class="alert alert-error" role="alert" runat="server" id="DropNapravAlert" visible="False">
                                        <asp:Label ID="DropNapravLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT     dolzhnost.dolzhnost, dolzhnost.ID, COUNT(*) AS Expr1
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
                            <div class="control-group">
                                <label class="control-label" for="txtStage">
                                    Стаж работы по специальности</label>
                                <div class="controls">

                                    <asp:TextBox ID="txtStage" runat="server" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Поле не заполнено" ControlToValidate="txtStage" ForeColor="Red" ValidationGroup="Users"></asp:RequiredFieldValidator>

                                    <telerik:RadToolTip ID="RadToolTip1" runat="server" Animation="Fade" AutoCloseDelay="0" Position="MiddleRight" RelativeTo="Element" ShowEvent="OnFocus" Skin="MetroTouch" TargetControlID="txtStage" Text="Указывать цифрами (например 1, 10, 24)"></telerik:RadToolTip>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="DropMestorab">
                                    Место работы</label>
                                <div class="controls">
                                    <asp:DropDownList ID="DropMestorab" runat="server" DataSourceID="SqlDataSource3" DataTextField="lpu" DataValueField="ID" Width="90%" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0" Text="Выберите место работы..."></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="alert alert-error" role="alert" runat="server" id="DropMestorabAlert" visible="False">
                                        <asp:Label ID="DropMestorabLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [lpu]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="Dropkat">
                                    Категория</label>
                                <div class="controls">
                                    <asp:DropDownList ID="Dropkat" runat="server" DataSourceID="SqlDataSource4" DataTextField="kategoria" DataValueField="ID" AppendDataBoundItems="true" OnDataBound="Dropkat_DataBound">
                                        <asp:ListItem Selected="True" Value="0" Text="Выберите категорию..."></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="alert alert-error" role="alert" runat="server" id="DropkatAlert" visible="False">
                                        <asp:Label ID="DropkatLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:tmsConnectionString %>" SelectCommand="SELECT * FROM [kategoria]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtemail">
                                    Электронная почта</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtemail" runat="server" placeholder="Электронная почта"></asp:TextBox>
                                    <telerik:RadToolTip ID="RadToolTip2" runat="server" Animation="Fade" AutoCloseDelay="0" Position="MiddleRight" RelativeTo="Element" ShowEvent="OnFocus" Skin="MetroTouch" TargetControlID="txtemail" Text="Например example@example.ru"></telerik:RadToolTip>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage=" Поле не заполнено" ControlToValidate="txtemail" ForeColor="Red" ValidationGroup="Users"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Электронная почта указана неверно..." ControlToValidate="txtemail" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtTelefon">
                                    Мобильный телефон</label>
                                <div class="controls">

                                    +7
                                  <asp:TextBox ID="txtTelefon" runat="server" MaxLength="10" OnTextChanged="txtTelefon_TextChanged" Width="185px" TextMode="Phone"></asp:TextBox>
                                    <asp:CheckBox ID="GetLoginPasswortToSMS" runat="server" Text="Получить логин и пароль по смс" CssClass="checkbox inline" />

                               
                                 
                                  
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="controls">
                                    <asp:Button ID="RegistrationButton" runat="server" CssClass="btn btn-success" OnClick="RegistrationButton_Click" Text="Регистрация" ValidationGroup="Users" />
                                </div>
                            </div>
                        </div>

                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Результат">
                    <div class="text-left">
                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                            <h2>Регистрация успешно завершена! </h2>
                            Логин и пароль для входа на сайт высланы Вам на указанный e-mail.
                <br />
                            <asp:Label ID="Label2" runat="server" Text="Через некоторое время Ваша учетная запись пройдёт утверждение модератором и Вы сможете пройти тестирование. Результат проверки будет выслан Вам на указанный электронный адрес."></asp:Label>

                            <br />
                            Если у Вас возникли вопросы:<br />
                            <address>

                                <abbr title="Телефон">Тел: 8 (3902) 295-025</abbr>
                                <br />
                                <abbr title="Электронная почта">E-mail: <a href="mailto:testmedspec@r-19.ru">testmedspec@r-19.ru</a></abbr>

                            </address>

                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                            <h2>Ошибка при регистрации</h2>
                            При регистрации возникла ошибка, это может произойти по следующим причинам:
                            <asp:Label ID="MessageErrorLabel" CssClass="text-error" runat="server" Text=""></asp:Label>
                            <ul>
                                <li>Повторная регистрация.</li>
                                <li>Заполнены не все поля, либо данные внесены не корректно.</li>
                                <li>Произошла внутренняя ошибка сервера.</li>
                            </ul>
                            Попробуйте пройти регистрацию заново, либо обратиться в службу технической поддержки по телефону 8 (3902) 295-025 или электронной почте <a href="mailto:testmedspec@r-19.ru">testmedspec@r-19.ru </a>

                        </asp:Panel>
                    </div>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <telerik:RadNotification ID="RadNotification1" runat="server" Position="Center"
            Width="330px" Height="130px" Animation="Fade" EnableRoundedCorners="True" EnableShadow="True"
            Style="z-index: 35000" Skin="MetroTouch">
        </telerik:RadNotification>
    </telerik:RadAjaxPanel>

    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="MetroTouch"></telerik:RadAjaxLoadingPanel>


    <%--<script>
         $(document).ready(function () {
            
             $("#input6").inputmask({ "mask": "9", "repeat": 10 });

             //$("#ctl00$BodyContent$Wizard1$txtStage").inputmask({ "mask": "9", "repeat": 10, "greedy": false });

             $("#input8").inputmask("d.m.y");

             $('#input8-set').click(function () { $("#input8").val('21122012'); });

             $('#input8-get').click(function () { alert($("#input8").inputmask('unmaskedvalue')); });

             $("#BodyContent_Wizard1_txtTelefon").inputmask("(999)9999999");

             $.extend($.inputmask.defaults.aliases, {
                 'non-negative-integer': {
                     regex: {
                         number: function (groupSeparator, groupSize) { return new RegExp("^(\\d*)$"); }
                     },
                     alias: "decimal"
                 }
             });

             $("#input10").inputmask("non-negative-integer");
         });
        </script>--%>

  <%--  <script type="text/javascript">
        $(function () {
            $.mask.definitions['~'] = "[+-]";
            $("#date").mask("99/99/9999", { completed: function () { alert("completed!"); } });
            $("#BodyContent_Wizard1_txtTelefon").mask("(999) 999-99-99");
            $("#phoneExt").mask("(999) 999-9999? x99999");
            $("#iphone").mask("+33 999 999 999");
            $("#tin").mask("99-9999999");
            $("#ssn").mask("999-99-9999");
            $("#product").mask("a*-999-a999", { placeholder: " " });
            $("#eyescript").mask("~9.99 ~9.99 999");
            $("#po").mask("PO: aaa-999-***");
            $("#pct").mask("99%");
            $("#phoneAutoclearFalse").mask("(999) 999-9999", { autoclear: false, completed: function () { alert("completed autoclear!"); } });
            $("#phoneExtAutoclearFalse").mask("(999) 999-9999? x99999", { autoclear: false });

            $("input").blur(function () {
                $("#info").html("Unmasked value: " + $(this).mask());
            }).dblclick(function () {
                $(this).unmask();
            });
        });

</script>--%>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="SidebarContent">
    <%
      
        Response.Write(" <ul class='nav nav-list'>   <li><a href='/Default.aspx'><i class='icon-home'></i>Вернуться</a></li>      </ul>");
        
    %>
</asp:Content>


