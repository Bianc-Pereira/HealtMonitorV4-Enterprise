using HealtMonitorV4.Data;
using HealtMonitorV4.Models;
using Microsoft.EntityFrameworkCore;

namespace HealtMonitorV4.Repositorio
{
    public class Repositorio : InterfaceHealtMonitor
    {
        private readonly Contexto _contexto;

        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public PacienteModel AdicionarPaciente(PacienteModel paciente)
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


        public MedicoModel listarPorIdMedico(string idMedico)
        {
            return _contexto.Medico.FirstOrDefault(x => x.IdMedico == idMedico);
        }

        public PacienteModel listarPorIdPaciente(string idPaciente)
        {
            return _contexto.Paciente.FirstOrDefault(x => x.IdPaciente == idPaciente);
        }

        public PacienteModel obterPacientePorId(string idPaciente)
        {
            return _contexto.Paciente.FirstOrDefault(x => x.IdPaciente == idPaciente);
        }

        public void ExcluirPaciente(int idPaciente)
        {
            var paciente = _contexto.Paciente.Find(idPaciente);

            if (paciente != null)
            {
                _contexto.Paciente.Remove(paciente);
                _contexto.SaveChanges();
            }
        }
    }
}
