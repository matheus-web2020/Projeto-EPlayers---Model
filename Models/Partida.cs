using System;
using System.Collections.Generic;

namespace Projeto_MVC_1.Models
{
    public class Partida : EPlayersBase , Interfaces.IPartida
    {
        public int IdPartida { get; set; }
        public int IdEquipe1 { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime Horario { get; set; }

        public void Create(Partida p)
        {
            
        }

        public void Delete(int IdEquipe1, int IdEquipe2)
        {
           
            
        }

        public List<Partida> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Partida p)
        {
            
        }
    }
}