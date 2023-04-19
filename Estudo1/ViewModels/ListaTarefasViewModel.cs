using Estudo1.Models;
using System.ComponentModel;

namespace Estudo1.ViewModels
{
    public class ListaTarefasViewModel
    {
        public IEnumerable<TarefaModel> Tarefas { get; set; }
        public string[] GrauTarefas = new string[3] { "Urgente", "Médio", "Suave" };

        public ISession Session { get; set; }

        [DisplayName("Titulo")]
        public string TituloTarefa { get; set; }

        [DisplayName("Descricao")]
        public string DescricaoTarefa { get; set; }

        [DisplayName("Grau")]
        public int GrauTarefa { get; set; }

    }
}
