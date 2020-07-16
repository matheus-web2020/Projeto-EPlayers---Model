using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
             //Upload da Imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticia");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticias.Imagem   = file.FileName;
            }
            else
            {
                noticias.Imagem   = "padrao.png";
            }
            //Término do upload da imagem

             noticiaModel.Create(noticias);
             return LocalRedirect("~/Noticia"); 
        }

    }
}
