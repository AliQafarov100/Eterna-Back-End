let left = document.querySelector(".fa-chevron-left");
let right = document.querySelector(".fa-chevron-right");
let slider = document.querySelector(".slider");
let points = document.querySelectorAll(".points");
let arrow = document.querySelector(".arrow");



window.addEventListener("scroll",function(){
    if(window.scrollY == 0){
        arrow.style.opacity = "0";
    }
    else{
        arrow.style.opacity = "1"
    }
})

points.forEach(point => {
    point.addEventListener("click",function(e){
        e.preventDefault();
        let dataId = point.getAttribute("data-id");
        let active = document.querySelector(".active");
        let items = document.querySelectorAll(".items");
        active.classList.remove("active");  

        point.style.backgroundColor = "blue";

        items.forEach(item => {
            let itemdataId = item.getAttribute("data-id");
            

            if(itemdataId == dataId){
                item.classList.add("active");
            }
            
        })
    })
})

right.addEventListener("click", function(){
    
    let active = document.querySelector(".active");
    active.classList.remove("active");

    if(active.nextElementSibling == null){
        slider.firstElementChild.classList.add("active");
    }
    else{
        active.nextElementSibling.classList.add("active");
    }
})


left.addEventListener("click",function() {
    let active = document.querySelector(".active");
    active.classList.remove("active");

    if(active.previousElementSibling == null){
        slider.lastElementChild.classList.add("active");
    }
    else{
        active.previousElementSibling.classList.add("active");
    }
})

setInterval(() => {
    let active = document.querySelector(".active");
    active.classList.remove("active");

    if(active.nextElementSibling == null){
        slider.firstElementChild.classList.add("active");
    }
    else{
        active.nextElementSibling.classList.add("active");
    }
},5000);

$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})