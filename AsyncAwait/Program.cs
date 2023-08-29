using AsyncAwait.Models;
using AsyncAwait.Servicos;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando programa Async");

        var pizzas = new List<Pizza> {
            new Pizza { Sabor = "Frango com Catupiry", Tempo = 9000 },
            new Pizza { Sabor = "Mussarela", Tempo = 5000 },
            new Pizza { Sabor = "Pepperoni", Tempo = 7000 },
            new Pizza { Sabor = "Calabresa", Tempo = 5500 }
        };

        var inicioAsync = DateTime.Now;
        await ExecutaAsync.FacaAsync(pizzas, true);
        var duracaoAsync = DateTime.Now - inicioAsync;
        Terminal.Espacos();
        Console.WriteLine($"Demorou {duracaoAsync.TotalMinutes:0.##} Minutos/Segundos para a execução Async");
        Terminal.Espacos();

        Console.WriteLine("Iniciando programa Sync");
        var inicioSync = DateTime.Now;
        ExecutaSync.Faca(pizzas);
        Terminal.Espacos();
        var duracaoSync = DateTime.Now - inicioSync;
        Console.WriteLine($"Demorou {duracaoSync.TotalMinutes:0.##} Minutos/Segundos para a execução Sync");

        Console.Read();
    }

}