using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Esta capa representa el modelo de dominio de la aplicación.
Aquí se definen las entidades, los objetos y las relaciones que componen el modelo de datos
de la aplicación. Esta capa es responsable de definir la estructura y el comportamiento
del modelo de datos de la aplicación.
*/

namespace Dominio
{
    public class Cliente
    {
        private int _dni;
        private string _nombre;
        private string _apellido;
        private int _edad;
        private string _pais;
        private string _genero;

        public Cliente()
        {

        }
        public Cliente(int DNI, string Nombre, String Apellido, int Edad, string Pais, string Genero)
        {
            _dni = DNI;
            _nombre = Nombre;
            _apellido = Apellido;
            _edad = Edad;
            _pais = Pais;
            _genero = Genero;
        }
        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }
        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public override string ToString()
        {
            return $"DNI: {DNI} - Nombre: {Nombre} - Apellido: {Apellido} - Edad: {Edad} - Pais: {Pais} - Género: {Genero}";
        }
    }
}
