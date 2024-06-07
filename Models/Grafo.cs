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
                foreach (KeyValuePair<string, Vertice> current in vertices)
                {
                    if (current.Value == verifiedOrigem)
                    {
                        current.Value.prioridade = 0;
                    }
                    naoVisitados.Enqueue(current.Value, current.Value.prioridade);
                }

                while (naoVisitados.Count > 0)
                {
                    naoVisitados.TryDequeue(out Vertice currentVertice, out int currentPrio);
                    currentVertice.visitado = true;
                    Console.WriteLine($"Visitando {currentVertice.nome} com prioridade {currentPrio}");
                    foreach (Aresta currentAresta in currentVertice.arestas)
                    {
                        Vertice currentDestino = currentAresta.destino;
                        Console.WriteLine($"Verificando aresta de {currentVertice.nome} para {currentDestino.nome}");
                        if (!currentDestino.visitado)
                        {
                            // int newPrio = currentPrio + (-1 * currentAresta.peso * (currentPrio - currentVertice.prioridade));
                            int newPrio = currentPrio + currentAresta.peso;
                            Console.WriteLine($"Calculando prioridade de {currentDestino.nome} com base em {currentVertice.nome}: {newPrio}");
                            // if (newPrio < currentVertice.prioridade)
                            // {
                            currentDestino.prioridade = newPrio;
                            currentDestino.nome = currentVertice.nome;
                            naoVisitados.Enqueue(currentDestino, newPrio);
                            // }
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
                while (naoVisitados.Count > 0)
                {
                    naoVisitados.TryDequeue(out Vertice currentVertice, out int currentPrio);
                    caminho.Add(currentVertice.nome + ": " + currentPrio);
                }
                Console.WriteLine($"Caminho de {origem} para {destino}: {string.Join(" -> ", caminho)}");
            }
            else
            {
                Console.WriteLine($"Erro ao encontrar o caminho de {origem} para {destino}!");
            }
        }
    }
}