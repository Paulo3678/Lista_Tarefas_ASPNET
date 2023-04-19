using Estudo1.Models;
using Estudo1.Repository.Interfaces;
using Estudo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
            listaTarefasViewModel.Session = HttpContext.Session;

            return View(listaTarefasViewModel);
        }

        [HttpPost]
        public RedirectToActionResult AdicionarTarefa(ListaTarefasViewModel model)
        {
            try
            {
                TarefaModel tarefaModel = new TarefaModel
                {
                    TituloTarefa = model.TituloTarefa,
                    DescricaoTarefa = model.DescricaoTarefa,
                    GrauTarefa = model.GrauTarefa
                };
                _tarefaRepository.AdicionarTarefa(tarefaModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("teste", "123");
                return RedirectToAction("Index");

            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}