
using System.Collections.Generic;
using System.Linq;
using Exo.WebApi.Contexts;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public bool Atualizar(int id, Projeto projeto)
        {
            Projeto projetoEncontrado = _context.Projetos.Find(id);

            if (projetoEncontrado == null)
                return false;

            projetoEncontrado.NomeDoProjeto = projeto.NomeDoProjeto;
            projetoEncontrado.Area = projeto.Area;
            projetoEncontrado.Status = projeto.Status;

            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Projeto projetoEncontrado = _context.Projetos.Find(id);

            if (projetoEncontrado == null)
                return false;

            _context.Projetos.Remove(projetoEncontrado);
            _context.SaveChanges();

            return true;
        }
    }
}
