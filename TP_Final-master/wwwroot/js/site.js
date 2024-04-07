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

document.getElementById('menuBtn').addEventListener('click', openMenu);

function openMenu() {
    var overlay = document.getElementById('overlay');
    var menuCard = document.getElementById('menuCard');

    overlay.style.display = 'block';
    menuCard.style.display = 'block';
  }

  function closeMenu() {
    var overlay = document.getElementById('overlay');
    var menuCard = document.getElementById('menuCard');

    overlay.style.display = 'none';
    menuCard.style.display = 'none';
  }

  function validarContraseña(event, contra, contra2){  
    const regex = /^(?=.*[A-Z])(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}$/;
    if(regex.test(contra) && contra === contra2){
        return true;
    }
    else 
    if(!regex.test(contra)){
        alert("La contraseña no cumple con los requisitos");
        return false;
    }else{
        alert("Las contraseñas no coinciden");
        return false;
    }

}

