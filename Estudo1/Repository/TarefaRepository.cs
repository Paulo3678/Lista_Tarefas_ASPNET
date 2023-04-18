using Estudo1.Context;
using Estudo1.Models;
using Estudo1.Repository.Interfaces;

namespace Estudo1.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TarefaModel> Tarefas => _context.Tarefa;

        public void AdicionarTarefa(TarefaModel tarefa) {
        
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
        }
    }
}
