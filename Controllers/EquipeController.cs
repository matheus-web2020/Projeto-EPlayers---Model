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
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            equipe.Nome = form["Nome"];
            //Upload da Imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

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
                equipe.Imagem   = file.FileName;
            }
            else
            {
                equipe.Imagem   = "padrao.png";
            }
            //Término do upload da imagem

            equipeModel.Create(equipe);
            return LocalRedirect("~/Equipe");
        }
        [Route("Equipe/{id}")]
        public IActionResult Deletar(int id){
              equipeModel.Delete(id);
              return LocalRedirect("~/Equipe");
        }

    }
}
