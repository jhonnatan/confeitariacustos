using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
        [Required]
        public double QtdePorReceita { get; set; }        
        public double TotalPorReceita { get; set; }
        public double TotalPorUnidade { get; set; }
        public virtual IList<ReceitaItens> RecItens { get; set; }

        public Receita()
        {
            RecItens = new List<ReceitaItens>();
        }
    }
}
