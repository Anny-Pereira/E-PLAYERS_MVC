// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function BotaoMenu() {
    var menu = document.getElementById("itens_header")
    if (menu.style.display === "flex") {
        menu.style.display = "none";
     //quando o menu estiver em display:flex, o esconda
    }
    else {
        menu.style.display = "flex";
     //se o menu não estiviver em display:flex, o mostre
    }
}