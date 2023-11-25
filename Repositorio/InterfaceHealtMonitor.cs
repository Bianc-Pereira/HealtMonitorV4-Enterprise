using HealtMonitorV4.Models;

namespace HealtMonitorV4.Repositorio
{
    public interface InterfaceHealtMonitor
    {
        MedicoModel AdicionarMedico(MedicoModel medico);

        PacienteModel AdicionarPaciente(PacienteModel paciente);

        List<PacienteModel> BuscarPacientes();

        List<MedicoModel> BuscarMedicos();
    }
}
