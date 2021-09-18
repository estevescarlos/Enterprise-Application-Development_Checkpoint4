using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Prodigium.Web.Checkpoint01.Models
{
    public class Funcionario
    {
        [HiddenInput]
        public int Codigo { get; set; }
        
        public string Nome { get; set; }
        
        public string CPF { get; set; }
        
        public Setores Setor { get; set; }
        
        public string Cargo { get; set; }
        
        public string Nivel { get; set; }

        [Display(Name = "Data de Admissão"), DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }
        
        [Display(Name = "Salário")]
        public decimal Salario { get; set; }
        
        public bool Status { get; set; }
    }

    public enum Setores
    {
        Administrativo, Desenvolvimento, Financeiro, Comercial, Marketing, Suporte, Qualidade 
    }
}
