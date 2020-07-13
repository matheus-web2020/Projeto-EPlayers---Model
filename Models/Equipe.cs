using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto_MVC_1.Models
{
    public class Equipe : EPlayersBase , Interfaces.IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Cria as equipes
        /// </summary>
        /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[] linhas = {PrepararLinha(e)};
           File.AppendAllLines(PATH,linhas);

        }
        /// <summary>
        /// Mostra os dados das equipes
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        /// <summary>
        /// Lê os dados das equipes
        /// </summary>
        /// <returns></returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
        /// <summary>
        /// Altera as equipes
        /// </summary>
        /// <param name="e"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
           linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString());
           linhas.Add(PrepararLinha(e));

           RewriteCSV(PATH,linhas);
        }
        /// <summary>
        /// Exclui as equipes
        /// </summary>
        /// <param name="IdEquipe"></param>
        public void Delete(int IdEquipe)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
           linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());

           RewriteCSV(PATH,linhas);
        }
    }
}