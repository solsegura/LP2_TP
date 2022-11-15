using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CociMundo
{
    class cVehiculo
    {
        int Cant_viajes_max;
        string Modelo;
        int Carga_max;
        int Carga_act;
        bool Elevador;
        Stack<cPedido> PedidosHoy; // una pila        tu pila y mi cola
        int Nafta_max;
        int Nafta_act;
        public List<cPedido> todos_los_pedidos;
        cGrafo mapa;
        string Nodo_actual;

        public void Ir(string destino) {
            Dictionary<string, string> auxiliar = this.mapa.Dijkstra(this.Nodo_actual);  //ahora tengo un diccionario que tiene guardados todos los saltos entre nodos
            string nodo_aux = destino;
            Stack<string> Camino_hasta_destino=new Stack<string>();
            while (nodo_aux != Nodo_actual)
            {
                Camino_hasta_destino.Push(auxiliar[nodo_aux]);  //guardamos de atras para adelante el camino que hay que hacer 
                nodo_aux = auxiliar[nodo_aux];
            }

            for(int n = 0; n < Camino_hasta_destino.Count(); n++)
            {
                this.Nodo_actual = Camino_hasta_destino.Pop();  //vamos recorriendo el camino hasta destino
                //mostrar en el form el nodo actual tipo de otro color
            }

        }  
        public void Repartir() {
            if (this.Cant_viajes_max > 0)
            {
                for (int n = 0; n < this.PedidosHoy.Count; n++)
                {
                    Ir(PedidosHoy.Peek().Direccion);  //voy a la direccion
                    this.Nodo_actual = PedidosHoy.Peek().Direccion;  //ahora estoy en esta direccion tendria que aparecer un cartel tipo ACA Entrego
                    this.PedidosHoy.Pop();  //lo entrego
                }
                Ir("Comuna 9");  //vuelvo a Liniers despues de repartir todo
                this.Cant_viajes_max--;   //ya hice un viaje hoy entonces lo resto
            }
            
        }
        public void CargarNafta() {
            this.Nafta_act = Nafta_max;
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="carga_max"></param>
        public cVehiculo(int cant_viajes_max, string modelo, int carga_max) {
            this.Cant_viajes_max = cant_viajes_max;
            this.Modelo = modelo;
            this.Carga_max = carga_max;
            this.Carga_act = 0;
            //this.Cant_viajes_max = 0;
            this.PedidosHoy = new Stack<cPedido>();
            this.Nafta_max = 0;
            this.todos_los_pedidos = new List<cPedido>();
            this.mapa = new cGrafo();
            this.Nodo_actual = "Comuna 9";
        }

        public void SetPedidos(List<cPedido> pedidos)
        {
            this.todos_los_pedidos = pedidos;

        }
        public void SetGrafo(cGrafo g)
        {
            this.mapa = g;

        }

        /// <summary>
        /// ordenamos todos los pedidos de mas lejos de liniers a mas cerca
        /// </summary>
        /// <param name="cant_pedidos"></param>
        //public void Ordenar_por_destino(int cant_pedidos)
        //{
        //    for (int n = 0; n < cant_pedidos; n++)
        //    {
        //        for(int i=0; i < cant_pedidos-1; i++)
        //        {
        //            if (todos_los_pedidos[i].Dist_a_liniers < todos_los_pedidos[i + 1].Dist_a_liniers)
        //            {
        //                cPedido aux = todos_los_pedidos[i];    
        //                todos_los_pedidos[i] = todos_los_pedidos[i + 1];
        //                todos_los_pedidos[i + 1] = aux;
        //            }
        //        }
        //    }

        //    this.Problema_mochila_dinamico(cant_pedidos); //una vez que esta ordenado ya podemos evaluar cuales van al camion
        //}

        /// <summary>
        /// Recibe el numero total de pedidos que hay en Cocimundo y retorna una lista con los pedidos que este camion va a repartir hoy
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public void Problema_mochila_dinamico( )  //val es mas grande para los elementos que menos tiempo les queda
        {
            foreach(var item in this.todos_los_pedidos){
                item.CalcularVolTotal();
            }
            int n = todos_los_pedidos.Count();
            int i, w;
            int[,] matriz_dinamica = new int[n + 1, Carga_max + 1];
            List<cPedido>[,] cosas_que_llevo = new List<cPedido>[n + 1, Carga_max + 1];   //en esta matriz vamos a guardar los pedidos que debemos llevar en el vehiculo (quedan en el orden que llegan, osea ordenados por distancia)
            
            int c = 0;
            
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= Carga_max; w++)
                {
                    if (i == 0 || w == 0) {
                        matriz_dinamica[i, w] = 0;
                        cosas_que_llevo[i, w] = new List<cPedido>();   
                    }
                    else if (todos_los_pedidos[i - 1].Volumen_total <= w) {
                        if (todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total] > matriz_dinamica[i - 1, w] )
                        {

                            matriz_dinamica[i, w] = todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total];
                            cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w - todos_los_pedidos[i - 1].Volumen_total];
                            cosas_que_llevo[i, w].Add(todos_los_pedidos[i - 1]);

                        }
                        else
                        {
                            matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                            cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w];

                        }

                    }
                    else
                    {
                        matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                        cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w];
                    }


                }
            }
            this.Llenar_vehiculo(cosas_que_llevo[n, Carga_max]);  //lleno el vehiculo con la lista que queda en la matriz
           
        }

        /// <summary>
        /// meto en la pila las cosas que el camion lleva hoy, quedan al fondo del camion los que estan a mayor distancia de liniers
        /// </summary>
        /// <param name="cosas_que_llevo"></param>
        public void Llenar_vehiculo(List<cPedido> cosas_que_llevo)
        {
            int cant_pedidos = cosas_que_llevo.Count();
            for (int n = 0; n < cant_pedidos; n++)   //primero lo ordeno de mas lejos de liniers a mas cerca para que al meterlos al camion queden los mas lejanos al fondo
            {
                for (int i = 0; i < cant_pedidos - 1; i++)
                {
                    if (cosas_que_llevo[i].Dist_a_liniers < cosas_que_llevo[i + 1].Dist_a_liniers)
                    {
                        cPedido aux = cosas_que_llevo[i];
                        cosas_que_llevo[i] = cosas_que_llevo[i + 1];
                        cosas_que_llevo[i + 1] = aux;
                    }
                }
            }  
            foreach (var item in cosas_que_llevo)
            {
                this.PedidosHoy.Push(item);
                this.todos_los_pedidos.Remove(item); //lo borro de la lista de todos los productos porque ya lo saque del almacen
            }

            this.Repartir();  //cuando termino de cargar el camion, reparto

        }

        
        public void SetCantViajes(int c)
        {
            this.Cant_viajes_max = c;
        }

    }

   
}
