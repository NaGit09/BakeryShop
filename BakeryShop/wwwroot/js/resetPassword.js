document.addEventListener("DOMContentLoaded", function () {
    // Lấy giá trị từ các thẻ ẩn
    var messageElement = document.getElementById("tempDataSwalMessage");
    var typeElement = document.getElementById("tempDataSwalType");

    // Kiểm tra nếu các phần tử tồn tại và có giá trị
    var message = messageElement?.value?.trim(); // Loại bỏ khoảng trắng thừa
    var type = typeElement?.value?.trim();

    // Xử lý SweetAlert chỉ khi có đủ dữ liệu hợp lệ
    if (message && type && (type === "success" || type === "error")) {
        Swal.fire({
            title: type === "success" ? "Thành công!" : "Thất bại!",
            text: message,
            icon: type,
            confirmButtonText: "OK"
        }).then((result) => {
            if (result.isConfirmed) {
                // Chuyển hướng đến trang khác
                if (type === "success") {
                    window.location.href = "/BakeryShop/login"; 
                } else {
                    window.location.href = "/BakeryShop/login"; 
                }
            }
        });
    }
});



