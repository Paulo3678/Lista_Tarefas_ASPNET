using Estudo1.Models;
using Estudo1.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        public HomeController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void NovaTarefa([FromQuery] string tituloTarefa, [FromQuery] string descricaoTarefa, [FromQuery] int grauTarefa)
        {
            TarefaModel tarefa = new TarefaModel
            {
                TituloTarefa = tituloTarefa,
                DescricaoTarefa = descricaoTarefa,
                GrauTarefa = grauTarefa
            };

            _tarefaRepository.AdicionarTarefa(tarefa);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}