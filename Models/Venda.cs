using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MeuProjetoMVC.Models {
    public class Venda {
        [Key]
        public int idVenda { get; set; }

        // Chave estrangeira para Cliente
        [ForeignKey("Cliente")]
        public int idCliente { get; set; }
        public Cliente? Cliente { get; set; }

        // Chave estrangeira para Produto
        [ForeignKey("Produto")]
        public int idProduto { get; set; }
        public Produto? Produto { get; set; }

        public int qtdVenda { get; set; }
        public float vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; }
        public float vlrTotalVenda { get; set; }
    }
}