using System;
using System.Threading.Tasks;
using AsyncAwait.Models;
using AsyncAwait.Models.Sync;

namespace AsyncAwait.Servicos.Async;

public class PizzariaAsync
{
    public async Task<Pedido> PedirPizzasAsync(List<Pizza> pizzas)
    {
        Terminal.EscrevaAmarelo("Recebendo pedido...");
        await Task.Delay(1000);  // Simula o tempo para processar o pedido.

        var pizzasDoPedido = new List<PizzaDoPedido>();
        foreach (var pizza in pizzas)
            pizzasDoPedido.Add(new PizzaDoPedido { Pizza = pizza, Concluido = false });

        var pedido = new Pedido
        {
            Id = new Random().Next(1, 101),
            Pizzas = pizzasDoPedido,
            HorarioDoPedido = DateTime.Now
        };

        espacos();
        Terminal.EscrevaBranco($"Pedido de pizza com sabores {string.Join(", ", pedido.Pizzas.Select(p => p.Pizza.Sabor))} realizado às {pedido.HorarioDoPedido}!");
        Terminal.EscrevaBranco($"Seu ID é: {pedido.Id}");
        espacos();
        return pedido;
    }

    private async Task prepararPizzaAsync(PizzaDoPedido pizzaDoPedido)
    {
        Terminal.EscrevaAmarelo($"Preparando pizza de {pizzaDoPedido.Pizza.Sabor}...");
        await Task.Delay(pizzaDoPedido.Pizza.Tempo);
        pizzaDoPedido.Concluido = true;
        Terminal.EscrevaVerde($"Pizza de {pizzaDoPedido.Pizza.Sabor} pronta!");
    }

    public async Task PrepararPedidoAsync(Pedido pedido)
    {
        var tarefasDePreparo = new List<Task>();
        foreach (var pizzaDoPedido in pedido.Pizzas)
        {
            tarefasDePreparo.Add(prepararPizzaAsync(pizzaDoPedido));
        }

        await Task.WhenAll(tarefasDePreparo);
    }


    public async Task EntregarPizzaAsync(Pedido pedido)
    {
        if (!pedido.TodasPizzasPreparadas())
        {
            espacos();
            Terminal.EscrevaVermelho($"Pedido ID: {pedido.Id} não pode ser entreque pois nem todas as pizzas foram concluídas!");
            return;
        }

        espacos();
        Terminal.EscrevaAmarelo($"Pedido ID: {pedido.Id}, saiu para entrega no horário {pedido.HorarioDoPedido}!");
        espacos();

        await Task.Delay(5000);  // Simula o tempo de entrega

        pedido.HorarioDaEntrega = DateTime.Now;

        espacos();
        Terminal.EscrevaAzul($"Pedido ID: {pedido.Id}, entregue com sucesso no horário {pedido.HorarioDoPedido}!");
    }

    private void espacos()
    {
        Console.WriteLine("\n");
    }
}
