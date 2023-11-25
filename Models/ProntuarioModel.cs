using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealtMonitorV4.Models
{
    [Table("Prontuario")]
    public class ProntuarioModel { 
    
        [Key]
        [DisplayName("ID do Prontuário")]
        public int IdProntuario { get; set; }

        // Chaves estrangeiras
        [DisplayName("ID do Paciente")]
        public int? IdPaciente { get; set; }
        [DisplayName("Paciente")]
        public PacienteModel Paciente { get; set; }

        [DisplayName("ID do Médico")]
        public int? IdMedico { get; set; }
        [DisplayName("Médico")]
        public MedicoModel Medico { get; set; }

        // Sinais vitais
        [DisplayName("Prioridade")]
        public string Prioridade { get; set; }

        [DisplayName("Temperatura Corporal")]
        public string TempCorporal { get; set; }

        [DisplayName("Pressão Arterial")]
        public string PressaoArt { get; set; }

        [DisplayName("Frequência Cardíaca")]
        public string FreqCardiaca { get; set; }

        [DisplayName("Frequência Respiratória")]
        public string FreqResp { get; set; }

        [DisplayName("Saturação de Oxigênio")]
        public string SatOxig { get; set; }
    }
}
