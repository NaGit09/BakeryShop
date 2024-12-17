const menuLi = document.querySelectorAll(
  `.admin-sidebar-content > ul > li > a`
);
const submenu = document.querySelectorAll(`.sub-menu`);
for (let index = 0; index < menuLi.length; index++) {
  menuLi[index].addEventListener(`click`, function (event) {
    event.preventDefault();
    for (let i = 0; i < submenu.length; i++) {
      submenu[i].setAttribute(`style`, `height:0px;`);
    }
    const submenuHeight =
      menuLi[index].parentNode.querySelector(`ul .sub-menu-items`).offsetHeight;
    menuLi[index].parentNode
      .querySelector(`ul`)
      .setAttribute(`style`, `height:` + submenuHeight + `px;`);
  });
}

const adminMenu = document.querySelector(`.admin-menu`);
const sub = document.querySelector(`.sub-menu-admin-container`);
adminMenu.addEventListener(`click`, function (event) {
  sub.classList.toggle(`hidden`);
  event.stopPropagation();
});

const titleByDate = document.querySelector(`.label-table i`);
const calender = document.querySelector(`#calender`);
const datePicker = document.querySelector(`#date-picker`);
const dateLabel = document.querySelector(`.label-table h3`);

const today = new Date();
const formatDate = today.toISOString().split(`T`)[0];

datePicker.setAttribute(`min`, `2024-10-01`);
datePicker.setAttribute(`max`, formatDate);

titleByDate.addEventListener(`click`, function () {
  calender.classList.toggle(`hidden`);
});
datePicker.addEventListener(`change`, ()=>{
  const selectDate = datePicker.value;
  if(selectDate){
    dateLabel.textContent = `Danh sách đơn hàng theo ngày ${selectDate}`;
  }else{
    dateLabel.textContent = `Danh sách đơn hàng`;
  }
})
