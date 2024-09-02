using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ListaDeTarefas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);
            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Vencimento = Filtros.VencimentoValoresFiltro;

            IQueryable<Tarefa> consulta = _context.Tarefas.
                Include(c => c.Categoria).Include(s => s.Status);


            if(filtros.TemCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaId == filtros.CategoriaId);
            }

            if(filtros.Temstatus)
            {
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId);
            }

            if (filtros.TemVencimentos)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                { consulta = consulta.Where(t => t.DataDeVencimento < hoje); }

                if (filtros.EFuturo)
                { consulta = consulta.Where(t => t.DataDeVencimento > hoje); }

                if (filtros.EHoje)
                { consulta = consulta.Where(t => t.DataDeVencimento == hoje); }


            }

            var tarefas = consulta.OrderBy(t => t.DataDeVencimento).ToList();
            
            return View(tarefas);
        }

    }
}
