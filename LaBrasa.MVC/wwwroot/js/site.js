// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//const carousel = document.querySelector('.carousel');
//const prevButton = document.querySelector('.prev-button');
//const nextButton = document.querySelector('.next-button');

//let position = 0; // inicialize a posição do carrossel

//prevButton.addEventListener('click', () => {
//    position += carousel.offsetWidth; // adicione a largura do carrossel para mover para a esquerda
//    carousel.style.transform = `translateX(${position}px)`; // ajuste a posição do carrossel
//});

//nextButton.addEventListener('click', () => {
//    position -= carousel.offsetWidth; // subtraia a largura do carrossel para mover para a direita
//    carousel.style.transform = `translateX(${position}px)`; // ajuste a posição do carrossel
//});


const carousels = document.querySelectorAll('.carousel');

carousels.forEach((carousel) => {
    const carouselContainer = carousel.querySelector('.carousel-container');
    const cards = carousel.querySelectorAll('.card');
    const prevBtn = carousel.querySelector('.prev-btn');
    const nextBtn = carousel.querySelector('.next-btn');
    const cardWidth = cards[0].offsetWidth + parseInt(getComputedStyle(cards[0]).marginRight);
    let position = 0;

    prevBtn.addEventListener('click', () => {
        if (position < 0) {
            position += cardWidth;
            carouselContainer.style.transform = `translateX(${position}px)`;
        }
    });

    nextBtn.addEventListener('click', () => {
        if (position > -(cards.length - 1) * cardWidth) {
            position -= cardWidth;
            carouselContainer.style.transform = `translateX(${position}px)`;
        }
    });
});
/***********************************************/
