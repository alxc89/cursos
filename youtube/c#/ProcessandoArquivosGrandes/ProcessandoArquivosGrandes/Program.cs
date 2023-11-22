using ProcessandoArquivosGrandes.ProcessandoArquivo;
using System.Diagnostics;

var before0 = GC.CollectionCount(0);
var before1 = GC.CollectionCount(1);
var before2 = GC.CollectionCount(2);

var sw = new Stopwatch();
sw.Start();
//Run.Main(@"C:\Users\alexc\Documents\dev\ratings.csv");
//Run.Main2(@"C:\Users\alexc\Documents\dev\ratings.csv");
//Run.Main3(@"C:\Users\alexc\Documents\dev\ratings.csv");
Run.Main4(@"C:\Users\alexc\Documents\dev\ratings.csv");
sw.Stop();

Console.WriteLine($"\nTime: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"# Gen0: {GC.CollectionCount(0) - before0}");
Console.WriteLine($"# Gen1: {GC.CollectionCount(1) - before1}");
Console.WriteLine($"# Gen2: {GC.CollectionCount(2) - before2}");
Console.WriteLine($"Memory: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} mb");