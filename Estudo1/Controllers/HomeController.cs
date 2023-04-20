using Estudo1.Models;
using Estudo1.Repository.Interfaces;
using Estudo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Estudo1.Exceptions;

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
            catch (MySqlException ex)
            {
                HttpContext.Session.SetString("mensagem_erro", "É preciso preencher todos os campos corretamente!");
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                HttpContext.Session.SetString("mensagem_erro", "É preciso preencher todos os campos corretamente!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("mensagem_erro", "Um erro inesperado aconteceu, tente novamente mais tarde.");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirTarefa()
        {
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
            {
                try
                {
                    string requestBody = await reader.ReadToEndAsync();
                    ExcluirTarefaViewModel tarefaParaExcluir = JsonConvert.DeserializeObject<ExcluirTarefaViewModel>(requestBody);
                    tarefaParaExcluir.ValidarParametros();

                    // logica para excluir tarefa

                }catch (ExcluirTarefaVMException e) {
                    return Ok("DEU PROBLEMA: " + e.Message);
                }

                return Ok();
            }
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}