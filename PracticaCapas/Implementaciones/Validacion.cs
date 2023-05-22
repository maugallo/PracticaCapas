using Negocio;
using PracticaCapas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticaCapas.Implementaciones
{
    class Validacion : IValidarDatos
    {
        public int IngresarRespuesta()
        {
            int result;
            string resp = Console.ReadLine();
            while (int.TryParse(resp, out result) == false || result < 1 || result > 6)
            {
                Console.WriteLine("Ingrese un valor válido: ");
                resp = Console.ReadLine();
            }
            return result;
        }

        public int CrearDNI()
        {
            int dni;
            NegocioCliente negocioCliente = new NegocioCliente();
            bool existe;
            string resp;
            while (true)
            {
                resp = Console.ReadLine();
                while (int.TryParse(resp, out dni) == false || dni > 99999999)
                {
                    Console.WriteLine("Ingrese un valor válido: ");
                    resp = Console.ReadLine();
                }

                existe = negocioCliente.ExisteDNI(dni);
                if (existe)
                {
                    Console.WriteLine("Ese DNI ya existe! ");
                }
                else return dni;
            }
        }

        public int IngresarDNI()
        {
            int dni;
            NegocioCliente negocioCliente = new NegocioCliente();
            bool existe;
            string resp;
            while (true)
            {
                resp = Console.ReadLine();
                while (int.TryParse(resp, out dni) == false || dni > 99999999)
                {
                    Console.WriteLine("Ingrese un valor válido: ");
                    resp = Console.ReadLine();
                }

                existe = negocioCliente.ExisteDNI(dni);
                if (existe == false)
                {
                    Console.WriteLine("Ese DNI no existe! ");
                }
                else return dni;
            }
        }
        public string CrearNombreApellidoPais()
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            string resp = Console.ReadLine();
            while (regex.IsMatch(resp) == false)
            {
                Console.WriteLine("Ingrese un valor válido: ");
                resp = Console.ReadLine();
            }
            return resp;
        }
        public int CrearEdad()
        {
            int edad;
            string resp = Console.ReadLine();
            while (int.TryParse(resp, out edad) == false)
            {
                Console.WriteLine("Ingrese un valor válido: ");
                resp = Console.ReadLine();
            }
            return edad;
        }
        public string CrearGenero()
        {
            string resp = Console.ReadLine().ToLower();
            while (resp != "masculino" && resp != "femenino")
            {
                Console.WriteLine("Ingrese un valor válido: ");
                resp = Console.ReadLine().ToLower();
            }
            return resp;
        }
    }
}
