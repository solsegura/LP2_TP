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


        public void Ir(destino Destino) { }  //no se   que onda esto pero le tengo que poner public a cada metodo, no se como hacer el constructor y destructor
        public void Repartir(cPedido pedido) { }
        public void CargarNafta() { }

    }
}
