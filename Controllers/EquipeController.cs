using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EPLAYERS_MVC.Models;

namespace E_PLAYERS_MVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        //retorna a página view // Método padrão

        Equipe EquipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = EquipeModel.LerEquipes();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe NovaEquipe = new Equipe();
            NovaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            NovaEquipe.Nome = form["Nome"];
            NovaEquipe.Imagem = form["Imagem"];

            EquipeModel.Criar(NovaEquipe);

            ViewBag.Equipes = EquipeModel.LerEquipes();
            //ViewBag = salva variáveis em um local acessível a view

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}