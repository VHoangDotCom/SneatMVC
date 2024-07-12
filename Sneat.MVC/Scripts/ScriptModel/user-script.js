function searchUser() {
    if (!navigator.onLine) {
        swal({
            title: "Check internet connection!",
            text: "",
            icon: "warning"
        })
        return;
    }
    var key = $("#txt-key-search").val().replace(/\s\s+/g, ' ');

    $.ajax({
        url: '/Users/Search',
        data: {
            page: 1,
            search: key
        },
        type: 'POST',
        success: function (response) {
            $("#list_user").html(response);
        },
        error: function (result) {
            console.log(result.responseText);
        }
    });
}