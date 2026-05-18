using Microsoft.AspNetCore.Mvc;
using PrjFinanceiro.Models;
using System.Linq;

namespace PrjFinanceiro.Controllers
{
    public class CargoController : Controller
    {
        private readonly AppDbContext _context;

        public CargoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Cargo.ToList();
            ViewBag.nomesenai = "SENAI";
            
            return View(lista); // Passa a lista para a View
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string Descricao, string Abreviacao)
        {
            // Criamos o objeto manualmente com os dados que vieram do formulário
            var novaCargo = new Cargo
            {
                Descricao = Descricao,
                Abreviacao = Abreviacao,
               
            };

            if (!string.IsNullOrEmpty(Descricao))
            {
                _context.Cargo.Add(novaCargo);
                  _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Agencia/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Busca a agência pelo código (ID)
            var Cargo = _context.Cargo.FirstOrDefault(a => a.Codigo == id);

            if (Cargo == null)
            {
                return NotFound();
            }

            return View(Cargo); // Passa o objeto para a View preencher os campos
        }

        // POST: Agencia/Editar
        [HttpPost]
        public IActionResult Editar(int Codigo, string Descricao, string Abreviacao)
        {
            // Busca o registro existente no banco
            var CargoNoBanco = _context.Cargo.FirstOrDefault(a => a.Codigo == Codigo);

            if (CargoNoBanco != null)
            {
                // Atualiza os atributos manualmente
                CargoNoBanco.Descricao = Descricao;
                CargoNoBanco.Abreviacao = Abreviacao;
                

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        // GET: Agencia/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // Busca a agência para mostrar ao usuário o que ele está prestes a apagar
            var Cargo = _context.Agencia.FirstOrDefault(a => a.Codigo == id);

            if (Cargo == null)
            {
                return NotFound();
            }

            return View(Cargo);
        }

        // POST: Agencia/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var Cargo = _context.Cargo.FirstOrDefault(a => a.Codigo == codigo);

            if (Cargo != null)
            {
                _context.Cargo.Remove(Cargo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



    }
}
