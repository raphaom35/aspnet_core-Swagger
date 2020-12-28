using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Models
{

    public class LancamentoHoras
    {
        [Key]
        public int Id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public int DesenvolvedorId { get; set; }
        public int ProjetosId { get; set; }
        public Projetos Projetos { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
    }

}
