let arrow = document.querySelector(".arrow");
let menu = document.querySelector(".responsive-menu");
let clickBar = document.querySelector(".fa-bars");
let deletebar = document.querySelector(".fa-x");

window.addEventListener("scroll",function(){
    if(window.scrollY == 0){
        arrow.style.opacity = "0";
    }
    else{
        arrow.style.opacity = "1"
    }
})

clickBar.addEventListener("click",function(){
    menu.style.visibility = "visible"
})

deletebar.addEventListener("click",function(){
    menu.style.visibility = "hidden";
})

