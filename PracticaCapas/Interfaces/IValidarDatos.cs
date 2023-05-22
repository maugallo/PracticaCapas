using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCapas.Interfaces
{
    internal interface IValidarDatos
    {
        int IngresarRespuesta();
        int CrearDNI();
        int IngresarDNI();
        string CrearNombreApellidoPais();
        int CrearEdad();
        string CrearGenero();
    }
}
