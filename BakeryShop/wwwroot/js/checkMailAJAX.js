$(document).ready(function () {
    $("#email").on("blur", function () {
        console.log("Blur event triggered!");
        let email = $(this).val().trim();
        let emailSpan = $(this).siblings("span[asp-validation-for='Gmail']");  // Phần tử hiển thị thông báo
        let emailError = $("#email-error");  // Phần tử hiển thị lỗi

        // Reset lỗi cũ
        emailError.text("");

        // Kiểm tra nếu email không rỗng
        if (email) {
            // Gửi yêu cầu AJAX tới API
            $.ajax({
                url: 'https://localhost:7056/api/User/CheckMailLogin',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(email), // Gửi email dưới dạng chuỗi
                success: function (response) {
                    if (response.success == true) {
                        emailSpan.text("");
                        emailError.text(""); // Không có lỗi
                    } else {
                        emailSpan.text(""); // Xóa thông báo lỗi nếu không có lỗi
                        emailError.text("Email không tồn tại trong hệ thống"); // Xóa lỗi trong phần tử #email-error
                    }
                },
                error: function (xhr, status, error) {
                    console.log("Error:", error); // Log chi tiết lỗi
                    emailSpan.text(""); // Xóa thông báo lỗi cũ nếu có
                    emailError.text("Có lỗi xảy ra khi kiểm tra email: " + xhr.responseText); // Sử dụng responseText nếu có từ server
                
                }
            });
        } else {
            emailSpan.text("Email không được để trống.");
            emailError.text("Email không được để trống."); // Hiển thị lỗi "Email không được để trống"
        }
    });
});
