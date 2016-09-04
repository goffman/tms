<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <%--  <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">--%>
            <script type="text/javascript">
              <%--  document.addEventListener('DOMContentLoaded', function () {
                    var UserNameSelected = document.getElementById("<%= HiddenField1.ClientID %>").value; //первое значение вознагрождения
                    console.log(UserNameSelected);
                    countDown(UserNameSelected); //устанавливаем таймер на 30 секунд     
                }, false);--%>

                //   var UserNameSelected = document.getElementById("<%= HiddenField1.ClientID %>");
                //  console.log(UserNameSelected);

     <%--           function countDown(second, endMinute, endHour, endDay, endMonth, endYear) {
                    var UserNameSelected2 = document.getElementById("<%= HiddenField2.ClientID %>").value;
                    var now = new Date();
                    second = second || now.getSeconds();
                    second = second + now.getSeconds();
                    endYear = endYear || now.getFullYear();
                    endMonth = endMonth ? month - 1 : now.getMonth();   //номер месяца начинается с 0
                    endDay = endDay || now.getDate();
                    endHour = endHour || now.getHours();
                    endMinute = endMinute || now.getMinutes();
                    //добавляем секунду к конечной дате (таймер показывает время уже спустя 1с.) 
                    var endDate = new Date(endYear, endMonth, endDay, endHour, endMinute, second + 1);
                    var interval = setInterval(function () { //запускаем таймер с интервалом 1 секунду

                        var time = endDate.getTime() - now.getTime();
                        if (time < 0) {                      //если конечная дата меньше текущей
                            clearInterval(interval);
                            alert("Неверная дата!");
                        } else {

                            var days = Math.floor(time / 864e5);
                            var hours = Math.floor(time / 36e5) % 24;
                            var minutes = Math.floor(time / 6e4) % 60;
                            var seconds = Math.floor(time / 1e3) % 60;
                            var digit = '<div style="width:70px;float:left;text-align:center">' +
                                '<div style="font-family:Stencil;font-size:65px;">';
                            var text = '</div><div>'
                            var end = '</div></div><div style="float:left;font-size:45px;">:</div>'
                            document.getElementById('mytimer').innerHTML = '<div>осталось: </div>' +
                                digit + days + text + 'Дней' + end + digit + hours + text + 'Часов' + end +
                                digit + minutes + text + 'Минут' + end + digit + seconds + text + 'Секунд';
                            UserNameSelected2.value = second;
                            console.log(UserNameSelected2);
                            if (!seconds && !minutes && !days && !hours) {
                                clearInterval(interval);
                                alert("Время вышло!");
                                UserNameSelected2.value = second;
                                console.log(UserNameSelected2);
                            }
                        }
                        now.setSeconds(now.getSeconds() + 1); //увеличиваем текущее время на 1 секунду
                    }, 1000);
                }--%>



                function timer() {
                    var obj = document.getElementById('timer_inp');
                    obj.innerHTML = obj.innerHTML / 60 + obj.innerHTML % 60;
                    obj.innerHTML--;
                    if (obj.innerHTML == 0) { alert('Hello'); setTimeout(function () { }, 1000); }
                    else { setTimeout(timer, 1000); }
                }
                setTimeout(timer, 1000);





                <%--  function RowSelected(sender, args) {
                var UserNameSelected = document.getElementById("<%= UserName.ClientID %>");
                var IDAccountSelected = document.getElementById("<%= IDAccount.ClientID %>");
                var telefonSelected = document.getElementById("<%= telefon.ClientID %>");
                var emailSelected = document.getElementById("<%= email.ClientID %>");
                var Fam = document.getElementById("<%= F.ClientID %>");
                var Im = document.getElementById("<%= I.ClientID %>");
                var Ot = document.getElementById("<%= O.ClientID %>");
                telefonSelected.value = args.getDataKeyValue("telefon");
                UserNameSelected.value = args.getDataKeyValue("UserName");
                IDAccountSelected.value = args.getDataKeyValue("ID");
                emailSelected.value = args.getDataKeyValue("email");
                Im.value = args.getDataKeyValue("I");
                Fam.value = args.getDataKeyValue("F");
                Ot.value = args.getDataKeyValue("O");
            }

            function TagRomove() {
                var ReasonRemoved = document.getElementById("<%= ReasonsRemovalTests.ClientID %>");
                ReasonRemoved.value = "Согласно письму МЗ № от ";

            }--%>


            </script>
            <%--  </telerik:RadCodeBlock>--%>

            <div id="mytimer" style="font-size: 17px; color: #333; line-height: 45px;">
                <div>осталось: </div>
                <div style="width: 70px; float: left; text-align: center">
                    <div style="font-family: Stencil; font-size: 65px;">0</div>
                    <div>Дней</div>
                </div>
                <div style="float: left; font-size: 45px;">:</div>
                <div style="width: 70px; float: left; text-align: center">
                    <div style="font-family: Stencil; font-size: 65px;">0</div>
                    <div>Часов</div>
                </div>
                <div style="float: left; font-size: 45px;">:</div>
                <div style="width: 70px; float: left; text-align: center">
                    <div style="font-family: Stencil; font-size: 65px;">0</div>
                    <div>Минут</div>
                </div>
                <div style="float: left; font-size: 45px;">:</div>
                <div style="width: 70px; float: left; text-align: center">
                    <div style="font-family: Stencil; font-size: 65px;">0</div>
                    <div>Секунд</div>
                </div>
            </div>


            <div id="timer_inp" runat="server">  </div>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </form>
</body>
</html>
