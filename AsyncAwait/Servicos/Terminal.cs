
namespace AsyncAwait.Servicos;

public class Terminal
{
    public static void EscrevaVerde(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public static void EscrevaBranco(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public static void EscrevaVermelho(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public static void EscrevaAmarelo(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public static void EscrevaAzul(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public static void Espacos()
    {
        Console.WriteLine("\n");
    }
}