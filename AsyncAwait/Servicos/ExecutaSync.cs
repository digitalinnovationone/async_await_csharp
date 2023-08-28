using AsyncAwait.Models;
using AsyncAwait.Servicos.Async;
using AsyncAwait.Servicos.Sync;

namespace AsyncAwait.Servicos;

public class ExecutaSync
{
     public static void Faca(List<Pizza> pizzasSolicitadas)
     {
        //var pizzaria = new PizzariaAsync();
        var pizzaria = new PizzariaSync();

        // Primeiro, fazemos os pedidos para todas as pizzas.
        var pedido = pizzaria.PedirPizzas(pizzasSolicitadas);

        // Prepara as pizzas do pedido.
        pizzaria.PrepararPedido(pedido);

        // Assuma que após preparar todas as pizzas, elas são entregues.
        pizzaria.EntregarPizza(pedido);
     }
}