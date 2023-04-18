using System.ComponentModel.DataAnnotations;

namespace Estudo1.Models
{
    public class TarefaModel
    {
        [Key]
        public int TarefaId { get; set; }
        
        [StringLength(100)]
        public string TituloTarefa { get; set; }
        
        [StringLength(200)]
        public string DescricaoTarefa{ get; set; }
        
        [StringLength(1)]
        public int GrauTarefa { get; set; }


    }
}
