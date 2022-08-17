

const Hamburger = document.querySelector('.header .navbar .navlist .hamburger');
const MobileMenu = document.querySelector('.header .navbar .navlist ul');
const Header = document.querySelector('.header.container');

function ToggleHamburger() {
    Hamburger.classList.toggle('active');
    MobileMenu.classList.toggle('active');
}

function HeaderBg() {
    var pos = window.scrollY;
    if (pos > 250) {
        Header.style.backgroundColor = "black";
    }
    else {
        Header.style.backgroundColor = "rgba(0, 0, 0, 0.445)";
    }
}

