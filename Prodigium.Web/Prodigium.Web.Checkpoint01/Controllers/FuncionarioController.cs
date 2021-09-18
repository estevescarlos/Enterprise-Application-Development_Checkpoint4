using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodigium.Web.Checkpoint01.Models;

namespace Prodigium.Web.Checkpoint01.Controllers
{
    public class FuncionarioController : Controller
    {
        private static List<Funcionario> _funcionarios = new List<Funcionario>();
        private static int _codigo = 1;
        
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarNiveis();
            return View();
        }

        private void CarregarNiveis()
        {
            var lista = new List<string>(new string[] { "Estagiário", "Auxiliar", "Assistente", "Analista", "Supervisor", "Gerente" });
            ViewBag.niveis = new SelectList(lista);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
