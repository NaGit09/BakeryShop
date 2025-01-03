// Các biến tham chiếu đến các dropdown
const yearSelect = document.getElementById("yearSelect");
const monthSelect = document.getElementById("monthSelect");
const daySelect = document.getElementById("daySelect");

// Tạo danh sách năm từ 1900 đến năm hiện tại
const currentYear = new Date().getFullYear();
for (let year = 2024; year > 1970; year--) {
    const option = document.createElement("option");
    option.value = year;
    option.textContent = year;
    yearSelect.appendChild(option);
}

// Tạo danh sách tháng từ 1 đến 12
for (let month = 1; month <= 12; month++) {
    const option = document.createElement("option");
    option.value = month;
    option.textContent = `Tháng ${month}`;
    monthSelect.appendChild(option);
}

// Cập nhật danh sách ngày dựa trên năm và tháng đã chọn
function updateDays() {
    const selectedYear = parseInt(yearSelect.value);
    const selectedMonth = parseInt(monthSelect.value);

    // Kiểm tra giá trị hợp lệ của năm và tháng
    if (isNaN(selectedYear) || isNaN(selectedMonth)) {
        daySelect.innerHTML = '<option selected value="Ngày">Ngày</option>';
        return;
    }

    // Xác định số ngày trong tháng
    const daysInMonth = new Date(selectedYear, selectedMonth, 0).getDate();

    // Tạo danh sách ngày
    daySelect.innerHTML = '<option selected value="Ngày">Ngày</option>';
    for (let day = 1; day <= daysInMonth; day++) {
        const option = document.createElement("option");
        option.value = day;
        option.textContent = day;
        daySelect.appendChild(option);
    }
}

// Lắng nghe sự kiện thay đổi trên dropdown năm và tháng
yearSelect.addEventListener("change", updateDays);
monthSelect.addEventListener("change", updateDays);

const passwordInput = document.getElementById("passwordInput");
const togglePassword = document.getElementById("togglePassword");
togglePassword.addEventListener("click", () => {
    const type = passwordInput.type === "password" ? "text" : "password";
    passwordInput.type = type;
    togglePassword.textContent = type === "password" ? "👁️" : "🙈";
});
const CheckPasswordInput = document.getElementById("CheckPasswordInput");
const CheckTogglePassword = document.getElementById("CheckTogglePassword");
CheckTogglePassword.addEventListener("click", () => {
    const type = CheckPasswordInput.type === "password" ? "text" : "password";
    CheckPasswordInput.type = type;
    CheckTogglePassword.textContent = type === "password" ? "👁️" : "🙈";
});