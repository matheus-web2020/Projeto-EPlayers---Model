using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto_MVC_1.Models
{
    public class Noticia : EPlayersBase , Interfaces.INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticia.csv";

        public Noticia(){
           CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Cria a notícia
        /// </summary>
        /// <param name="n"></param>
        public void Create(Noticia n)
        {
           string[] linha = {PrepararLinha(n)};
           File.AppendAllLines(PATH,linha);
        }
        /// <summary>
        /// Mostra os dados da notícia
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string PrepararLinha(Noticia n){
           return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
        /// <summary>
        /// Exclui os dados da notícia
        /// </summary>
        /// <param name="IdNoticia"></param>
        public void Delete(int IdNoticia)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH,linhas);

        }
        /// <summary>
        /// Lê os dados da notícia
        /// </summary>
        /// <returns></returns>
        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }
        /// <summary>
        /// Altera as notícias
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticia n)
        {
             List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH,linhas);
        }
    }
}