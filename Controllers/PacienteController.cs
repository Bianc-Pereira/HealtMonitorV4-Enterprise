using HealtMonitorV4.Models;
using HealtMonitorV4.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace HealtMonitorV4.Controllers
{
    public class PacienteController : Controller
    {
        private readonly InterfaceHealtMonitor _repositorio;

        public PacienteController(InterfaceHealtMonitor repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<PacienteModel> pacientes = _repositorio.BuscarPacientes();

            return View(pacientes);
        }

        
        public IActionResult CriarPaciente(PacienteModel paciente)
        {
            try
            {
                // Verifica se todos os campos obrigatórios foram preenchidos
                if (string.IsNullOrWhiteSpace(paciente.NomePaciente) ||
                    paciente.DataNascimento == null || // Adapte conforme necessário
                    string.IsNullOrWhiteSpace(paciente.EmailPaciente) ||
                    string.IsNullOrWhiteSpace(paciente.CpfPaciente) ||
                    string.IsNullOrWhiteSpace(paciente.RgPaciente) ||
                    string.IsNullOrWhiteSpace(paciente.CelEmergencia) ||
                    string.IsNullOrWhiteSpace(paciente.Cep))
                {
                    // Mensagem de erro se algum campo obrigatório não foi preenchido
                    TempData["Mensagem"] = "Todos os campos são obrigatórios.";
                    return View();
                }

                // Chama o método Adicionar do repositório para adicionar o paciente
                _repositorio.AdicionarPaciente(paciente);

                // Mensagem de sucesso após o cadastro bem-sucedido
                TempData["Mensagem"] = "Cadastro feito com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao criar paciente: {ex.Message}");

                // Mensagem de erro de sistema ao cadastrar
                TempData["Mensagem"] = "Erro de sistema ao cadastrar. Tente novamente mais tarde.";
                return View(); // ou RedirectToAction("Erro");
            }
        }

        public IActionResult DeletarPaciente(int id)
        {
            // Aqui você pode adicionar lógica para buscar o paciente pelo ID
            // e passar os dados para a view de confirmação de exclusão
            PacienteModel paciente = _repositorio.obterPacientePorId(id.ToString());

            if (paciente == null)
            {
                // Se o paciente não for encontrado, redirecione ou exiba uma mensagem de erro
                TempData["Mensagem"] = "Paciente não encontrado.";
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        [HttpPost]
        public IActionResult ConfirmarExclusao(int id)
        {
            try
            {
                // Chama o método para excluir o paciente pelo ID
                _repositorio.ExcluirPaciente(id);

                // Mensagem de sucesso após a exclusão bem-sucedida
                TempData["Mensagem"] = "Exclusão realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir paciente: {ex.Message}");

                // Mensagem de erro de sistema ao excluir
                TempData["Mensagem"] = "Erro de sistema ao excluir. Tente novamente mais tarde.";
                return RedirectToAction("Index"); // ou RedirectToAction("Erro");
            }
        }

    }
    
}
