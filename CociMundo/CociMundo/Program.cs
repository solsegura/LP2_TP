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

        static string[] Todos_los_destinos = new string[]
        {"Comuna 1", "Comuna 2", "Comuna 3", "Comuna 4", "Comuna 5","Comuna 6", "Comuna 7", "Comuna 8", "Comuna 9",
         "Comuna 10", "Comuna 11", "Comuna 12", "Comuna 13", "Comuna 14", "Comuna 15", "San Isidro", "Vicente Lopez", 
         "La Matanza", "Lanus", "Tres de Febrero", "Avellaneda", "Lomas de Zamora", "Moron", "San Martin" };



        [STAThread]
        static void Main()
        {
            cCocimundo cocimundo = new cCocimundo();

            DateTime Fecha1 = new DateTime(2022, 11, 12);
            DateTime Fecha2 = new DateTime(2022, 11, 13);
            DateTime Fecha3 = new DateTime(2022, 11, 14);
            DateTime Fecha4= new DateTime(2022, 11, 15);

            cProducto Heladera = new cProducto("Heladera", 4, 2000);
            cProducto Microondas = new cProducto("Microondas", 2, 100);
            cProducto Licuadora = new cProducto("Licuadora", 1, 300);
            cProducto TV = new cProducto("TV", 3, 3000);
            cProducto Tostadora = new cProducto("Tostadora", 1, 200);
            cProducto Cafetera = new cProducto("Cafetera", 1, 200);
            cProducto Molinillo = new cProducto("Molinillo", 1, 100);
            cProducto Termotanque = new cProducto("Termo", 5, 5000);
            cProducto Lavaropas = new cProducto("Lavaropa", 3, 1100);
            cProducto Freezer = new cProducto("Freezer", 3, 2500);
            cProducto Impresora = new cProducto("Impresora", 2, 1200);
            cProducto Computadora = new cProducto("Compu", 2, 2000);
            cProducto Mouse = new cProducto("Raton", 1, 200);
            cProducto Parlante = new cProducto("Parlante", 1, 200);

            cPedido Pedido1 = new cPedido("Fiorella", Todos_los_destinos[0], Prioridad.diferido, Fecha1);
            cPedido Pedido2 = new cPedido("Sol", Todos_los_destinos[0], Prioridad.express, DateTime.Today);  //de los mas prioritariosLO CAMBIE
            cPedido Pedido3 = new cPedido("Valentina", Todos_los_destinos[1], Prioridad.normal, Fecha2);
            cPedido Pedido4 = new cPedido("Rosario", Todos_los_destinos[6], Prioridad.normal, Fecha1);
            cPedido Pedido5 = new cPedido("Ezequiel", Todos_los_destinos[17], Prioridad.normal, Fecha2);
            cPedido Pedido6 = new cPedido("El Pampa", Todos_los_destinos[23], Prioridad.normal, DateTime.Today);  //el menos prioritario 
            cPedido Pedido7 = new cPedido("Andrea", Todos_los_destinos[6], Prioridad.express, DateTime.Today);
            cPedido Pedido8 = new cPedido("Bruno", Todos_los_destinos[19], Prioridad.diferido, Fecha3);
            cPedido Pedido9 = new cPedido("Julieta", Todos_los_destinos[9], Prioridad.express, DateTime.Today);
            cPedido Pedido10 = new cPedido("Lorena", Todos_los_destinos[3], Prioridad.normal, Fecha2);
            cPedido Pedido11= new cPedido("Sirne", Todos_los_destinos[5], Prioridad.normal, Fecha1);
            cPedido Pedido12= new cPedido("Franco", Todos_los_destinos[7], Prioridad.diferido, Fecha4);
            cPedido Pedido13= new cPedido("Eduardo", Todos_los_destinos[20], Prioridad.express, DateTime.Today);
            cPedido Pedido14= new cPedido("Fabricio", Todos_los_destinos[13], Prioridad.diferido, Fecha3);
            cPedido Pedido15= new cPedido("Candela", Todos_los_destinos[4], Prioridad.express, DateTime.Today);
            cPedido Pedido16= new cPedido("Sofia", Todos_los_destinos[8], Prioridad.diferido, Fecha4);
            cPedido Pedido17= new cPedido("Victoria", Todos_los_destinos[13], Prioridad.normal, Fecha4);
            cPedido Pedido18= new cPedido("Fiona", Todos_los_destinos[10], Prioridad.diferido, Fecha2);
            cPedido Pedido19= new cPedido("Melina", Todos_los_destinos[9], Prioridad.express, Fecha4); //si o si mañana
            cPedido Pedido20= new cPedido("Trinidad", Todos_los_destinos[11], Prioridad.normal, Fecha1);
            cPedido Pedido21= new cPedido("Joaquin", Todos_los_destinos[12], Prioridad.diferido, Fecha3);
            cPedido Pedido22= new cPedido("Martina", Todos_los_destinos[23], Prioridad.normal, Fecha1);
            cPedido Pedido23 = new cPedido("Francisco", Todos_los_destinos[2], Prioridad.diferido, Fecha3);


            Pedido1.Lista_productos.Add(Licuadora);   //vol 1

            Pedido2.Lista_productos.Add(Microondas); //vol 2
            
            Pedido3.Lista_productos.Add(Tostadora);  //vol 3
            Pedido3.Lista_productos.Add(Impresora);  

            Pedido4.Lista_productos.Add(TV); //vol 4
            Pedido4.Lista_productos.Add(Tostadora);

            Pedido5.Lista_productos.Add(Licuadora); //eze renueva la cocina
            Pedido5.Lista_productos.Add(Microondas); //vol 5
            Pedido5.Lista_productos.Add(Computadora);
            
            Pedido6.Lista_productos.Add(Heladera);  //vol 6
            Pedido6.Lista_productos.Add(Impresora);

            Pedido7.Lista_productos.Add(Lavaropas);
            Pedido7.Lista_productos.Add(Freezer);
            Pedido7.Lista_productos.Add(Parlante);  // vol 7

            Pedido8.Lista_productos.Add(Cafetera);
            Pedido8.Lista_productos.Add(Molinillo);
            Pedido8.Lista_productos.Add(Mouse); //vol 8
            Pedido8.Lista_productos.Add(Parlante);
            Pedido8.Lista_productos.Add(Licuadora);
            Pedido8.Lista_productos.Add(Lavaropas);

            Pedido9.Lista_productos.Add(Termotanque); //vol 9
            Pedido9.Lista_productos.Add(Computadora);
            Pedido9.Lista_productos.Add(Microondas);

            Pedido10.Lista_productos.Add(Termotanque); //vol 10
            Pedido10.Lista_productos.Add(Termotanque);

            Pedido11.Lista_productos.Add(Microondas); //vol 11
            Pedido11.Lista_productos.Add(Heladera);
            Pedido11.Lista_productos.Add(Termotanque);

            Pedido12.Lista_productos.Add(Termotanque); //vol 12
            Pedido12.Lista_productos.Add(Heladera);
            Pedido12.Lista_productos.Add(Lavaropas);

            Pedido13.Lista_productos.Add(Microondas); //vol 13
            Pedido13.Lista_productos.Add(Parlante);
            Pedido13.Lista_productos.Add(Parlante);
            Pedido13.Lista_productos.Add(Parlante);
            Pedido13.Lista_productos.Add(Parlante);
            Pedido13.Lista_productos.Add(Tostadora);
            Pedido13.Lista_productos.Add(Tostadora);
            Pedido13.Lista_productos.Add(Tostadora);
            Pedido13.Lista_productos.Add(Tostadora);
            Pedido13.Lista_productos.Add(Tostadora);
            Pedido13.Lista_productos.Add(Tostadora);

            Pedido14.Lista_productos.Add(Microondas); //vol14
            Pedido14.Lista_productos.Add(Microondas);
            Pedido14.Lista_productos.Add(Termotanque);
            Pedido14.Lista_productos.Add(Termotanque);

            Pedido15.Lista_productos.Add(TV); //vol 15
            Pedido15.Lista_productos.Add(TV);
            Pedido15.Lista_productos.Add(TV);
            Pedido15.Lista_productos.Add(TV);
            Pedido15.Lista_productos.Add(TV);

            Pedido16.Lista_productos.Add(Heladera); //vol 16
            Pedido16.Lista_productos.Add(Heladera);
            Pedido16.Lista_productos.Add(Heladera);
            Pedido16.Lista_productos.Add(Heladera);

            Pedido17.Lista_productos.Add(Heladera); //vol 17
            Pedido17.Lista_productos.Add(TV);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);
            Pedido17.Lista_productos.Add(Mouse);

            Pedido18.Lista_productos.Add(Mouse); //vol 18
            Pedido18.Lista_productos.Add(Mouse);
            Pedido18.Lista_productos.Add(Heladera);
            Pedido18.Lista_productos.Add(Heladera);
            Pedido18.Lista_productos.Add(Heladera);
            Pedido18.Lista_productos.Add(Heladera);

            Pedido19.Lista_productos.Add(Termotanque); //vol 19 
            Pedido19.Lista_productos.Add(Licuadora);
            Pedido19.Lista_productos.Add(Termotanque);
            Pedido19.Lista_productos.Add(Licuadora);
            Pedido19.Lista_productos.Add(Heladera);
            Pedido19.Lista_productos.Add(Freezer);

            Pedido20.Lista_productos.Add(Licuadora); //vol 20
            Pedido20.Lista_productos.Add(Licuadora);
            Pedido20.Lista_productos.Add(Mouse); 
            Pedido20.Lista_productos.Add(Mouse);
            Pedido20.Lista_productos.Add(Heladera);
            Pedido20.Lista_productos.Add(Heladera);
            Pedido20.Lista_productos.Add(Heladera);
            Pedido20.Lista_productos.Add(Heladera);

            Pedido21.Lista_productos.Add(Microondas); //vol 21
            Pedido21.Lista_productos.Add(Microondas);
            Pedido21.Lista_productos.Add(Termotanque);
            Pedido21.Lista_productos.Add(Termotanque);
            Pedido21.Lista_productos.Add(Termotanque);
            Pedido21.Lista_productos.Add(Impresora);

            Pedido22.Lista_productos.Add(Microondas); //vol 22
            Pedido22.Lista_productos.Add(Microondas);
            Pedido22.Lista_productos.Add(Microondas);
            Pedido22.Lista_productos.Add(Heladera); 
            Pedido22.Lista_productos.Add(Heladera);
            Pedido22.Lista_productos.Add(Heladera);
            Pedido22.Lista_productos.Add(Heladera);

            Pedido23.Lista_productos.Add(TV); //vol 23
            Pedido23.Lista_productos.Add(TV);
            Pedido23.Lista_productos.Add(TV);
            Pedido23.Lista_productos.Add(TV);
            Pedido23.Lista_productos.Add(Molinillo);
            Pedido23.Lista_productos.Add(Molinillo);
            Pedido23.Lista_productos.Add(Molinillo);
            Pedido23.Lista_productos.Add(Molinillo);
            Pedido23.Lista_productos.Add(Cafetera);
            Pedido23.Lista_productos.Add(Cafetera);
            Pedido23.Lista_productos.Add(Cafetera);
            Pedido23.Lista_productos.Add(Cafetera);
            Pedido23.Lista_productos.Add(Freezer);
         
            cVehiculo Furgon = new cVehiculo(1, "Iveco Daily", 17, 5000);
            cVehiculo Furgoneta = new cVehiculo(1, "Fiat Ducato", 10, 1000);
            cVehiculo Camioneta = new cVehiculo(4, "Renault Kangoo Express", 5, 60);

            cocimundo.Todos_los_pedidos.Add(Pedido1);
            cocimundo.Todos_los_pedidos.Add(Pedido2);
            cocimundo.Todos_los_pedidos.Add(Pedido3);
            cocimundo.Todos_los_pedidos.Add(Pedido4);
            cocimundo.Todos_los_pedidos.Add(Pedido5);
            cocimundo.Todos_los_pedidos.Add(Pedido6);
            cocimundo.Todos_los_pedidos.Add(Pedido7);
            cocimundo.Todos_los_pedidos.Add(Pedido8);
            cocimundo.Todos_los_pedidos.Add(Pedido9);
            cocimundo.Todos_los_pedidos.Add(Pedido10);
            cocimundo.Todos_los_pedidos.Add(Pedido11);
            cocimundo.Todos_los_pedidos.Add(Pedido12);
            cocimundo.Todos_los_pedidos.Add(Pedido13);
            cocimundo.Todos_los_pedidos.Add(Pedido14);
            cocimundo.Todos_los_pedidos.Add(Pedido15);
            cocimundo.Todos_los_pedidos.Add(Pedido16);
            cocimundo.Todos_los_pedidos.Add(Pedido17);
            cocimundo.Todos_los_pedidos.Add(Pedido18);
            cocimundo.Todos_los_pedidos.Add(Pedido19);
            cocimundo.Todos_los_pedidos.Add(Pedido20);
            cocimundo.Todos_los_pedidos.Add(Pedido21);
            cocimundo.Todos_los_pedidos.Add(Pedido22);
            cocimundo.Todos_los_pedidos.Add(Pedido23);

            cocimundo.VectorVehiculo.Add(Furgon);
            cocimundo.VectorVehiculo.Add(Furgoneta);
            cocimundo.VectorVehiculo.Add(Camioneta);

            Furgon.SetPedidos(cocimundo.Todos_los_pedidos); //le pasamos todos los pedidos y despues c/u se qeuda con lo que le corresponde
            Furgoneta.SetPedidos(cocimundo.Todos_los_pedidos);
            Camioneta.SetPedidos(cocimundo.Todos_los_pedidos);

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

            Furgon.SetGrafo(Grafo);
            Furgoneta.SetGrafo(Grafo); //le paso el mapa a cada vehiculo
            Camioneta.SetGrafo(Grafo);

            cocimundo.enviarVehiculos();

            //FINAL DEL DIA ------ seteo los viajes para mañana
            Furgon.SetCantViajes(1);
            Furgoneta.SetCantViajes(1);
            Camioneta.SetCantViajes(4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
