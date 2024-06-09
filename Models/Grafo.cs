using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_13___Dijkstra.Models
{
    public class Grafo
    {
        Dictionary<string, Vertice> vertices;

        public Grafo()
        {
            vertices = new Dictionary<string, Vertice>();
        }

        public void AdicionaVertice(string nome)
        {
            Vertice v = new Vertice(nome);
            if (vertices.TryAdd(nome, v))
            {
                Console.WriteLine($"Vertice {nome} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Erro ao adicionar o vertice {nome}!");
            }
        }

        public void AdicionaAresta(string origem, string destino, int peso)
        {
            if (vertices.TryGetValue(origem, out Vertice verifiedOrigem) && vertices.TryGetValue(destino, out Vertice verifiedDestino))
            {
                Aresta a = new Aresta(verifiedOrigem, verifiedDestino, peso);
                verifiedOrigem.AdicionaAresta(a);
                Console.WriteLine($"Aresta de {origem} para {destino} adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine($"Erro ao adicionar a aresta de {origem} para {destino}!");
            }
        }

        public void caminhoMinimoDijkstra(string origem, string destino)
        {
            if (vertices.TryGetValue(origem, out Vertice verifiedOrigem) && vertices.TryGetValue(destino, out Vertice verifiedDestino))
            {
                PriorityQueue<Vertice, int> naoVisitados = new PriorityQueue<Vertice, int>();
                // foreach (KeyValuePair<string, Vertice> current in vertices)
                // {
                //     if (current.Value == verifiedOrigem)
                //     {
                //         current.Value.prioridade = 0;
                //     }
                //     naoVisitados.Enqueue(current.Value, current.Value.prioridade);
                // }
                vertices[destino].path.Add(vertices[origem]);
                naoVisitados.Enqueue(verifiedOrigem, 0);

                while (naoVisitados.TryPeek(out Vertice peekedVertice, out int peekedDistance) && peekedDistance != int.MaxValue)
                {
                    naoVisitados.TryDequeue(out Vertice currentVertice, out int currentDistance);
                    Console.WriteLine($"Visitando {currentVertice.nome} com distancia {currentDistance}");
                    // if (vertices[currentVertice.nome].visitado)
                    // {
                    //     Console.WriteLine($"Vertice {currentVertice.nome} ja foi visitado!");
                    //     continue;
                    // }
                    vertices[currentVertice.nome].visitado = true;
                    foreach (Aresta aresta in currentVertice.arestas)
                    {
                        Vertice currentDestino = aresta.destino;
                        if (!vertices[currentDestino.nome].visitado)
                        {
                            if (currentDistance + aresta.peso < vertices[currentDestino.nome].prioridade)
                            {
                                vertices[currentDestino.nome].prioridade = currentDistance + aresta.peso;
                                if (vertices[currentDestino.nome].path.Count > 0)
                                {
                                    vertices[currentDestino.nome].path.Clear();
                                    vertices[currentDestino.nome].path.AddRange(vertices[currentVertice.nome].path);
                                }
                                vertices[currentDestino.nome].path.Add(vertices[currentVertice.nome]);
                                naoVisitados.Enqueue(vertices[currentDestino.nome], vertices[currentDestino.nome].prioridade);
                            }
                        }
                    }
                }

                Vertice v = verifiedDestino;
                List<string> caminho = new List<string>();
                // while (v != null)
                // {
                //     caminho.Add(v.nome);
                //     v = vertices[v.nome];
                // }
                // caminho.Reverse();
                // while (naoVisitados.Count > 0)
                // {
                //     naoVisitados.TryDequeue(out Vertice currentVertice, out int currentPrio);
                //     caminho.Add(currentVertice.nome + ": " + currentPrio);
                // }
                Console.WriteLine($"Caminho de {origem} para {destino}: {vertices[origem].nome} -> {string.Join(" -> ", vertices[destino].path.Select(v => v.nome))} -> {vertices[destino].nome} com distancia {vertices[destino].prioridade}!");
            }
            else
            {
                Console.WriteLine($"Erro ao encontrar o caminho de {origem} para {destino}!");
            }
        }
    }
}