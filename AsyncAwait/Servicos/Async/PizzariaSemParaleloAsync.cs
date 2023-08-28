using System;
using System.Threading.Tasks;
using AsyncAwait.Models;

namespace AsyncAwait.Servicos.Async;

public class PizzariaSemParaleloAsync
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

        Terminal.Espacos();
        Terminal.EscrevaBranco($"Pedido de pizza com sabores {string.Join(", ", pedido.Pizzas.Select(p => p.Pizza.Sabor))} realizado às {pedido.HorarioDoPedido}!");
        Terminal.EscrevaBranco($"Seu ID é: {pedido.Id}");
        Terminal.Espacos();
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
        foreach (var pizzaDoPedido in pedido.Pizzas)
        {
            await prepararPizzaAsync(pizzaDoPedido);
        }
    }


    public async Task EntregarPizzaAsync(Pedido pedido)
    {
        if (!pedido.TodasPizzasPreparadas())
        {
            Terminal.Espacos();
            Terminal.EscrevaVermelho($"Pedido ID: {pedido.Id} não pode ser entreque pois nem todas as pizzas foram concluídas!");
            return;
        }

        Terminal.Espacos();
        Terminal.EscrevaAmarelo($"Pedido ID: {pedido.Id}, saiu para entrega no horário {pedido.HorarioDoPedido}!");
        Terminal.Espacos();

        await Task.Delay(5000);  // Simula o tempo de entrega

        pedido.HorarioDaEntrega = DateTime.Now;

        Terminal.Espacos();
        Terminal.EscrevaAzul($"Pedido ID: {pedido.Id}, entregue com sucesso no horário {pedido.HorarioDoPedido}!");
    }
}
