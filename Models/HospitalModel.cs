using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealtMonitorV4.Models
{
    [Table("Hospital")]
    public class HospitalModel
    {
        [Key]
        [DisplayName("Código do Hospital")]
        public int CodigoHospital { get; set; }

        [DisplayName("Nome do Hospital")]
        public string NomeHospital { get; set; }

        [DisplayName("CEP")]
        public string Cep { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        // Chave estrangeira para a tabela FIAP.endereco
        [DisplayName("Endereço")]
        public EnderecoModel Endereco { get; set; }
    }
}
