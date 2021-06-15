using System.Collections.Generic;
using Projeto_EPLAYERS_MVC.Models;

namespace Projeto_EPLAYERS_MVC.Interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe E);

        List<Equipe> LerEquipes();

        void Alterar(Equipe E);

        void Deletar(int Id);
    }
}