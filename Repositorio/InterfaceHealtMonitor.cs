using HealtMonitorV4.Models;

namespace HealtMonitorV4.Repositorio
{
    public interface InterfaceHealtMonitor
    {
        MedicoModel AdicionarMedico(MedicoModel medico);

        PacienteModel AdicionarPaciente(PacienteModel paciente);

        List<PacienteModel> BuscarPacientes();

        List<MedicoModel> BuscarMedicos();

        PacienteModel listarPorIdPaciente(string idPaciente);

        MedicoModel listarPorIdMedico(string idMedico);

        PacienteModel obterPacientePorId(String  idPaciente);


        void ExcluirPaciente (int idPaciente);
    }
}
