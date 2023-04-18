using Estudo1.Models;

namespace Estudo1.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        IEnumerable<TarefaModel> Tarefas { get; }

        public void AdicionarTarefa(TarefaModel tarefa);
    }
}
