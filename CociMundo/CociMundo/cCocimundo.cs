using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CociMundo
{
    class cCocimundo
    {
        public List<cVehiculo> VectorVehiculo;
        public List<cPedido> Todos_los_pedidos;

        public cCocimundo() {
            this.VectorVehiculo = new List<cVehiculo>();
            this.Todos_los_pedidos = new List<cPedido>();
        }

        public void OrdenarPorVolumen()
        {
            int cant_pedidos = this.Todos_los_pedidos.Count();
            for (int n = 0; n < cant_pedidos; n++)
            {
                for (int i = 0; i < cant_pedidos - 1; i++)
                {
                    if (Todos_los_pedidos[i].Volumen_total > Todos_los_pedidos[i + 1].Volumen_total) //ordeno de menor a mayor
                    {
                        cPedido aux = Todos_los_pedidos[i];
                        Todos_los_pedidos[i] = Todos_los_pedidos[i + 1];
                        Todos_los_pedidos[i + 1] = aux;
                    }
                }
            }
        }
        public void Ordenar_por_destino()
        {
            int cant_pedidos = this.Todos_los_pedidos.Count();
            for (int n = 0; n < cant_pedidos; n++)
            {
                for (int i = 0; i < cant_pedidos - 1; i++)
                {
                    if (Todos_los_pedidos[i].Dist_a_liniers < Todos_los_pedidos[i + 1].Dist_a_liniers)
                    {
                        cPedido aux = Todos_los_pedidos[i];
                        Todos_los_pedidos[i] = Todos_los_pedidos[i + 1];
                        Todos_los_pedidos[i + 1] = aux;
                    }
                }
            }
            
            //una vez que esta ordenado ya podemos evaluar cuales van a cada camion
        }

        public void enviarVehiculos() {

            this.OrdenarPorVolumen();
            foreach (var item in VectorVehiculo)
            {
                item.Problema_mochila_dinamico();
                this.Todos_los_pedidos = item.todos_los_pedidos; //actualizamos la lista con los que quedarons
            }
        }
    }


}
