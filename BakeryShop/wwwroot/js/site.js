const header = document.querySelector("header");
let prevScrollPos = window.scrollY;
window.addEventListener("scroll", () => {
    let CurrentScroll = window.scrollY;
    if (CurrentScroll > prevScrollPos) {
        header.style.transform = `translateY(-105%)`;
    }
    else {
        header.style.transform = `translateY(0)`;

    }
    prevScrollPos = CurrentScroll;
});