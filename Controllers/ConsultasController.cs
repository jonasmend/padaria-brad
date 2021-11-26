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
//using Padaria_Bread.Extra;

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
                                                        //descProduto = grupo.Key.descricao,
                                                        //tipoMovimentacao = Enum.GetName(typeof(MovimentacaoTipo), grupo.Key.movTipo),
                                                        descProduto = grupo.Key.descricao,
                                                        totalComprado = grupo.Sum(p => p.quantidade)
                                                        //totalProdutos = grupo.Sum(p => p.quantidade)
                                                    };
            return View(lista);
        }
    }
}
