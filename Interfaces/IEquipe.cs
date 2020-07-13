using System.Collections.Generic;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Interfaces
{
    public interface IEquipe 
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();
         void Update(Equipe e);
         void Delete(int IdEquipe);

    }
}