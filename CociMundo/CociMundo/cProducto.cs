using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CociMundo
{
    class cProducto
    {
        string Descripcion;
        int Volumen;
        int Precio;

        public cProducto(string descripcion, int volumen, int precio)
        {
            this.Descripcion = descripcion;
            this.Volumen = volumen;
            this.Precio = precio;
        }
    }
}

