using System.Diagnostics;

namespace Paralelismo.Exemplo1;

public static class Exemplo1
{
    public static void Iniciar()
    {
        var stopWatch = new Stopwatch();
        var acao1 = new Action(Processo1);
        var acao2 = new Action(Processo2);
        var acao3 = new Action(Processo3);
        stopWatch.Start();
        Parallel.Invoke(acao1, acao2, acao3);
        stopWatch.Stop();
        Console.WriteLine($"O tempo de processamento total é de {stopWatch.ElapsedMilliseconds} ms");
    }

    static void Processo1()
    {
        Console.WriteLine($"Processo 1 finalizado Thread: {Environment.CurrentManagedThreadId}");
        Thread.Sleep(1000);
    }

    static void Processo2()
    {
        Console.WriteLine($"Processo 2 finalizado Thread: {Environment.CurrentManagedThreadId}");
        Thread.Sleep(1000);
    }

    static void Processo3()
    {
        Console.WriteLine($"Processo 3 finalizado Thread: {Environment.CurrentManagedThreadId}");
        Thread.Sleep(1000);
    }
}
