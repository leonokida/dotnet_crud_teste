using MeuProjetoMVC.Data;
using MeuProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MeuProjetoMVC.Controllers {
    public class ProdutoController : Controller {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var produtos = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                produtos = produtos.Where(p => p.dscProduto.Contains(search));
            }

            return View(produtos.ToList());
        }

        // Criar produto - Formulário
        public IActionResult Criar()
        {
            return View();
        }

        // Criar produto - Salvar no banco de dados
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // Editar produto - Exibir formulário
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // Editar produto - Salvar alterações
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // Deletar produto - Página de confirmação
        public IActionResult Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // Deletar produto - Excluir do banco de dados
        [HttpPost]
        public IActionResult ConfirmarDelecao(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}