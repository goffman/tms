//Поиск людей по ФИО в БД. Мастер 
$(document).ready(function () {
    $("#SearcAt").autocomplete({
        source: function (request, response) {
            var param = { keyword: $('#SearcAt').val() };
            $.ajax({
                url: "/admin/webmetod.aspx/GetFam",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        };
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        minLength: 2
    });
});




