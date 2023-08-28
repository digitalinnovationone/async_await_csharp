using System;
using System.Threading.Tasks;
using AsyncAwait.Models;

namespace AsyncAwait.Models.Sync;

public class Pizzaria
{
    //public Pedido PedirPizza(string sabor)
    //{
    //    Console.WriteLine("Recebendo pedido...");
    //    Thread.Sleep(2000);  // Simula o tempo para processar o pedido.

    //    var pedido = new Pedido
    //    {
    //        Pizza = new Pizza { Sabor = sabor, Tempo = 1000 },
    //        HorarioDoPedido = DateTime.Now
    //    };

    //    Console.WriteLine($"Pedido de pizza de {sabor} realizado às {pedido.HorarioDoPedido}!");
    //    return pedido;
    //}

    //public Pizza PrepararPizza(Pedido pedido)
    //{
    //    Console.WriteLine($"Preparando pizza de {pedido.Pizza.Sabor}...");
    //    Thread.Sleep(2000); // Simula o tempo para preparar a pizza.

    //    Console.WriteLine($"Pizza de {pedido.Pizza.Sabor} pronta!");
    //    return pedido.Pizza;
    //}
}
