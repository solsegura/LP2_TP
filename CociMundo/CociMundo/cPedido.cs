using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CociMundo
{
    class cPedido
    {
        string Nombre;
        destino Direccion;
        int Volumen_total;  //al agregar un prod se debe sumar al vol total
        List<cProducto> Lista_productos;  //esta lista template venia con el c sharp, creo que tiene metodos para agregar, borrar etc
        cFecha Fecha_entrega_max;
        prioridad Prioridad;

    }
}
