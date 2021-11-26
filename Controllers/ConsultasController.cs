using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Padaria_Bread.Data;
using Padaria_Bread.Models.Consultas;
using Padaria_Bread.Models;
using Padaria_Bread.Extra;

namespace Padaria_Bread.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {

        private readonly Contexto contexto;

        public ConsultasController(Contexto context)
        {
            contexto = context;
        }


        public IActionResult ConsultaCompras()
        {
            IEnumerable<ConsultaCompras> lista = from compra in contexto.Vendas
                                          .Include(p => p.cliente)
                                          .Include(m => m.produto)
                                          .ToList()
                                                     //select new ConsultaCompras
                                                 group compra by new { compra.produto.descricao, compra.cliente.nome, compra.cliente.cpf }
                                                  into grupo
                                                 orderby grupo.Key.descricao
                                                 select new ConsultaCompras
                                                 {
                                                     
                                                         cliente = grupo.Key.nome,
                                                         cpf = grupo.Key.cpf,
                                                         produto = grupo.Key.descricao,
                                                         quantidade = grupo.Sum(p => p.quantidade)
                                                 };
            return View(lista);
        }

        public IActionResult TotalCompras()
        {
            IEnumerable<TotalCompras> lista = from venda in contexto.Vendas
                                                  .Include(p => p.produto)
                                                  .ToList()
                                                    group venda by new { venda.produto.descricao }
                                                  into grupo
                                                    orderby grupo.Key.descricao
                                                    select new TotalCompras
                                                    {
                                                        descProduto = grupo.Key.descricao,
                                                        totalComprado = grupo.Sum(p => p.quantidade)
                                                        
                                                    };
            return View(lista);
        }

        public IActionResult ConsultaComprasPivot()
        {
            IEnumerable<ConsultaComprasPivot> listaProdutoVenda = from vendas in contexto.Vendas
                                                  .Include(p => p.produto)
                                                  .Include(p => p.cliente)
                                                  .ToList()
                                                                  group vendas by new { vendas.produto.descricao, vendas.cliente.nome }
                                                  into grupo
                                                                  orderby grupo.Key.nome
                                                                  select new ConsultaComprasPivot
                                                                  {
                                                                      produto = grupo.Key.descricao,
                                                                      cliente = grupo.Key.nome,
                                                                      total = grupo.Sum(p => p.valorVenda)
                                                                             };

            var PivotTableMovimentacoes = listaProdutoVenda.ToList().ToPivotTable(
                                                                        pivot => pivot.produto,
                                                                        pivot => pivot.cliente,
                                                                        pivot => pivot.Any() ? pivot.Sum(x => x.total) : 0
                                                                    );

            List<PivotCompras> listaPivot = new List<PivotCompras>();

            listaPivot = (from DataRow coluna in PivotTableMovimentacoes.Rows
                          select new PivotCompras()
                          {
                              cliente = coluna[0].ToString(),
                              produto1 = Convert.ToSingle(coluna[1]),
                              produto2 = Convert.ToSingle(coluna[2]),
                          }).ToList();
            return View(listaPivot);
        }
    }
}
