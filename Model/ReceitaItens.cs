using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReceitaItens
    {
        [Key]
        public int IdReceitaItens { get; set; }   
                
        public int ReceitaId { get; set; }        
        public int IngredienteId { get; set; }
        public virtual Receita Receita { get; set; }        
        public virtual Ingrediente Ingrediente { get; set; }
    }
}
