$(document).ready(function () {
    $("#TextBox1").autocomplete({
        source: function (request, response) {
            var param = { keyword: $('#TextBox1').val() };
            $.ajax({
                url: "search.aspx/GetFam",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        //select: function (event, ui) {
        //    if (ui.item) {
        //        GetCustomerDetails(ui.item.value);
        //    }
        //},
        minLength: 2
    });
});

$(document).ready(function () {
    $("#im").autocomplete({
        source: function (request, response) {
            var param = { keyword: $('#im').val(), f: $('#fam').val() };

            $.ajax({
                url: "bdz.aspx/Getim",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        //select: function (event, ui) {
        //    if (ui.item) {
        //        GetCustomerDetails(ui.item.value);
        //    }
        //},
        minLength: 1
    });
});

$(document).ready(function () {
    $("#ot").autocomplete({
        source: function (request, response) {
            var param = { keyword: $('#ot').val(), f: $('#fam').val(), i: $('#im').val() };

            $.ajax({
                url: "bdz.aspx/GetOt",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        //select: function (event, ui) {
        //    if (ui.item) {
        //        GetCustomerDetails(ui.item.value);
        //    }
        //},
        minLength: 1
    });
});

Ext.onReady(function () {
    var store = new Ext.data.JsonStore({
        url: 'bdz.aspx/GetTest',
        root: 'fam',
        fields: ['fam'],
        remoteSort: true,
        autoLoad: true
    });
    var cm = new Ext.grid.ColumnModel({
        columns: [
                    { header: 'fam', width: 50, dataIndex: 'Id' }
                   
        ]
    });
    var grid = new Ext.grid.GridPanel({
        title: 'Employees',
        store: store,
        colModel: cm,
        renderTo: Ext.get('divGrid'),
        width: 500,
        height: 350,
        border: true,
        loadMask: true
    });
});

//function GetCustomerDetails(country) {

//    $("#tblCustomers tbody tr").remove();

//    $.ajax({
//        type: "POST",
//        url: "Default.aspx/GetCustomers",
//        data: '{country: "' + country + '" }',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            response($.map(data.d, function (item) {
//                var rows = "<tr>"
//                    + "<td class='customertd'>" + item.CustomerID + "</td>"
//                    + "<td class='customertd'>" + item.CompanyName + "</td>"
//                    + "<td class='customertd'>" + item.ContactName + "</td>"
//                    + "<td class='customertd'>" + item.ContactTitle + "</td>"
//                    + "<td class='customertd'>" + item.City + "</td>"
//                    + "<td class='customertd'>" + item.Phone + "</td>"
//                    + "</tr>";
//                $('#tblCustomers tbody').append(rows);
//            }))
//        },
//        failure: function (response) {
//            alert(response.d);
//        }
//    });
//}