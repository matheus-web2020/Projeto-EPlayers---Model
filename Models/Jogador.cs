using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto_MVC_1.Models
{
    public class Jogador : EPlayersBase , Interfaces.IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        //Jogador x pertence a equipe Y
        private const string PATH = "Database/jogador.csv";

        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Jogador j)
        {
            string[] linha = {PrepararLinha(j)};
            File.AppendAllLines(PATH,linha);
        }

        private string PrepararLinha(Jogador j){
       
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe}";
        }

        public void Delete(int IdEquipe)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(z => z.Split(";")[0] == IdJogador.ToString());
            RewriteCSV(PATH,linhas);
        }
 
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();
                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.IdEquipe = Int32.Parse(linha[2]);
                
                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public void Update(Jogador j)
        {
           List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(z => z.Split(";")[0] == IdJogador.ToString());
            linhas.Add(PrepararLinha(j));
            RewriteCSV(PATH,linhas);
        }
        

    }
}