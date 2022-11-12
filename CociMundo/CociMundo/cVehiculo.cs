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


        public void Ir(Destino Destino) { }  //no se   que onda esto pero le tengo que poner public a cada metodo, no se como hacer el constructor y destructor
        public void Repartir(cPedido pedido) { }
        public void CargarNafta() {
            this.Nafta_act = Nafta_max;
        }

        /// <summary>
        /// Constructor para testear
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="carga_max"></param>
        public cVehiculo(string modelo, int carga_max) {  
            this.Modelo = modelo;
            this.Carga_max = carga_max;
            this.Elevador = false;
            this.Cant_viajes_max = 0;
            this.Carga_act = 0;
            this.PedidosHoy = new Stack<cPedido>();
            this.Nafta_act = 0;
            this.Nafta_max = 0;
            this.todos_los_pedidos = new List<cPedido>();
            this.mapa = new cGrafo();
        }


        /// <summary>
        /// Recibe el numero total de pedidos que hay en Cocimundo y retorna una lista con los pedidos que este camion va a repartir hoy
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<cPedido> Problema_mochila_dinamico( int n)  //val es mas grande para los elementos que menos tiempo les queda
        {
            
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
                        if (todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total] > matriz_dinamica[i - 1, w])
                        {

                            matriz_dinamica[i, w] = todos_los_pedidos[i - 1].Val + matriz_dinamica[i - 1, w - todos_los_pedidos[i - 1].Volumen_total];
                            cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w - todos_los_pedidos[i - 1].Volumen_total];
                            cosas_que_llevo[i, w].Add(todos_los_pedidos[i - 1]);

                        }
                        else
                        {
                            matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                            cosas_que_llevo[1, w] = cosas_que_llevo[i - 1, w];

                        }

                    }
                    else
                    {
                        matriz_dinamica[i, w] = matriz_dinamica[i - 1, w];
                        cosas_que_llevo[i, w] = cosas_que_llevo[i - 1, w];
                    }


                }
            }

            return cosas_que_llevo[n,Carga_max];   //ni siquiera hace falta retornar, podriamos directamente meterlo en el stack y a la vez ponerlo en el forms
        }

    }
}
