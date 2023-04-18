using Estudo1.Models;
using Estudo1.Repository.Interfaces;
using Estudo1.ViewModels;
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
            ListaTarefasViewModel listaTarefasViewModel = new ListaTarefasViewModel();
            listaTarefasViewModel.Tarefas = _tarefaRepository.Tarefas;

            return View(listaTarefasViewModel);
        }

        [HttpPost]
        public void TestePostDados(ListaTarefasViewModel model)
        {
            Console.WriteLine("OLA");
            Console.WriteLine(model.TituloTarefa);
        }



        public RedirectToActionResult NovaTarefa([FromQuery] string tituloTarefa, [FromQuery] string descricaoTarefa, [FromQuery] int grauTarefa)
        {
            TarefaModel tarefa = new TarefaModel
            {
                TituloTarefa = tituloTarefa,
                DescricaoTarefa = descricaoTarefa,
                GrauTarefa = grauTarefa
            };

            _tarefaRepository.AdicionarTarefa(tarefa);

            return RedirectToAction("Index");
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