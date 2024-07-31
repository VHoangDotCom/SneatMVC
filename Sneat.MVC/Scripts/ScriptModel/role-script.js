function saveCreateRole() {
    var name = $('#nameCreate').val();
    var description = $('#txtDescription').val();

    var checkboxTree = $('#tree-role');
    var selectedNodes = checkboxTree.jstree("get_selected", true);
    var selectedNodeIds = selectedNodes.map(function (node) {
        return node.id;
    });

    if (name == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập tên vai trò!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    $.ajax({
        url: "/Roles/CreateRole",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            name: name,
            description: description,
            permissionIDs: selectedNodeIds
        }),
        beforeSend: function () {
            $("#modalLoad").modal("show");
        },
        success: function (response) {
            $("#modalLoad").modal("hide");
            if (response == -1) {
                Swal.fire({
                    title: 'Không thể tạo vai trò',
                    text: `Đã tồn tại vai trò có tên ${name}!`,
                    icon: 'warning',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
            }
            else if (response == 1) {
                Swal.fire({
                    title: 'Thành công!',
                    text: 'Tạo vai trò thành công!',
                    icon: 'success',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
                setTimeout(function () {
                    window.location = "/Roles/Index?";
                    //searchUser();
                }, 2000);
            }

            else {
                Swal.fire({
                    title: 'Có lỗi xảy ra!',
                    text: ' Không thể tạo vai trò!',
                    icon: 'error',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
            }
        }
    });
}
