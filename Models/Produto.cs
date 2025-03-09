using System.ComponentModel.DataAnnotations;


namespace MeuProjetoMVC.Models {
    public class Produto {
        [Key]
        public int idProduto { get; set; }
        public string dscProduto { get; set; }
        public float vlrUnitario { get; set; }
    }
}