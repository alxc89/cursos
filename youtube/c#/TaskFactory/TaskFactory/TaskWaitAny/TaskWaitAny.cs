namespace TaskFactory.TaskWaitAny;

public static class TaskWaitAny
{
    public static void Main()
    {
        var TaskA = Task.Factory.StartNew(MetodoA);
        var TaskB = Task.Factory.StartNew(MetodoB);

        Console.WriteLine("TaskA id = {0}", TaskA.Id);
        Console.WriteLine("TaskB id = {0}", TaskB.Id);

        var tarefas = new Task[] { TaskA, TaskB };
        int qualTask = Task.WaitAny(tarefas);

        Console.WriteLine($"A Task de id {tarefas[qualTask].Id} acabou primeiro");
        Console.ReadLine();
    }

    public static void MetodoA()
    {
        Console.WriteLine("MetodoA");
        Thread.SpinWait(100000000);
    }

    public static void MetodoB()
    {
        Console.WriteLine("MetodoB");
        Thread.SpinWait(100000000 / 2);
    }
}
