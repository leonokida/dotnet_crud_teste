using MeuProjetoMVC.Data;
using MeuProjetoMVC.Models;
using MeuProjetoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeuProjetoMVC.Controllers {
    public class VendaController : Controller {
        private readonly AppDbContext _context;
        private readonly VendaService _vendaService;

        public VendaController(VendaService vendaService, AppDbContext context) {
            _context = context;
            _vendaService = vendaService;
        }

        public async Task<IActionResult> Index(string search)
        {
            // Carrega vendas do endpoint
            if (!_context.Produtos.Any())
            {
                var vendasExternas = await _vendaService.ObterVendasAsync();

                foreach (var venda in vendasExternas)
                {
                    if (!_context.Vendas.Any(v => v.idVenda == venda.idVenda))
                    {
                        _context.Vendas.Add(venda);
                    }
                }

                await _context.SaveChangesAsync();
            }

            var vendas = _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                vendas = vendas.Where(v => v.Produto.dscProduto.Contains(search) || v.Cliente.nmCliente.Contains(search));
            }

            return View(vendas.ToList());
        }

        // Criar venda - Formulário
        public IActionResult Criar()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes, "idCliente", "nmCliente");
            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "dscProduto");
            return View();
        }

        // Criar venda - Salvar no banco de dados
        [HttpPost]
        public IActionResult Criar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                // Buscar o valor unitário do produto para calcular o total
                var produto = _context.Produtos.Find(venda.idProduto);
                var cliente = _context.Clientes.Find(venda.idCliente);
                if (produto != null)
                {
                    venda.vlrUnitarioVenda = (float)produto.vlrUnitario;
                    venda.vlrTotalVenda = venda.qtdVenda * venda.vlrUnitarioVenda;
                    venda.dthVenda = DateTime.Now;
                }

                _context.Clientes.Attach(cliente);
                _context.Produtos.Attach(produto);
                venda.Cliente = cliente;
                venda.Produto = produto;

                _context.Vendas.Add(venda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }

            ViewBag.Clientes = new SelectList(_context.Clientes, "idCliente", "nmCliente");
            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "dscProduto");
            return View(venda);
        }

        // Editar venda - Exibir formulário
        public IActionResult Editar(int id)
        {
            var venda = _context.Vendas.Find(id);
            ViewBag.Clientes = new SelectList(_context.Clientes, "idCliente", "nmCliente");
            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "dscProduto");
            if (venda == null) return NotFound();
            return View(venda);
        }

        // Editar venda - Salvar alterações
        [HttpPost]
        public IActionResult Editar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                // Buscar o valor unitário do produto para calcular o total
                var produto = _context.Produtos.Find(venda.idProduto);
                var cliente = _context.Clientes.Find(venda.idCliente);
                if (produto != null)
                {
                    venda.vlrUnitarioVenda = (float)produto.vlrUnitario;
                    venda.vlrTotalVenda = venda.qtdVenda * venda.vlrUnitarioVenda;
                    venda.dthVenda = DateTime.Now;
                }

                _context.Clientes.Attach(cliente);
                _context.Produtos.Attach(produto);
                venda.Cliente = cliente;
                venda.Produto = produto;

                _context.Vendas.Update(venda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = new SelectList(_context.Clientes, "idCliente", "nmCliente");
            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "dscProduto");
            return View(venda);
        }

        // Deletar venda - Página de confirmação
        public IActionResult Deletar(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null) return NotFound();
            return View(venda);
        }

        // Deletar cliente - Excluir do banco de dados
        [HttpPost]
        public IActionResult ConfirmarDelecao(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null) return NotFound();

            _context.Vendas.Remove(venda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}