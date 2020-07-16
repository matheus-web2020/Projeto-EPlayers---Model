using System;
using System.Collections.Generic;
using System.IO;
using Projeto_MVC_1.Interfaces;


namespace Projeto_MVC_1.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
       public int IdNoticias { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

         public Noticias(){
            CreateFolderAndFile(PATH);
        }

        private string PrepararLinha (Noticias n){
            return $"{n.IdNoticias};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// Criar um método que volta uma linha(criada em outro métofo PrepararTexto)
        /// </summary>
        /// <param name="n">noticia</param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }



        /// <summary>
        /// Cria um método que remove linhas
        /// </summary>
        /// <param name="IdNoticias"></param>
        public void Delete(int IdNoticias)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

/// <summary>
///  Uma lista que lê informações como: Titulo
/// </summary>
/// <returns>Linha</returns>
        public List<Noticias> ReadAll()
        { 
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];
               

                noticias.Add(noticia);
            }
            return noticias;
        }


        /// <summary>
        /// Atualiza, lê e remove
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticias n)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }
    }
}