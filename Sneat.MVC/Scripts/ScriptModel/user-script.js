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

function saveCreateUser() {
    var name = $('#nameCreate').val();
    var email = $('#emailCreate').val();
    var phone = $('#input-add-phone').val();
    var password = $('#txt-pass').val();
    var passwordConfirm = $('#txt-pass-confirm').val();
    var avatar = $('#currentImage').val();

    if (name == "" ) {
      /*  swal({
            title: "Thông báo",
            text: "Vui lòng nhập tên người dùng!",
            icon: "warning"
        })*/
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập tên người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (phone == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập số điện thoại người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (email == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập Email người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (password == "") {
        swal({
            title: "Thông báo",
            text: "Vui lòng nhập mật khẩu người dùng!",
            icon: "warning"
        })
        return;
    }

    var phone_validate = new RegExp("^[0-9]{9,11}");
    if (!phone_validate.test(phone)) {
        Swal.fire({
            title: 'Thông báo!',
            text: 'Số điện thoại không đúng định dạng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    var email_validate = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    if (!email_validate.test(email)) {
        Swal.fire({
            title: 'Thông báo!',
            text: 'Email không đúng định dạng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (password != passwordConfirm) {
        Swal.fire({
            title: 'Thông báo!',
            text: 'Xác nhận mật khẩu không đúng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    $.ajax({
        url: "/Users/CreateUser",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            name: name,
            email: email,
            phone: phone,
            password: password,
            avatar: avatar,
        }),
        beforeSend: function () {
            $("#modalLoad").modal("show");
        },
        success: function (response) {
            $("#modalLoad").modal("hide");
            if (response == -1) {
                Swal.fire({
                    title: 'Không thể tạo tài khoản',
                    text: 'Email này đã được sử dụng!',
                    icon: 'warning',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
            }
            else if (response == -2) {
                Swal.fire({
                    title: 'Không thể tạo tài khoản',
                    text: 'Số điện thoại đã được sử dụng!',
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
                    text: 'Tạo tài khoản thành công!',
                    icon: 'success',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
                setTimeout(function () {
                    window.location = "/Users/Index?";
                    searchUser();
                }, 2000);
            }
           
            else {
                Swal.fire({
                    title: 'Có lỗi xảy ra!',
                    text: ' Không thể tạo tài khoản!',
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

function saveUpdateUser(ID) {
    var name = $('#nameCreate').val();
    var email = $('#emailCreate').val();
    var phone = $('#input-add-phone').val();
    var avatar = $('#currentImage').val();

    if (name == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập tên người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (phone == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập số điện thoại người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    if (email == "") {
        Swal.fire({
            title: 'Thông báo!',
            text: ' Vui lòng nhập Email người dùng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    var phone_validate = new RegExp("^[0-9]{9,11}");
    if (!phone_validate.test(phone)) {
        Swal.fire({
            title: 'Thông báo!',
            text: 'Số điện thoại không đúng định dạng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    var email_validate = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    if (!email_validate.test(email)) {
        Swal.fire({
            title: 'Thông báo!',
            text: 'Email không đúng định dạng!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: false
        });
        return;
    }

    $.ajax({
        url: "/Users/UpdateUser",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            id: ID,
            name: name,
            phone: phone,
            email: email,
            avatar: avatar,
        }),
        beforeSend: function () {
            $("#modalLoad").modal("show");
        },
        success: function (response) {
            $("#modalLoad").modal("hide");
            if (response == -1) {
                Swal.fire({
                    title: 'Không thể cập nhật tài khoản',
                    text: 'Email này đã được sử dụng!',
                    icon: 'warning',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
            }
            else if (response == -3) {
                Swal.fire({
                    title: 'Cập nhật tài khoản thất bại!',
                    text: 'Tài khoản hiện không tồn tại hoặc đã bị xóa!',
                    icon: 'warning',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
            }
            else if (response == -2) {
                Swal.fire({
                    title: 'Không thể cập nhật tài khoản',
                    text: 'Số điện thoại đã được sử dụng!',
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
                    text: 'Cập nhật tài khoản thành công!',
                    icon: 'success',
                    customClass: {
                        confirmButton: 'btn btn-primary'
                    },
                    buttonsStyling: false
                });
                setTimeout(function () {
                    window.location = "/Users/Index?";
                    searchUser();
                }, 2000);
            }

            else {
                Swal.fire({
                    title: 'Có lỗi xảy ra!',
                    text: ' Không thể cập nhật tài khoản!',
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

function deleteUser(id) {
    if (!navigator.onLine) {
        swal({
            title: "Kiểm tra kết nối internet!",
            text: "",
            icon: "warning"
        })
        return;
    }
    Swal.fire({
        title: 'Bạn chắc chắn xóa chứ?',
        text: "Dữ liệu tài khoản sẽ bị xóa?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Vâng, tôi xác nhận!',
        customClass: {
            confirmButton: 'btn btn-primary me-3',
            cancelButton: 'btn btn-label-secondary'
        },
        buttonsStyling: false
    }).then(function (resultConfirm) {
        console.log(resultConfirm)
        if (resultConfirm.isConfirmed) {
            $.ajax({
                url: '/Users/DeleteUser',
                data: { id: id },
                type: "POST",
                success: function (result) {
                    if (result == 1) {
                        Swal.fire({
                            title: 'Thành công!',
                            text: 'Xóa tài khoản thành công!',
                            icon: 'success',
                            customClass: {
                                confirmButton: 'btn btn-primary'
                            },
                            buttonsStyling: false
                        });
                        setTimeout(function () {
                            window.location = "/Users/Index?";
                            searchUser();
                        }, 2000);
                    } else if (result == -3) {
                        Swal.fire({
                            title: 'Xóa tài khoản thất bại!',
                            text: 'Tài khoản hiện không tồn tại hoặc đã bị xóa!',
                            icon: 'warning',
                            customClass: {
                                confirmButton: 'btn btn-primary'
                            },
                            buttonsStyling: false
                        });
                        setTimeout(
                            function () {
                                window.location = "/Users/Index?";
                                searchUser();
                            }, 1000);

                    }
                    else {
                        Swal.fire({
                            title: 'Có lỗi xảy ra!',
                            text: ' Không thể xóa tài khoản!',
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
    });
   
}