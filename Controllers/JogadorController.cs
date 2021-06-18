using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EPLAYERS_MVC.Models;

namespace E_PLAYERS_MVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {

        Jogador JogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = JogadorModel.LerJogadores();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador NovoJogador = new Jogador();
            
            NovoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            NovoJogador.Nome = form["Nome"];
            NovoJogador.Email = form["Email"];
            NovoJogador.Senha = form["Senha"];
            NovoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);

            JogadorModel.Criar(NovoJogador);

            ViewBag.Jogadores = JogadorModel.LerJogadores();

            //LocalRedirect - recarrega a página
            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            JogadorModel.Deletar(id);
            ViewBag.Jogadores =  JogadorModel.LerJogadores();

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}