using System.Collections.Generic;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Interfaces
{
    public interface IJogador
    {
         void Create(Jogador j);
         List<Jogador> ReadAll();
         void Update(Jogador j);
         void Delete(int IdEquipe);
    }
}