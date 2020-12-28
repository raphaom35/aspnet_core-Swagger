using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Ranking
    {
        [Key]
        public int DesenvolvedorId { get; set; }
        public long HorasTrabalhadasNaSemana { get; set; }
    }
}
