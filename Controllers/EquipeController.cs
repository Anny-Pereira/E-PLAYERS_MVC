using System;
using System.IO;
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
            // NovaEquipe.Imagem = form["Imagem"];

            if (form.Files.Count > 0)
            {
                // uplopad início

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);

                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                NovaEquipe.Imagem = file.FileName;

                // uplopad final

            }
            else
            {
                NovaEquipe.Imagem = "padrao.png";
            }

            EquipeModel.Criar(NovaEquipe);

            ViewBag.Equipes = EquipeModel.LerEquipes();
            //ViewBag = salva variáveis em um local acessível a view

            return LocalRedirect("~/Equipe/Listar");
        }


        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            EquipeModel.Deletar(id);
            ViewBag.Equipes = EquipeModel.LerEquipes();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}