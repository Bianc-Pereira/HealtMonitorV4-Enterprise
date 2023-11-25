using HealtMonitorV4.Data;
using HealtMonitorV4.Models;

namespace HealtMonitorV4.Repositorio
{
    public class Repositorio : InterfaceHealtMonitor
    {
        private readonly Contexto _contexto;

        public Repositorio (Contexto contexto)
        {
            _contexto = contexto;
        }

        public PacienteModel AdicionarPaciente (PacienteModel paciente)
        {
            //Gravar no banco de dados
            _contexto.Paciente.Add(paciente);
            _contexto.SaveChanges();

            return paciente;
        }

        public MedicoModel AdicionarMedico(MedicoModel medico)
        {
            //Gravar no banco de dados 
            _contexto.Medico.Add(medico);
            _contexto.SaveChanges();
            
            return medico;
        }

        public List<PacienteModel> BuscarPacientes()
        {
            return _contexto.Paciente.ToList();
        }

        public List<MedicoModel> BuscarMedicos()
        {
            return _contexto.Medico.ToList();
        }
    }
}
