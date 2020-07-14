using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_MVC_1.Models;

namespace Projeto_MVC_1.Controllers
{
    public class NoticiaController : Controller
    {
        
        Noticia noticiaModel = new Noticia();
        public IActionResult Index()
        {
            ViewBag.Noticia = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Criar(IFormCollection form){
             
             Noticia noticias = new Noticia();
             noticias.IdNoticia = Int32.Parse(form["IdNoticia"]);
             noticias.Titulo = form["Título"];
             noticias.Texto = form["Texto"];
             noticias.Imagem = form["Imagem"];

             noticiaModel.Create(noticias);

             ViewBag.Noticia = noticiaModel.ReadAll(); 
             return LocalRedirect("~/Noticia"); 
        }

    }
}
