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

        Dictionary<string,int> Dijkstra(string nodo_partida) {
            HashSet<string> Lo_que_ya_visite = new HashSet<string>();
            string nodo_actual;
            Dictionary<string, int> dist_hasta = new Dictionary<string, int>();
            Dictionary<string, string> salto_anterior = new Dictionary<string, string>();
            foreach (var item in this.Grafo){
                dist_hasta[item.Key] = int.MaxValue;  //inicializo en valor muy grande la lista de distancias desde mi nodo de partida hasta el resto
            }
            dist_hasta[nodo_partida] = 0;
            //si primera vez, inicializo en inf el resto

            for(int n = 0; n < this.Grafo.Count();n++) {
                nodo_actual = Min_distancia(Lo_que_ya_visite, dist_hasta);
                Lo_que_ya_visite.Add(nodo_partida);

                foreach(var (nodo, peso) in this.Grafo[nodo_actual]){  //me guardo el mejor camino 
                    if (!Lo_que_ya_visite.Contains(nodo) && dist_hasta[nodo] > dist_hasta[nodo_actual] + peso)
                    {
                        dist_hasta[nodo] = dist_hasta[nodo_actual] + peso;
                        salto_anterior[nodo] = nodo_actual;
                    }
                }
            }
            return dist_hasta;  //dist hasta ahora contiene las distancias mas cortas entre nodo_partida y todo el resto de los nodos (ver video, o preguntar)

            //salto_anterior tiene nodo_destino , nodo del que vengo entonces cuando quiero recomponer el camino para saber como ir de A a C, le paso a dijktra A, y uso salto_anterior[C] para ir de atras para adelante y ver que camino era
        }  
        

        string Min_distancia(HashSet<string> Lo_que_ya_visite, Dictionary<string, int> dist_hasta) {
            int min = int.MaxValue;
            string nodo_min="nada";
            foreach (var item in dist_hasta){
                if (!Lo_que_ya_visite.Contains(item.Key) && dist_hasta[item.Key]< min) {  //recorro la lista de distancias desde el nodo de partida y me guardo la minima (y el nodo de destino que le corresponde
                    min = dist_hasta[item.Key];
                    nodo_min = item.Key;
                }

            }
            return nodo_min;
        }
    }
}
