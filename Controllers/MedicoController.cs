using HealtMonitorV4.Models;
using HealtMonitorV4.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace HealtMonitorV4.Controllers
{
    public class MedicoController : Controller
    {
        private readonly InterfaceHealtMonitor _repositorio;

        public MedicoController(InterfaceHealtMonitor repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<MedicoModel> medicos = _repositorio.BuscarMedicos();
            
            return View(medicos);

        }


        public IActionResult CriarMedico(MedicoModel medico)
        {
            try
            {
                // Verifica se todos os campos obrigatórios foram preenchidos
                if (string.IsNullOrWhiteSpace(medico.NomeMedico) ||
                    medico.DataNascimento == null || // Adapte conforme necessário
                    string.IsNullOrWhiteSpace(medico.EmailMedico) ||
                    string.IsNullOrWhiteSpace(medico.IdMedico) ||
                    string.IsNullOrWhiteSpace(medico.CpfMedico) ||
                    string.IsNullOrWhiteSpace(medico.CrmMedico))
                {
                    // Mensagem de erro se algum campo obrigatório não foi preenchido
                    TempData["Mensagem"] = "Todos os campos são obrigatórios.";
                    return View();
                }

                // Chama o método Adicionar do repositório para adicionar o paciente
                _repositorio.AdicionarMedico(medico);

                // Mensagem de sucesso após o cadastro bem-sucedido
                TempData["Mensagem"] = "Cadastro feito com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao criar paciente: {ex.Message}");

                // Mensagem de erro de sistema ao cadastrar
                TempData["Mensagem"] = ex;
                return View(); // ou RedirectToAction("Erro");
            }
        }

    }
}
