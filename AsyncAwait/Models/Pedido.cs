namespace AsyncAwait.Models;

public class Pedido
{
    public int Id { get; set; }
    public List<PizzaDoPedido> Pizzas { get; set; }
    public DateTime HorarioDoPedido { get; set; }
    public DateTime HorarioDaEntrega { get; set; }

    public bool TodasPizzasPreparadas()
    {
        return Pizzas.All(p => p.Concluido);
    }
}