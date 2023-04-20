using Estudo1.ViewModels.Interfaces;
using Estudo1.Exceptions;

namespace Estudo1.ViewModels
{
    public class ExcluirTarefaViewModel : IEndpointViewModel
    {
        public int IdTarefa { get; set; }

        public void ValidarParametros()
        {
            if(IdTarefa  <= 0 && IdTarefa == null) {
                throw new ExcluirTarefaVMException("É preciso informar um Id válido");
            }
        }
    }
}
