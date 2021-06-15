using System.Collections.Generic;
using Projeto_EPLAYERS_MVC.Models;

namespace Projeto_EPLAYERS_MVC.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador J);

        List<Jogador> LerJogadores();

        void Alterar(Jogador J);

        void Deletar(int Id);
    }
}