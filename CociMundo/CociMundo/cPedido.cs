using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CociMundo
{
    enum Prioridad { express, diferido, normal };

    class cPedido
    {
        
        
        public string Nombre;
        string Direccion;
        public int Dist_a_liniers;
       public  int Volumen_total;  //al agregar un prod se debe sumar al vol total
        List<cProducto> Lista_productos;  //esta lista template venia con el c sharp, creo que tiene metodos para agregar, borrar etc
        DateTime Fecha_entrega_act;

        DateTime Fecha_entrega_max;
        public int Val;
        Prioridad Prioridadd;

        public cPedido(string nombre, int volumen, string direcion,  int valor, Prioridad prioridad)
        {
            this.Nombre = nombre;
            this.Direccion = direcion;
            this.Volumen_total = volumen;
            this.Lista_productos = new List<cProducto>();
           // this.Fecha_entrega_max = new cFecha();
            this.Val = valor;
            this.Prioridadd = prioridad;

            if (this.Direccion == "Comuna 2"|| this.Direccion == "Comuna 13"|| this.Direccion == "Comuna 14"|| this.Direccion == "Avellaneda" || this.Direccion == "San Isidro")
                Dist_a_liniers = 4;

            else if (this.Direccion == "Comuna 3"|| this.Direccion == "Comuna 15"|| this.Direccion == "Comuna 12"||this.Direccion == "Comuna 1"|| this.Direccion == "Lanus" || this.Direccion == "San Martin")
                Dist_a_liniers = 3;

            else if (this.Direccion == "Comuna 4"|| this.Direccion == "Comuna 5"|| this.Direccion == "Comuna 6"|| this.Direccion == "Comuna 11" || this.Direccion == "Moron" || this.Direccion == "Lomas de Zamora")
                Dist_a_liniers = 2;

           
            else if (this.Direccion == "Comuna 7"|| this.Direccion == "Comuna 8"|| this.Direccion == "Comuna 10"|| this.Direccion == "La Matanza" || this.Direccion == "Tres de Febrero")
                Dist_a_liniers = 1;


            else if (this.Direccion == "Comuna 9")
                Dist_a_liniers = 0;


            switch (Prioridadd)
            {
                case Prioridad.express:
                    this.Fecha_entrega_max = Fecha_entrega_act.AddDays(1);
                    break;
                case Prioridad.diferido:
                    this.Fecha_entrega_max = Fecha_entrega_act.AddHours(96);
                    break;
                case Prioridad.normal:
                    this.Fecha_entrega_max = Fecha_entrega_act.AddHours(72);
                    break;

            }

        }


      
    }
}
