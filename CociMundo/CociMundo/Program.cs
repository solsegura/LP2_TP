using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CociMundo
{
   // enum Destino { Comuna1, Comuna2 };  //esto lo vamos a borrar
   // enum Prioridad { express, diferido, el_otro };

    
    static class Program
    {

        static string[] Todos_los_destinos = new string[]{"Comuna 1", "Comuna 2", "Comuna 3", "Comuna 4", "Comuna 5", "Comuna 6", "Comuna 7", "Comuna 8", "Comuna 9",
                                    "Comuna 10", "Comuna 11", "Comuna 12", "Comuna 13", "Comuna 14", "Comuna 15", "San Isidro", "Vicente Lopez", "La Matanza",
                                    "Lanus", "Tres de Febrero", "Avellaneda", "Lomas de Zamora", "Moron", "San Martin" };



    [STAThread]
        static void Main()
        {
            cCocimundo cocimundo = new cCocimundo();

            DateTime Fecha1 = new DateTime(2022, 11, 13);
            DateTime Fecha2 = new DateTime(2022, 11, 12);
            DateTime Fecha3 = new DateTime(2022, 11, 11);


            cProducto Heladera = new cProducto("heladera", 10, 2000);
            cProducto Microondas = new cProducto("microondas", 4, 100);
            cProducto Licuadora = new cProducto("licuadora", 1, 300);
            cProducto TV = new cProducto("TV", 2, 3000);
            cProducto Tostadora = new cProducto("tostadora", 1, 200);

            cPedido Pedido1 = new cPedido("Fiorella", Todos_los_destinos[0], Prioridad.diferido, Fecha1);
            cPedido Pedido2 = new cPedido("Sol", Todos_los_destinos[0], Prioridad.express, Fecha1);  //de los mas prioritarios
            cPedido Pedido3 = new cPedido("Valentina", Todos_los_destinos[1], Prioridad.normal, Fecha2);
            cPedido Pedido4 = new cPedido("Rosario", Todos_los_destinos[6], Prioridad.normal, Fecha1);
            cPedido Pedido5 = new cPedido("Eze", Todos_los_destinos[17], Prioridad.normal, Fecha3);
            cPedido Pedido6 = new cPedido("El Pampa", Todos_los_destinos[23], Prioridad.normal, DateTime.Today);  //el menos prioritario
            cPedido Pedido7 = new cPedido("Andrea", Todos_los_destinos[6], Prioridad.express, Fecha1);
            cPedido Pedido8 = new cPedido("Bruno", Todos_los_destinos[19], Prioridad.diferido, Fecha3);

            Pedido1.Lista_productos.Add(Heladera);  //fio necesita dos heladeras
            Pedido1.Lista_productos.Add(Heladera);
            Pedido1.Lista_productos.Add(Microondas);

            Pedido2.Lista_productos.Add(TV);
            Pedido2.Lista_productos.Add(Microondas);
            
            Pedido3.Lista_productos.Add(Licuadora);

            Pedido4.Lista_productos.Add(Tostadora);
            Pedido4.Lista_productos.Add(TV);
            Pedido4.Lista_productos.Add(TV);

            Pedido5.Lista_productos.Add(Licuadora); //eze renueva la cocina
            Pedido5.Lista_productos.Add(Microondas);
            Pedido5.Lista_productos.Add(Heladera);
            Pedido5.Lista_productos.Add(Tostadora);
            
            Pedido6.Lista_productos.Add(Tostadora);

            
            Pedido7.Lista_productos.Add(TV);

            Pedido8.Lista_productos.Add(Microondas);
            Pedido8.Lista_productos.Add(Heladera);

            cVehiculo Furgon = new cVehiculo(1, "no se", 30);
            cVehiculo Furgoneta = new cVehiculo(1, "no se", 20);
            cVehiculo Camioneta = new cVehiculo(4, "no se", 30);

            cocimundo.Todos_los_pedidos.Add(Pedido1);
            cocimundo.Todos_los_pedidos.Add(Pedido2);
            cocimundo.Todos_los_pedidos.Add(Pedido3);
            cocimundo.Todos_los_pedidos.Add(Pedido4);
            cocimundo.Todos_los_pedidos.Add(Pedido5);
            cocimundo.Todos_los_pedidos.Add(Pedido6);
            cocimundo.Todos_los_pedidos.Add(Pedido7);
            cocimundo.Todos_los_pedidos.Add(Pedido8);

            cocimundo.VectorVehiculo.Add(Furgon);
            cocimundo.VectorVehiculo.Add(Furgoneta);
            cocimundo.VectorVehiculo.Add(Camioneta);

            Furgon.SetPedidos(cocimundo.Todos_los_pedidos);
            Furgoneta.SetPedidos(cocimundo.Todos_los_pedidos);
            Camioneta.SetPedidos(cocimundo.Todos_los_pedidos);


            //auto.todos_los_pedidos.Add(pe1);
            //auto.todos_los_pedidos.Add(pe2);
            //auto.todos_los_pedidos.Add(pe3);
            //auto.todos_los_pedidos.Add(pe4);

            //List<cPedido> algo = auto.Problema_mochila_dinamico(4);
            // Dictionary<string, List<Tuple<string, int>>> Grafo;
            cGrafo Grafo = new cGrafo();

            foreach(var item in Todos_los_destinos)
            {
                Grafo.AgregarVertice(item);
            }

            Grafo.AgregarArista(Todos_los_destinos[0], Todos_los_destinos[1], 2); //los de comuna 1
            Grafo.AgregarArista(Todos_los_destinos[0], Todos_los_destinos[2], 5);
            Grafo.AgregarArista(Todos_los_destinos[0], Todos_los_destinos[3], 3);

            Grafo.AgregarArista(Todos_los_destinos[1], Todos_los_destinos[0], 2);
            Grafo.AgregarArista(Todos_los_destinos[1], Todos_los_destinos[2], 4);
            Grafo.AgregarArista(Todos_los_destinos[1], Todos_los_destinos[13], 3);

            Grafo.AgregarArista(Todos_los_destinos[2], Todos_los_destinos[0], 5);
            Grafo.AgregarArista(Todos_los_destinos[2], Todos_los_destinos[1], 4);
            Grafo.AgregarArista(Todos_los_destinos[2], Todos_los_destinos[3], 2);
            Grafo.AgregarArista(Todos_los_destinos[2], Todos_los_destinos[4], 1);

            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[0], 3);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[2], 2);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[4], 4);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[6], 5);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[7], 3);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[18], 4);
            Grafo.AgregarArista(Todos_los_destinos[3], Todos_los_destinos[20], 3);

            Grafo.AgregarArista(Todos_los_destinos[4], Todos_los_destinos[2], 2);
            Grafo.AgregarArista(Todos_los_destinos[4], Todos_los_destinos[3], 4);
            Grafo.AgregarArista(Todos_los_destinos[4], Todos_los_destinos[14], 7);
            Grafo.AgregarArista(Todos_los_destinos[4], Todos_los_destinos[6], 2);
            Grafo.AgregarArista(Todos_los_destinos[4], Todos_los_destinos[5], 9);


            Grafo.AgregarArista(Todos_los_destinos[5], Todos_los_destinos[4], 9);
            Grafo.AgregarArista(Todos_los_destinos[5], Todos_los_destinos[14], 5);
            Grafo.AgregarArista(Todos_los_destinos[5], Todos_los_destinos[10], 2);
            Grafo.AgregarArista(Todos_los_destinos[5], Todos_los_destinos[6], 3);

            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[5], 3);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[4], 2);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[3], 5);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[7], 2);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[10], 8);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[9], 10);
            Grafo.AgregarArista(Todos_los_destinos[6], Todos_los_destinos[8], 1);

            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[3], 3);
            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[6], 2);
            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[8], 4);
            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[17], 7);
            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[21], 5);
            Grafo.AgregarArista(Todos_los_destinos[7], Todos_los_destinos[18], 2);

            Grafo.AgregarArista(Todos_los_destinos[8], Todos_los_destinos[6], 1);
            Grafo.AgregarArista(Todos_los_destinos[8], Todos_los_destinos[9], 1);
            Grafo.AgregarArista(Todos_los_destinos[8], Todos_los_destinos[7], 4);
            Grafo.AgregarArista(Todos_los_destinos[8], Todos_los_destinos[19], 6);
            Grafo.AgregarArista(Todos_los_destinos[8], Todos_los_destinos[17], 15);

            Grafo.AgregarArista(Todos_los_destinos[9], Todos_los_destinos[8], 1);
            Grafo.AgregarArista(Todos_los_destinos[9], Todos_los_destinos[6], 10);
            Grafo.AgregarArista(Todos_los_destinos[9], Todos_los_destinos[10], 2);

            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[9], 2);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[6], 8);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[5], 2);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[14], 6);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[11], 4);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[23], 5);
            Grafo.AgregarArista(Todos_los_destinos[10], Todos_los_destinos[19], 9);

            Grafo.AgregarArista(Todos_los_destinos[11], Todos_los_destinos[10], 4);
            Grafo.AgregarArista(Todos_los_destinos[11], Todos_los_destinos[14], 5);
            Grafo.AgregarArista(Todos_los_destinos[11], Todos_los_destinos[12], 2);
            Grafo.AgregarArista(Todos_los_destinos[11], Todos_los_destinos[16], 7);

            Grafo.AgregarArista(Todos_los_destinos[12], Todos_los_destinos[11], 2);
            Grafo.AgregarArista(Todos_los_destinos[12], Todos_los_destinos[16], 3);
            Grafo.AgregarArista(Todos_los_destinos[12], Todos_los_destinos[13], 3);
           
            Grafo.AgregarArista(Todos_los_destinos[13], Todos_los_destinos[12], 3);
            Grafo.AgregarArista(Todos_los_destinos[13], Todos_los_destinos[14], 10);
            Grafo.AgregarArista(Todos_los_destinos[13], Todos_los_destinos[1], 3);

            Grafo.AgregarArista(Todos_los_destinos[14], Todos_los_destinos[5], 5);
            Grafo.AgregarArista(Todos_los_destinos[14], Todos_los_destinos[4], 7);
            Grafo.AgregarArista(Todos_los_destinos[14], Todos_los_destinos[13], 10);
            Grafo.AgregarArista(Todos_los_destinos[14], Todos_los_destinos[11], 5);
            Grafo.AgregarArista(Todos_los_destinos[14], Todos_los_destinos[10], 6);

            Grafo.AgregarArista(Todos_los_destinos[15], Todos_los_destinos[16], 4);
            Grafo.AgregarArista(Todos_los_destinos[15], Todos_los_destinos[23], 7);

            Grafo.AgregarArista(Todos_los_destinos[16], Todos_los_destinos[11], 7);
            Grafo.AgregarArista(Todos_los_destinos[16], Todos_los_destinos[12], 3);
            Grafo.AgregarArista(Todos_los_destinos[16], Todos_los_destinos[15], 4);
            Grafo.AgregarArista(Todos_los_destinos[16], Todos_los_destinos[23], 2);

            Grafo.AgregarArista(Todos_los_destinos[17], Todos_los_destinos[7], 7);
            Grafo.AgregarArista(Todos_los_destinos[17], Todos_los_destinos[8], 15);
            Grafo.AgregarArista(Todos_los_destinos[17], Todos_los_destinos[22], 10);
            Grafo.AgregarArista(Todos_los_destinos[17], Todos_los_destinos[21], 8);

            Grafo.AgregarArista(Todos_los_destinos[18], Todos_los_destinos[3], 4);
            Grafo.AgregarArista(Todos_los_destinos[18], Todos_los_destinos[7], 2);
            Grafo.AgregarArista(Todos_los_destinos[18], Todos_los_destinos[21], 6);
            Grafo.AgregarArista(Todos_los_destinos[18], Todos_los_destinos[20], 5);


            Grafo.AgregarArista(Todos_los_destinos[19], Todos_los_destinos[10], 9);
            Grafo.AgregarArista(Todos_los_destinos[19], Todos_los_destinos[8], 6);
            Grafo.AgregarArista(Todos_los_destinos[19], Todos_los_destinos[23], 6);
            Grafo.AgregarArista(Todos_los_destinos[19], Todos_los_destinos[22], 10);

            Grafo.AgregarArista(Todos_los_destinos[20], Todos_los_destinos[3], 3);
            Grafo.AgregarArista(Todos_los_destinos[20], Todos_los_destinos[18], 5);
           
            Grafo.AgregarArista(Todos_los_destinos[21], Todos_los_destinos[7], 5);
            Grafo.AgregarArista(Todos_los_destinos[21], Todos_los_destinos[18], 6);
            Grafo.AgregarArista(Todos_los_destinos[21], Todos_los_destinos[17], 8);

            Grafo.AgregarArista(Todos_los_destinos[22], Todos_los_destinos[19], 10);
            Grafo.AgregarArista(Todos_los_destinos[22], Todos_los_destinos[17], 10);

            Grafo.AgregarArista(Todos_los_destinos[23], Todos_los_destinos[10], 5);
            Grafo.AgregarArista(Todos_los_destinos[23], Todos_los_destinos[16], 2);
            Grafo.AgregarArista(Todos_los_destinos[23], Todos_los_destinos[15], 7);
            Grafo.AgregarArista(Todos_los_destinos[23], Todos_los_destinos[19], 6);



            cocimundo.enviarVehiculos();


            //FINAL DEL DIA
            Furgon.SetCantViajes(1);
            Furgoneta.SetCantViajes(1);
            Camioneta.SetCantViajes(4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
