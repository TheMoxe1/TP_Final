const productContainers = [...document.querySelectorAll('.product-container')];
const nxtBtn = [...document.querySelectorAll('.nxt-btn')];
const preBtn = [...document.querySelectorAll('.pre-btn')];

productContainers.forEach((item, i) => {
    let containerDimensions = item.getBoundingClientRect();
    let containerWidth = containerDimensions.width;

    nxtBtn[i].addEventListener('click', () => {
        item.scrollLeft += containerWidth;
    })

    preBtn[i].addEventListener('click', () => {
        item.scrollLeft -= containerWidth;
    })
})


document.getElementById('menuBtn').addEventListener('click', openMenu);

function openMenu() {
  document.getElementById('overlay').style.display = 'block';
  document.getElementById('menuCard').style.display = 'block';
}

function closeMenu() {
  document.getElementById('overlay').style.display = 'none';
  document.getElementById('menuCard').style.display = 'none';
}