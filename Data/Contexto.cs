using Microsoft.EntityFrameworkCore;

namespace HealtMonitorV4.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :base(options) { 
            
        }

        public DbSet<Models.PacienteModel> Paciente { get; set; }
        public DbSet<Models.MedicoModel> Medico { get; set; }


        //Não usadas no momento 
        public DbSet<Models.EnderecoModel> Endereco { get; set; }

        public DbSet<Models.ProntuarioModel> Prontuario { get; set;}

        public DbSet<Models.HospitalModel> Hospital { get; set; }

        public DbSet<Models.ConsultaModel> Consulta { get; set; }

    }
}
