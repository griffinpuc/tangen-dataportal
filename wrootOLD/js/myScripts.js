function UpdateButton() {
    $.ajax({
        url: '@Url.Action("UpdateButton", "Home")',
        success: function (data) {
            $('#partialview_button').html(data);
        }
    });
}

function UpdateConnections() {
    $.ajax({
        url: '@Url.Action("UpdateConnections", "Home")',
        success: function (data) {
            $('#partialview_instruments').html(data);
        }
    });
}

function UpdateModel() {
    $.ajax({
        url: '@Url.Action("UpdateModel", "Home")',
        success: function (data) {
            $('#partialview_data').html(data);
        }
    });
}

function LoadMore() {
    $.ajax({
        url: '@Url.Action("LoadMore", "Home")',
        success: function (data) {
            $('#partialview_data').html(data);
        }
    });
}

function SortNew() {
    $.ajax({
        url: '@Url.Action("SortNew", "Home")',
        success: function (data) {
            $('#partialview_data').html(data);
        }
    });
}

function SortOld() {
    $.ajax({
        url: '@Url.Action("SortOld", "Home")',
        success: function (data) {
            $('#partialview_data').html(data);
        }
    });
}

function UpdateFromSearch() {
    var term = document.getElementById('searchbar').value
    $.ajax({
        url: '@Url.Action("UpdateFromSearch", "Home")',
        data: { term },
        success: function (data) {
            $('#partialview_data').html(data);
        }
    });
    UpdateButton();
}

window.setInterval(function () {
    UpdateConnections();
    UpdateButton();
}, 500);