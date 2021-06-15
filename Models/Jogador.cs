using System;
using System.Collections.Generic;
using System.IO;
using Projeto_EPLAYERS_MVC.Interfaces;

namespace Projeto_EPLAYERS_MVC.Models
{
    public class Jogador : BaseEPlayers, IJogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string IdEquipe { get; set; }

        private const string CAMINHO = "DataBase/Jogador.csv";

        public Jogador()
        {
            CriarPastaArquivo(CAMINHO);
        }

        private string Preparar(Jogador J)
        {
            return $"{J.IdEquipe};{J.Nome}";
        }

        public void Alterar(Jogador J)
        {
            List<string> linhas = LerLinhasArquivo(CAMINHO);
            linhas.RemoveAll(item => item.Split(";")[0] == J.IdJogador.ToString());

            linhas.Add(Preparar(J));
            Reescrever(CAMINHO, linhas);
        }

        public void Criar(Jogador J)
        {
            string[] linha = { Preparar(J) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int Id)
        {
            List<string> linhas = LerLinhasArquivo(CAMINHO);
            linhas.RemoveAll(item => item.Split(";")[0] == Id.ToString());

            Reescrever(CAMINHO, linhas);
        }

        public List<Jogador> LerJogadores()
        {
            List<Jogador> ListaJogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] CadaLinha = item.Split(";");
                Jogador jogador = new Jogador();

                jogador.IdJogador = Int32.Parse(CadaLinha[0]);
                jogador.Nome = CadaLinha[1];

                ListaJogadores.Add(jogador);
            }

            return ListaJogadores;
        }
    }
}