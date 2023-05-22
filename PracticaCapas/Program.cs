using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;
using PracticaCapas.Implementaciones;

/*
Esta capa es la interfaz de usuario de la aplicación y se encarga de mostrar la información
al usuario final y de recopilar la entrada del usuario. Esta capa puede incluir formularios,
controles de usuario, páginas web, servicios web o cualquier otro tipo de interfaz de usuario
que se utilice en la aplicación.
*/

namespace Presentacion
{
    internal class Program
    {
        static Validacion validacion = new Validacion();
        static NegocioCliente negocioCliente = new NegocioCliente();
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("APLICACIÓN DE CONSOLA CON BASE DE DATOS SQL:");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("1- Agregar registro.");
                Console.WriteLine("2- Editar registro.");
                Console.WriteLine("3- Eliminar registro.");
                Console.WriteLine("4- Ver registro.");
                Console.WriteLine("5- Ver todos los registros.");
                Console.WriteLine("6- Salir.");
                Console.WriteLine("-----------------------------------------");

                Console.Write("Escoge una opción: ");
                int resp = validacion.IngresarRespuesta();

                switch (resp)
                {
                    case 1:
                        AgregarRegistro();
                        break;
                    case 2:
                        EditarRegistro();
                        break;
                    case 3:
                        EliminarRegistro();
                        break;
                    case 4:
                        VerRegistro();
                        break;
                    case 5:
                        VerRegistros();
                        break;
                    case 6:
                        continuar = false;
                        break;
                }
            }
        }
        
        static void AgregarRegistro()
        {
            Console.Write("Ingrese DNI: ");
            int dni = validacion.CrearDNI();
            Console.Write("Ingrese Nombre: ");
            string nombre = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Apellido: ");
            string apellido = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Edad: ");
            int edad = validacion.CrearEdad();
            Console.Write("Ingrese País: ");
            string pais = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Género: ");
            string genero = validacion.CrearGenero();

            negocioCliente.AgregarRegistro(dni, nombre, apellido, edad, pais, genero);
            Console.WriteLine("¡Registro creado con éxito!");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void EditarRegistro()
        {
            Console.WriteLine("Ingrese el DNI: ");
            int dni = validacion.IngresarDNI();
            Console.WriteLine("A continuación ingrese los nuevos datos para el registro:");
            Console.Write("Ingrese Nombre: ");
            string nombre = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Apellido: ");
            string apellido = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Edad: ");
            int edad = validacion.CrearEdad();
            Console.Write("Ingrese País: ");
            string pais = validacion.CrearNombreApellidoPais();
            Console.Write("Ingrese Género: ");
            string genero = validacion.CrearGenero();

            negocioCliente.EditarRegistro(dni, nombre, apellido, edad, pais, genero);
            Console.WriteLine("¡Registro editado con éxito!");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void EliminarRegistro()
        {
            Console.WriteLine("Ingrese el DNI: ");
            int dni = validacion.IngresarDNI();

            negocioCliente.EliminarRegistro(dni);
            Console.WriteLine("¡Registro eliminado con éxito!");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void VerRegistro()
        {
            Console.WriteLine("Ingrese el DNI: ");
            int dni = validacion.IngresarDNI();

            Cliente cliente = negocioCliente.VerRegistro(dni);
            Console.WriteLine("\nRegistro del cliente:");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void VerRegistros()
        {
            List<Cliente> lista = new List<Cliente>();
            lista = negocioCliente.VerRegistros();
            Console.WriteLine("\nRegistros de clientes:");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            foreach (Cliente cliente in lista)
            {
                Console.WriteLine(cliente.ToString());
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
