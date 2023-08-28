using AsyncAwait.Models;
using AsyncAwait.Servicos.Async;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAwait.Servicos
{
    public class ExecutaAsync
    {
        public static async Task FacaAsync(List<Pizza> pizzasSolicitadas)
        {
            var pizzaria = new PizzariaAsync();

            // Primeiro, fazemos os pedidos para todas as pizzas.
            var pedido = await pizzaria.PedirPizzasAsync(pizzasSolicitadas);

            // Prepara as pizzas do pedido.
            await pizzaria.PrepararPedidoAsync(pedido);

            // Assuma que após preparar todas as pizzas, elas são entregues.
            await pizzaria.EntregarPizzaAsync(pedido);
        }
    }
}
