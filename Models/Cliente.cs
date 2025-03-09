using System.ComponentModel.DataAnnotations;

namespace MeuProjetoMVC.Models {
    public class Cliente {
        [Key]
        public int idCliente { get; set; }
        public string nmCliente { get; set; }
        public string cidade { get; set; }
    }
}