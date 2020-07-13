using System.Collections.Generic;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Interfaces
{
    public interface INoticia
    {
         void Create(Noticia n);
         List<Noticia> ReadAll();
         void Update(Noticia n);
         void Delete(int IdNoticia);
    }
}