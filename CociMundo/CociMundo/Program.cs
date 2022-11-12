using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

 

namespace CociMundo
{
    enum Destino { Comuna1, Comuna2 };
    enum Prioridad { express, diferido, el_otro };


    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            cVehiculo auto = new cVehiculo("auto",10);
            cPedido pe1 = new cPedido(3, 10);
            cPedido pe2 = new cPedido(1, 12);
            cPedido pe3 = new cPedido(10, 13);
            cPedido pe4 = new cPedido(2, 14);

            auto.todos_los_pedidos.Add(pe1);
            auto.todos_los_pedidos.Add(pe2);
            auto.todos_los_pedidos.Add(pe3);
            auto.todos_los_pedidos.Add(pe4);

            int algo = auto.Problema_mochila_dinamico(4);

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
