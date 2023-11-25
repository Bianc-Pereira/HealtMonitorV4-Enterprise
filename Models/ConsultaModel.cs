using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealtMonitorV4.Models
{
    [Table("Consulta")]
    public class ConsultaModel
    {
        [Key]
        [DisplayName("Código da Consulta")]
        public int CodigoConsulta { get; set; }

        [DisplayName("Data da Consulta")]
        public String DataConsulta { get; set; }

        // Chave estrangeira para a tabela paciente
        [DisplayName("Senha Paciente")]
        public int IdPaciente { get; set; }
        [DisplayName("Paciente")]
        public PacienteModel Paciente { get; set; }

        // Chave estrangeira para a tabela médico
        [DisplayName("CRM do Médico")]
        public string CrmMedico { get; set; }
        [DisplayName("Médico")]
        public MedicoModel Medico { get; set; }

        // Chave estrangeira para a tabela hospital
        [DisplayName("Código do Hospital")]
        public int CodigoHospital { get; set; }
        [DisplayName("Hospital")]
        public HospitalModel Hospital { get; set; }
    }
}
