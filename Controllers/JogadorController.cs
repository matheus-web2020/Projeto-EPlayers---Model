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
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        { 
            ViewBag.Jogador = jogadorModel.ReadAll(); 
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){
                 
                 Jogador jogador = new Jogador();
                 jogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
                 jogador.Nome = form["Nome"];
                 jogador.IdJogador = Int32.Parse(form["IdJogador"]);

                 jogadorModel.Create(jogador);

                 ViewBag.Jogador = jogadorModel.ReadAll(); 
                 return LocalRedirect("~/Jogador"); 
        }

        [Route("Jogador/{id}")]
        public IActionResult Deletar(int id){
              jogadorModel.Delete(id);
              return LocalRedirect("~/jogador");
        }

        
    }
}
