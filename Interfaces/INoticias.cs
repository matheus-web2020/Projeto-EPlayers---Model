using System.Collections.Generic;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Interfaces
{
    public interface INoticias
    {
         void Create(Noticias n);
         List<Noticias> ReadAll();
         void Update(Noticias n);
         void Delete(int IdNoticia);
    }
}