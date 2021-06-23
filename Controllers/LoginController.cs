using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EPLAYERS_MVC.Models;

namespace E_PLAYERS_MVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string MensagemErro { get; set; }
        Jogador JogadorModel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> JogadoresCSV = JogadorModel.LerLinhasArquivo("DataBase/Jogador.csv");

            var Logado =  JogadoresCSV.Find(item => item.Split(";")[2] == form["Email"] && item.Split(";")[3] == form["Senha"]);

            if (Logado != null)
            {
                HttpContext.Session.SetString("_NomeUsuario", Logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            MensagemErro = "Dados incorretos. Tente novamente!";

            return LocalRedirect("~/Login");
        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_NomeUsuario");
            return LocalRedirect("~/");
        }
    }
}