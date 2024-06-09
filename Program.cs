using Aula_13___Dijkstra.Models;

Grafo grafo = new Grafo();
grafo.AdicionaVertice("0");
grafo.AdicionaVertice("1");
grafo.AdicionaVertice("2");
grafo.AdicionaVertice("3");
grafo.AdicionaVertice("4");
grafo.AdicionaVertice("5");
grafo.AdicionaVertice("6");

grafo.AdicionaAresta("0", "1", 5);
grafo.AdicionaAresta("0", "3", 21);
grafo.AdicionaAresta("1", "2", 40);
grafo.AdicionaAresta("2", "3", 13);
grafo.AdicionaAresta("2", "4", 19);
grafo.AdicionaAresta("3", "5", 41);
grafo.AdicionaAresta("4", "5", 32);
grafo.AdicionaAresta("4", "6", 14);
grafo.AdicionaAresta("5", "6", 8);

var watch = System.Diagnostics.Stopwatch.StartNew();
grafo.caminhoMinimoDijkstra("0", "6");
watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
// grafo.caminhoMinimoDijkstra("A", "F");
