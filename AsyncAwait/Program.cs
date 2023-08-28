using AsyncAwait.Models;
using AsyncAwait.Servicos;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando programa Sync");

        var pizzas = new List<Pizza> {
            new Pizza { Sabor = "Frago com Catupiri", Tempo = 9000 },
            new Pizza { Sabor = "Mussarela", Tempo = 5000 },
            new Pizza { Sabor = "Peperone", Tempo = 7000 },
            new Pizza { Sabor = "Calabresa", Tempo = 5500 }
        };

        await ExecutaAsync.FacaAsync(pizzas);

        // Console.WriteLine("Iniciando programa Async");
        // ExecutaSync.Faca();

        Console.Read();
    }
}