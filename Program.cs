using Aula_13___Dijkstra.Models;

Grafo grafo = new Grafo();
grafo.AdicionaVertice("A");
grafo.AdicionaVertice("B");
grafo.AdicionaVertice("C");
grafo.AdicionaVertice("D");
grafo.AdicionaVertice("E");
grafo.AdicionaVertice("F");

grafo.AdicionaAresta("A", "B", 3);
grafo.AdicionaAresta("A", "C", 7);
grafo.AdicionaAresta("A", "D", 8);
grafo.AdicionaAresta("B", "E", 9);
grafo.AdicionaAresta("C", "F", 4);
grafo.AdicionaAresta("D", "F", 5);

grafo.caminhoMinimoDijkstra("A", "E");
grafo.caminhoMinimoDijkstra("A", "F");
