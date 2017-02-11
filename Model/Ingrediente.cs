using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ingrediente
    {   
        [Key]        
        public int IngredienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        [MaxLength(50)]
        public string Unidade { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        //public virtual IList<ReceitaItens> RecItens { get; set; }
    }

    public enum Unidade
    {
        Unidade,
        Colher,
        Gramas,
        Litros,
        Mililitros
    }
}
