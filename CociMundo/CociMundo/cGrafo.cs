using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CociMundo
{
    class cGrafo
    {
        Dictionary<string, List<Tuple<string, int>>> Grafo;  //ver tema constructor

        public void AgregarVertice(string vertice) {   //agregamos un nodo
            this.Grafo.Add(vertice, new List<Tuple<string, int>>());
        }

        public void AgregarArista(string vertice_1, string vertice_2, int peso) {  //agregamos un camino entre dos nodos
            Grafo[vertice_1].Add(new Tuple<string, int>(vertice_2, peso));
            Grafo[vertice_2].Add(new Tuple<string, int>(vertice_1, peso));  //al usar caminos no direccionados, ponemos en la lista de ambos el nuevo camino

        }

        void Dijkstra() { }  //recibe dos nodos y devuelve el camino para ir de uno a otro

    }
}
