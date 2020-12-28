using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Projetos
    {
        [Key]
        public int Id { get; set; }
        public string Nome_Projeto { get; set; }
    }
}
