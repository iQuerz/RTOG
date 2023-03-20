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