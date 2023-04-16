// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const api = function (endpoint, data) {
    $.ajax({
        type: 'PUT',
        url: $('#JoinLobbyUrl').val() + "/" + accountId + "/" + code,
        success: function (response) {
            window.location.href = $('#LobbyUrl').val() + "/" + accountId + "/" + response.id
        }
    });
}

const startLoading = function() {
    $(".loading").addClass("active")
}
const stopLoading = function() {
    $(".loading").removeClass("active")
}

const ajaxBody = function (data) {
    startLoading();
    $.ajax({
        type: data.type,
        url: data.url,
        data: JSON.stringify(data.data),
        contentType: 'application/json',
        success: function (response) {
            stopLoading();
            if (data.success)
                data.success(response);
        },
        error: function (response) {
            stopLoading();
            if (data.error)
                data.error(response);
            alert(response.responseText)
        }
    });
}
const ajaxQuery = function (data) {
    startLoading();
    $.ajax({
        type: data.type,
        url: data.url,
        data: data.data,
        success: function (response) {
            stopLoading();
            if (data.success)
                data.success(response);
        },
        error: function (response) {
            stopLoading();
            if (data.error)
                data.error(response);
            alert(response.responseText)
        }
    });
}