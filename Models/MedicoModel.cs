using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealtMonitorV4.Models
{
    [Table("Medico")]
    public class MedicoModel
    {
        [Key]
        [DisplayName("ID do Médico")]
        public string IdMedico { get; set; }

        [DisplayName("Nome do Médico")]
        public string NomeMedico { get; set; }

        [DisplayName("Data de Nascimento")]
        public String DataNascimento { get; set; }

        [DisplayName("Email do Médico")]
        public string EmailMedico { get; set; }

        [DisplayName("CPF do Médico")]
        public string CpfMedico { get; set; }

        [DisplayName("CRM do Médico")]
        public string CrmMedico { get; set; }

        // Chave estrangeira para a tabela Endereco
        [DisplayName("CEP")]
        public string? Cep { get; set; }
        [DisplayName("Endereço")]
        public EnderecoModel Endereco { get; set; }

    }
}
