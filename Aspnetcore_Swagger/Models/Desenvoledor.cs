using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Models
{
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome_Desenvolvedor { get; set; }
    }
}
