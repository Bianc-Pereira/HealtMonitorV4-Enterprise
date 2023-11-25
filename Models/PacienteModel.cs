using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealtMonitorV4.Models
{
    public class PacienteModel
    {
        [Key]
        [DisplayName("ID do Paciente")]
        public string IdPaciente { get; set; }

        [DisplayName("Nome do Paciente")]
        public string NomePaciente { get; set; }

        [DisplayName("Data de Nascimento")]
        public String DataNascimento { get; set; }

        [DisplayName("Email do Paciente")]
        public string EmailPaciente { get; set; }

        [DisplayName("CPF do Paciente")]
        public string CpfPaciente { get; set; }

        [DisplayName("RG do Paciente")]
        public string RgPaciente { get; set; }

        [DisplayName("Celular de Emergência")]
        public string CelEmergencia { get; set; }

        // Chave estrangeira para a tabela de Endereco
        [DisplayName("CEP")]
        public string Cep { get; set; }
        [DisplayName("Endereço")]
        public EnderecoModel Endereco { get; set; }
    }
}
