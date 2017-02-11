using Confeitaria.DAL.Context;
using Confeitaria.DAL.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confeitaria.Console
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Excluir();
            AdicionarIngredientes();
            AdicionarReceitaMaster();            
            
            System.Console.ReadKey();
        }

        private static void AdicionarReceitaItens(Receita receita)
        {            
            using (var repItens = new ReceitaItensRepository())
            {
                using (var repIngr = new IngredienteRepository())
                {
                    foreach (var ingr in repIngr.GetAll())
                    {
                        repItens.Adicionar( new ReceitaItens() {
                            ReceitaId = receita.ReceitaId, IngredienteId = ingr.IngredienteId
                        });
                    }
                }                
                repItens.SalvarTodos();
            };           
        }                                   
        

        private static void AdicionarReceitaMaster()
        {            
            using (var repReceita = new ReceitaRepository())
            {
                Receita receita = new Receita();
                receita.Descricao = "Carolinas";
                receita.QtdePorReceita = 20;
                                
                repReceita.Adicionar(receita);
                repReceita.SalvarTodos();

                // Adiciona Itens
                AdicionarReceitaItens(receita);

                System.Console.WriteLine("Receita Adicionada - Descrição: {0}", receita.Descricao);                
            }
            
        }

        private static void Excluir()
        {
            try
            {
                using (var repIngredientes = new IngredienteRepository())
                {
                    repIngredientes.Excluir(i => i.Descricao.Length > 0);
                    repIngredientes.SalvarTodos();
                    System.Console.WriteLine("======= Ingredientes Excluídos ========");
                }

                using (var repReceitas = new ReceitaRepository())
                {
                    repReceitas.Excluir(i => i.Descricao.Length > 0);
                    repReceitas.SalvarTodos();
                    System.Console.WriteLine("======= Receitas Excluídas ========");
                }

                using (var repReceitasItens = new ReceitaItensRepository())
                {
                    repReceitasItens.Excluir(i => i.ReceitaId > 0);
                    repReceitasItens.SalvarTodos();
                    System.Console.WriteLine("======= Itens de Receitas Excluídas ========");
                }
            }
            catch (Exception)
            {

                System.Console.WriteLine("Erro ao excluir!");
            }            
        }

        private static void AdicionarIngredientes()
        {
            using (var repIngredientes = new IngredienteRepository())
            {
                new List<Ingrediente>
                {
                    new Ingrediente { IngredienteId=1, Descricao="Leite Moça", DataCadastro=DateTime.Now, Preco=50.99, Unidade="Unidade"},
                    new Ingrediente { IngredienteId=2, Descricao="Farinha de Trigo 500g", DataCadastro=DateTime.Now, Preco=2.99, Unidade="Unidade"},
                    new Ingrediente { IngredienteId=3, Descricao="Granulado", DataCadastro=DateTime.Now, Preco=1.50, Unidade="Unidade"}
                }.ForEach(repIngredientes.Adicionar);

                repIngredientes.SalvarTodos();

                System.Console.WriteLine("========== Ingredientes Cadastrados ============");

                foreach (var i in repIngredientes.GetAll())
                {
                    System.Console.WriteLine("{0} - {1}", i.IngredienteId, i.Descricao);
                }                
            }
        }
    }
}
