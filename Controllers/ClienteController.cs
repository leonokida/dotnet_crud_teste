using MeuProjetoMVC.Data;
using MeuProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MeuProjetoMVC.Controllers {
    public class ClienteController : Controller {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var clientes = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                clientes = clientes.Where(c => c.nmCliente.Contains(search));
            }

            return View(clientes.ToList());
        }

        // Criar cliente - Formulário
        public IActionResult Criar()
        {
            return View();
        }

        // Criar cliente - Salvar no banco de dados
        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // Editar cliente - Exibir formulário
        public IActionResult Editar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // Editar cliente - Salvar alterações
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // Deletar cliente - Página de confirmação
        public IActionResult Deletar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // Deletar cliente - Excluir do banco de dados
        [HttpPost]
        public IActionResult ConfirmarDelecao(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}