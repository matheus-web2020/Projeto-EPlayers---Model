using System.Collections.Generic;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Interfaces
{
    public interface IPartida
    {
         void Create(Partida p);
         List<Partida> ReadAll();
         void Update(Partida p);
         void Delete(int IdEquipe);
    }
}