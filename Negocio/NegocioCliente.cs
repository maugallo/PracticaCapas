using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class NegocioCliente
    {
        AccesoDatosClass accesoDatos = new AccesoDatosClass();
        public List<Cliente> VerRegistros()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                accesoDatos.SetearConsulta("SELECT * FROM Clientes");
                accesoDatos.EjecutarConsulta();
                accesoDatos.Lector = accesoDatos.Comando.ExecuteReader();
                while (accesoDatos.Lector.Read())
                {
                    Cliente clienteRegistro = new Cliente((int)accesoDatos.Lector["DNI"], (string)accesoDatos.Lector["Nombre"], (string)accesoDatos.Lector["Apellido"], (int)accesoDatos.Lector["Edad"], (string)accesoDatos.Lector["Pais"], (string)accesoDatos.Lector["Genero"]);
                    listaClientes.Add(clienteRegistro);
                }
                return listaClientes;
            } catch (Exception ex)
            {
                Console.WriteLine("Error - Exception: " + ex.Message);
                Console.WriteLine("Tipo de Exception: " + ex.GetType().ToString());
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
            return listaClientes;
        }

        public void AgregarRegistro(int dni, string nombre, string apellido, int edad, string pais, string genero)
        {
            try
            {
                accesoDatos.SetearConsulta($"INSERT INTO Clientes (DNI, Nombre, Apellido, Edad, Pais, Genero) VALUES ({dni}, '{nombre}', '{apellido}', {edad}, '{pais}', '{genero}');");
                accesoDatos.EjecutarConsulta();
                
            } catch (Exception ex)
            {
                Console.WriteLine("Exception - Error: " + ex.Message);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
        public bool ExisteDNI(int dni)
        {
            int count=0;
            try
            {
                accesoDatos.SetearConsulta("SELECT COUNT(*) FROM Clientes WHERE DNI = " + dni);
                accesoDatos.EjecutarConsulta();
                accesoDatos.Lector = accesoDatos.Comando.ExecuteReader();
                while (accesoDatos.Lector.Read())
                {
                    count = (int)accesoDatos.Lector[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception - Error: " + ex.Message);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
            if (count == 0) return false;
            else return true;
        }
        public void EditarRegistro(int dni, string nombre, string apellido, int edad, string pais, string genero)
        {
            try
            {
                accesoDatos.SetearConsulta($"UPDATE Clientes SET Nombre = '{nombre}', Apellido = '{apellido}', Pais = '{pais}', Genero = '{genero}', Edad = {edad} WHERE DNI = {dni}");
                accesoDatos.EjecutarConsulta();
            }catch (Exception ex)
            {
                Console.WriteLine("Exception - Error: " + ex.Message);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public void EliminarRegistro(int dni)
        {
            try
            {
                accesoDatos.SetearConsulta($"DELETE FROM Clientes WHERE DNI = {dni};");
                accesoDatos.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception - Error: " + ex.Message);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public Cliente VerRegistro(int dni)
        {
            Cliente clienteRegistro = new Cliente();
            try
            {
                accesoDatos.SetearConsulta($"SELECT * FROM Clientes WHERE DNI = {dni}");
                accesoDatos.EjecutarConsulta();
                accesoDatos.Lector = accesoDatos.Comando.ExecuteReader();
                while (accesoDatos.Lector.Read())
                {
                    clienteRegistro = new Cliente((int)accesoDatos.Lector["DNI"], (string)accesoDatos.Lector["Nombre"], (string)accesoDatos.Lector["Apellido"], (int)accesoDatos.Lector["Edad"], (string)accesoDatos.Lector["Pais"], (string)accesoDatos.Lector["Genero"]);
                }
                return clienteRegistro;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception - Error: " + ex.Message);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
            return clienteRegistro;
        }
    }
}
