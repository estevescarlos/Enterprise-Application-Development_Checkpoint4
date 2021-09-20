using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodigium.Web.Checkpoint01.Models;

namespace Prodigium.Web.Checkpoint01.Controllers
{
    public class FuncionarioController : Controller
    {
        private static List<Funcionario> _funcionarios = new List<Funcionario>(new Funcionario[]{
            new Funcionario()
            {
                Codigo = 1,
                Nome = "Carlos Esteves",
                CPF = "36980809525",
                Setor = Setores.Desenvolvimento,
                Cargo = "Desenvolvedor Java",
                Nivel = "Analista",
                DataAdmissao = DateTime.Now,
                Salario = 2800,
                Status = true
            },
            new Funcionario()
            {
                Codigo = 2,
                Nome = "Thiago Yamamoto",
                CPF = "42585793058",
                Setor = Setores.Marketing,
                Cargo = "Marketing",
                Nivel = "Gerente",
                DataAdmissao = DateTime.Now,
                Salario = 9800,
                Status = false
            },
            new Funcionario()
            {
                Codigo = 3,
                Nome = "João Figueiredo",
                CPF = "28574869549",
                Setor = Setores.Administrativo,
                Cargo = "Recursos Humanos",
                Nivel = "Assistente",
                DataAdmissao = DateTime.Now,
                Salario = 2300,
                Status = true
            }
        });
        
        private static int _codigo = 4;

        
        [HttpGet]
        public IActionResult Pesquisar(int codigo)
        {
            _funcionarios = _funcionarios.FindAll(c => c.Codigo == codigo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int codigo)
        {
            _funcionarios.RemoveAll(c => c.Codigo == codigo);
            TempData["msg"] = "Funcionário removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarNiveis();
            var funcionario = _funcionarios.Find(c => c.Codigo == id);
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            _funcionarios[_funcionarios.FindIndex(c => c.Codigo == funcionario.Codigo)] = funcionario;
            TempData["msg"] = "Funcionário atualizado!";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            funcionario.Codigo = _codigo++;
            _funcionarios.Add(funcionario);
            TempData["msg"] = "Funcionário cadastrado!";
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
            return View(_funcionarios);
        }
    }
}
