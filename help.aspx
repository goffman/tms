<%@ Page Language="C#" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="help" MasterPageFile="~/MasterPage.master" Title="Справка" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="BodyContent">
    <script src="js/ifvisible.js"></script>


    <%--    <script type="text/javascript">
        function d(el) {
            return document.getElementById(el);
        }
        ifvisible.setIdleDuration(20);

        //ifvisible.on('statusChanged', function (e) {
        //    d("result").innerHTML += (e.status + "<br>");
        //});

        ifvisible.idle(function () {
            location.href = 'http://localhost:50896/';
        });

        //ifvisible.wakeup(function () {
        //    d("result2").innerHTML = "(O_o) Hey!, you woke me up.";
        //    document.body.style.opacity = 1;
        //});

        ifvisible.onEvery(0.5, function () {
            // Clock, as simple as it gets
            var h = (new Date()).getHours();
            var m = (new Date()).getMinutes();
            var s = (new Date()).getSeconds();
            h = h < 10 ? "0" + h : h;
            m = m < 10 ? "0" + m : m;
            s = s < 10 ? "0" + s : s;
            // Update clock
            d("result3").innerHTML = (h + ':' + m + ':' + s);
        });

        setInterval(function () {
            var info = ifvisible.getIdleInfo();
            // Give 3% margin to stabilaze user output
            if (info.timeLeftPer < 3) {
                info.timeLeftPer = 0;
                info.timeLeft = ifvisible.getIdleDuration();
            }
            d("seconds").innerHTML = parseInt(info.timeLeft / 1000), 10;
            d("idlebar").style.width = info.timeLeftPer + '%';
        }, 100);
        </script>--%>

    <%--<script type="text/javascript">
        var dur = (ifvisible.getIdleDuration() / 1000);
        alert(dur + " seconds");
        d('seconds').innerHTML = dur;
        d('idleTime').innerHTML = dur + " seconds";
            </script>--%>

    Система тестирования располагается в интернете по адресу:<a href="http://tms.miacrh.ru/">http://tms.miacrh.ru/</a> (далее - сайт).
    <br />
    Рекомендуется использовать браузеры последних версий, такие как:
    <ul>
        <li>Google Chrome.
        </li>
        <li>Firefox.</li>
        <li>Internet Explorer (версии 9).</li>
    </ul>
    Для начало процедуры тестирования необходимо пройти регистрацию в системе. 
    <br />
    <br />
    <span>
         <img alt="" src="img/help/ScreenShot%2035.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
        <br />
    </span>
    <br />
    В форме регистрации пользователь заполняет перечисленные поля: ФИО, контактный номер телефона, адрес электронной почты, специальность, место работы, должность, стаж работы. Из списка необходимо выбрать группу должностей (для тестирования врачей - группа «Медицинский и фармацевтический персонал», для среднего медицинского персонала - &quot;Средний медицинский персонал&quot;). Далее из списка специальностей выбирается та специальность, по которой будет проходить тестирование. По завершению заполнения формы необходимо нажать на кнопку «Регистрация». 
    <br />
    <br />
 <img alt="" src="img/help/ScreenShot%2036.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />

    <br />
    На указанный e-mail придет письмо с логином, паролем, ссылкой на активацию учетной записи и кодом активации. 
    <br />
    <br />
    <img alt="" src="img/help/ScreenShot%2037.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <br />
    Активировать учетную запись можно следующими способами: 
    <ul>
        <li>Используя ссылку активации, отправленную на e-mail.</li>
        <li>Используя код активации отправленный на e-mail в личном кабинете.</li>

    </ul>
    <img alt="" src="img/help/ScreenShot%2040.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <img alt="" src="img/help/ScreenShot%2039.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <br />
    В случае если ФИО пользователя отсутствует в списке на прохождение аттестации, система отображает уведомление о необходимости модерации. 
    <br />
    Вход в личный кабинет пользователя осуществляется по логину и паролю. 
    <br />
    <br />
    <img alt="" src="img/help/ScreenShot%2038.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <br />
    После авторизации на сайте, появляется личный кабинет пользователя. Перед началом тестирования, есть возможность пройти пробное тестирование обучение. В данном разделе представлен ограниченный тест, который позволит ознакомиться со всей процедурой прохождения теста. Для начала тестирования, в личном кабинете, необходимо выбрать тест из раздела «Тесты доступные для прохождения».<br />
    <br />
    <img alt="" src="img/help/ScreenShot%2041.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <br />
    &nbsp;Далее откроется окно с описанием теста. Для начала тестирования необходимо нажать на кнопку «Начать тест». Окно тестирования состоит из 2 блоков: в первом блоке отображается вопрос, во втором – ответы на вопрос. Некоторые вопросы предусматривают несколько вариантов ответа. После выбора 
    ответа необходимо нажать на кнопку «Следующий вопрос». По завершению тестирования пользователя информирует о количестве правильно данных ответов в процентном соотношении.<br />
    <br />
    <img alt="" src="img/help/ScreenShot%2042.png" class="img-polaroid" style="width: 50%; height: 50%" /><br />
    <br />
    &nbsp;После этого данные о результатах тестирования направляются в Министерство здравоохранения Республики Хакасия testmedspec@r-19.ru, либо по тел. 295025.&nbsp;
</asp:Content>

