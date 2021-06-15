using System;
using System.Collections.Generic;
using System.IO;
using Projeto_EPLAYERS_MVC.Interfaces;

namespace Projeto_EPLAYERS_MVC.Models
{
    public class Equipe : BaseEPlayers, IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string CAMINHO = "DataBase/Equipe.csv";

        public Equipe()
        {
            CriarPastaArquivo(CAMINHO);
        }

        private string Preparar(Equipe E)
        {
            return $"{E.IdEquipe};{E.Nome};{E.Imagem}";
        }

        public void Alterar(Equipe E)
        {
            List<string> linhas = LerLinhasArquivo(CAMINHO);
            linhas.RemoveAll(item => item.Split(";")[0] == E.IdEquipe.ToString());

            linhas.Add(Preparar(E));
            Reescrever(CAMINHO, linhas);
        }

        public void Criar(Equipe E)
        {
            string[] linha = {Preparar(E)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int Id)
        {
            List<string> linhas = LerLinhasArquivo(CAMINHO);
            linhas.RemoveAll(item => item.Split(";")[0] == Id.ToString());

            Reescrever(CAMINHO, linhas);
        }

        public List<Equipe> LerEquipes()
        {
            List<Equipe> ListaEquipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] CadaLinha = item.Split(";");
                Equipe equipe = new Equipe();

                equipe.IdEquipe = Int32.Parse(CadaLinha[0]);
                equipe.Nome = CadaLinha[1];
                equipe.Imagem = CadaLinha[2];

                ListaEquipes.Add(equipe);
            }

            return ListaEquipes;
        }
    }
}