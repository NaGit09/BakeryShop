const sidebar = document.getElementById("rightSidebar");
const toggleButton = document.getElementById("toggleSidebar");
let isClick = false;
// Mở sidebar
toggleButton.addEventListener("click", () => {
    if (!isClick) {
        sidebar.classList.add("show");
        isClick = true;
    } else {
        sidebar.classList.remove("show");
        isClick = false;
    }
});