namespace TaskFactory.CShp_Task;

public static class CShp_Task
{
    public static void Main()
    {
        var task1 = Task.Factory.StartNew(FazerAlgo);
        Console.ReadKey();
    }
    public static void FazerAlgo()
    {
        Console.WriteLine("Executando uma tarefa => FazerAlgo()(task1)");
        Thread.Sleep(2000);
        Console.WriteLine("retornando...");
    }
}
