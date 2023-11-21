namespace TaskFactory.TaskWaitAll;

public static class TaskWaitAll
{
    public static void Main()
    {
        var TaskA = Task.Factory.StartNew(MetodoA);
        var TaskB = Task.Factory.StartNew(MetodoB);
        Task.WaitAll(new Task[] { TaskA, TaskB }, 5000);
        //Task.WaitAll(new Task[] { TaskA, TaskB }, 5000(tempo definido para esperar a Task terminar));
        Console.WriteLine("Completou todas as tarefas");
        Console.ReadLine();
    }

    public static void MetodoA()
    {
        Console.WriteLine("Iniciando MetodoA...");
        Thread.Sleep(2000);
        Console.WriteLine("Concluindo MetodoA...");
    }
    public static void MetodoB()
    {
        Console.WriteLine("Iniciando MetodoB...");
        Thread.Sleep(3000);
        Console.WriteLine("Concluindo MetodoB...");
    }
}
