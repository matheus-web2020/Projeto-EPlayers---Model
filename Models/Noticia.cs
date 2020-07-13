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

        public void Create(Noticia n)
        {
           string[] linha = {PrepararLinha(n)};
           File.AppendAllLines(PATH,linha);
        }

        private string PrepararLinha(Noticia n){
           return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Delete(int IdNoticia)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH,linhas);

        }

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

        public void Update(Noticia n)
        {
             List<String> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH,linhas);
        }
    }
}