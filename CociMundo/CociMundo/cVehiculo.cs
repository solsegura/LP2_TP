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
        public string Modelo;
        int Carga_max;
        Stack<cPedido> PedidosHoy; 
        int Nafta_max;
        int Nafta_act;
        public List<cPedido> todos_los_pedidos;
        cGrafo mapa;
        string Nodo_actual;

        public void Ir(string destino) {
            Dictionary<string, string> auxiliar = this.mapa.Dijkstra(this.Nodo_actual);  //ahora tengo un diccionario que tiene guardados todos los saltos entre nodos
            string nodo_aux = destino;
            Stack<string> Camino_hasta_destino=new Stack<string>();

            Camino_hasta_destino.Push(nodo_aux);  //guardamos el destino al final

            while (nodo_aux != Nodo_actual)
            {
                Camino_hasta_destino.Push(auxiliar[nodo_aux]);  //guardamos de atras para adelante el camino que hay que hacer 
                nodo_aux = auxiliar[nodo_aux];
            }
            Console.WriteLine();

            Console.WriteLine("Para ir de " + Nodo_actual + " hasta " + destino + " el camino es: ");


            int a = Camino_hasta_destino.Count();
            for (int n = 0; n < a; n++)
            {
                //imprimo el siguiente nodo al que voy
                Console.WriteLine(Camino_hasta_destino.Peek());

                this.Nodo_actual = Camino_hasta_destino.Pop();  //vamos recorriendo el camino hasta destino
                //mostrar en el form el nodo actual tipo de otro color
            }
            Console.ReadLine();

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
        public cVehiculo(int cant_viajes_max, string modelo, int carga_max, int nafta_max) {
            this.Cant_viajes_max = cant_viajes_max;
            this.Modelo = modelo;
            this.Carga_max = carga_max;
           // this.Carga_act = 0;
            //this.Cant_viajes_max = 0;
            this.PedidosHoy = new Stack<cPedido>();
            this.Nafta_max = nafta_max;
            this.todos_los_pedidos = new List<cPedido>();
            this.mapa = new cGrafo();
            this.Nodo_actual = "Comuna 9"; //seteamos a todos en liniers
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
        /// Recibe el numero total de pedidos que hay en Cocimundo y retorna una lista con los pedidos que este camion va a repartir hoy
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public void Problema_mochila_dinamico()  //val es mas grande para los elementos que menos tiempo les queda
        {
            foreach(var item in this.todos_los_pedidos){
                item.CalcularVolTotal(); //volumen de cada pedido
            }
            int n = todos_los_pedidos.Count(); //cant de pedidos totales
            int i, w;
            int[,] matriz_dinamica = new int[n + 1, Carga_max + 1]; //volumen del pedido vs volumen del camion
            List<cPedido>[,] cosas_que_llevo = new List<cPedido>[n + 1, Carga_max + 1];   
            //en esta matriz vamos a guardar los pedidos que debemos llevar en el vehiculo (quedan en el orden que llegan, osea ordenados por distancia)
            
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= Carga_max; w++)
                {
                    if (i == 0 || w == 0) { //las rimeras pos son 0
                        matriz_dinamica[i, w] = 0;
                        cosas_que_llevo[i, w] = new List<cPedido>();   
                    }
                    else if (todos_los_pedidos[i - 1].Volumen_total <= w) { //si tengo lugar
                        if (todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total] > matriz_dinamica[i - 1, w] )
                        { //si tengo lugarme fijo si es mejor meter el nuevo o dejar el anterior (valor total nuevo > valor total anterior)

                            matriz_dinamica[i, w] = todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total]; //agrego este nuevo valor
                            cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w - todos_los_pedidos[i - 1].Volumen_total]; //me compio la pos anterior en al nueva
                            cosas_que_llevo[i, w].Add(todos_los_pedidos[i - 1]); //agrego el nuevo al final

                        }
                        else //si no me conviene lo dejo igual
                        {
                            matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                            cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w];

                        }

                    }
                    else //si no tengo lugar lo dejo
                    {
                        matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                        cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w];
                    }


                }
            }
            Console.Clear();

            Console.WriteLine("----------Matriz Dinamica---------");
            Console.WriteLine();

            for (int k = 1; k < Carga_max + 1; k++)
            {
                for (int s=0;s< Carga_max+1;s++)
                {
                     Console.Write(matriz_dinamica[k,s] + " ");
                 }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Este vehiculo lleva los pedidos de :");
            foreach(var item in cosas_que_llevo[n, Carga_max])
            {

                Console.Write(item.Nombre + " ");

            }

            Console.ReadLine();
            Console.Clear();

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
                this.PedidosHoy.Push(item); //meto en la pila
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
