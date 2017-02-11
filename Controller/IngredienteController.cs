using Confeitaria.DAL.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class IngredienteController
    {
        private IngredienteRepository repositorio = new IngredienteRepository();

        public void Adicionar(Ingrediente ingrediente)
        {
            repositorio.Adicionar(ingrediente);
        }

        public void Atualizar(Ingrediente ingrediente)
        {
            repositorio.Atualizar(ingrediente);
        }

        public void Excluir(Ingrediente ingrediente)
        {
            repositorio.Excluir(x => x.IngredienteId == ingrediente.IngredienteId);
        }

        public IList<Ingrediente> GetAll()
        {
            return repositorio.GetAll().ToList();
        }

        public Ingrediente Find(int key)
        {
            return repositorio.Find(key);
        }

        public IList<Ingrediente> Get(Func<Ingrediente, bool> predicate)
        {
            return repositorio.Get(predicate).ToList();
        }

        public void SalvarTodos()
        {
            repositorio.SalvarTodos();
        }

    }
}
