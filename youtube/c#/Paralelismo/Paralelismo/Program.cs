using Paralelismo;
using Paralelismo.Exemplo1;
using System.Diagnostics;

//Exemplo1.Iniciar();

string[] ceps = new string[5];
ceps[0] = "15010050";
ceps[1] = "08473690";
ceps[2] = "77445100";
ceps[3] = "13312015";
ceps[4] = "07994060";

var parallelOptions = new ParallelOptions
{
    MaxDegreeOfParallelism = 32
};
var stopWatch = new Stopwatch();
stopWatch.Start();
Parallel.ForEach(ceps, parallelOptions, cep =>
{
    Console.WriteLine(new ViaCepService().GetCep(cep) + $" Thread {Environment.CurrentManagedThreadId}");
});
//foreach (var c in ceps)
//    Console.WriteLine(new ViaCepService().GetCep(c) + $" Thread {Environment.CurrentManagedThreadId}");
stopWatch.Stop();
Console.WriteLine($"O tempo de processamento total é de {stopWatch.ElapsedMilliseconds} ms");