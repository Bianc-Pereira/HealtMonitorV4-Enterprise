using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealtMonitorV4.Models
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        [Key]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [DisplayName("Rua")]
        public String Rua { get; set; }

        [DisplayName("Bairro")]
        public String Bairro { get; set; }

        [DisplayName("Cidade")]
        public String Cidade { get; set; }

        [DisplayName("Número")]
        public int Numero { get; set; }

        [DisplayName("Estado")]
        public String Estado { get; set; }

        }
}
