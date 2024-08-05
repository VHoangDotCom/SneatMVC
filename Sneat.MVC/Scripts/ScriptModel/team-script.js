function searchTeam() {
    if (!navigator.onLine) {
        Swal.fire({
            title: 'Có lỗi xảy ra!',
            text: ' Kiểm tra kết nối internet!',
            icon: 'error',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }
    var key = $("#txt-key-search").val().replace(/\s\s+/g, ' ');

    $.ajax({
        url: '/Teams/Search',
        data: {
            page: 1,
            search: key
        },
        type: 'POST',
        success: function (response) {
            $("#list_team").html(response);
        },
        error: function (result) {
            console.log(result.responseText);
        }
    });
}