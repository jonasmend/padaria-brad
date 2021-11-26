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
                                                     //id = agendamento.id,
                                                         cliente = grupo.Key.nome,
                                                         cpf = grupo.Key.cpf,
                                                         produto = grupo.Key.descricao,
                                                         quantidade = grupo.Sum(p => p.quantidade)
                                                     //especialidade = agendamento.medico.especialidade,
                                                     //crm = agendamento.medico.crm,
                                                     //dataRealizacao = agendamento.dataRealizacao,
                                                     //dataAgendamento = agendamento.dataAgendamento,
                                                     //status = Enum.GetName(typeof(AgendamentoStatus), agendamento.agendamentoStatus)
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
