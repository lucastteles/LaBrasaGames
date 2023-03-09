// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const carousel = document.querySelector('.carousel');
const prevButton = document.querySelector('.prev-button');
const nextButton = document.querySelector('.next-button');

let position = 0; // inicialize a posição do carrossel

prevButton.addEventListener('click', () => {
    position += carousel.offsetWidth; // adicione a largura do carrossel para mover para a esquerda
    carousel.style.transform = `translateX(${position}px)`; // ajuste a posição do carrossel
});

nextButton.addEventListener('click', () => {
    position -= carousel.offsetWidth; // subtraia a largura do carrossel para mover para a direita
    carousel.style.transform = `translateX(${position}px)`; // ajuste a posição do carrossel
});