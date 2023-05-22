using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/*
Esta capa se encarga de la interacción con la base de datos.
Aquí se definen las clases y métodos que permiten a la aplicación leer y escribir datos
en la base de datos. Esta capa es responsable de abstraer los detalles de la base de datos
y proporcionar una interfaz de acceso a los datos que sea independiente del proveedor de
la base de datos.
*/

namespace AccesoDatos
{
    public class AccesoDatosClass
    {
        private SqlConnection _conexion;
        private SqlDataReader _lector;
        private SqlCommand _comando;

        public AccesoDatosClass()
        {
            Conexion = new SqlConnection("Data Source=LAPTOP-NHMAE4TA; Initial Catalog=PracticaDB; Integrated Security=True");
            Comando = new SqlCommand();
        }

        public SqlConnection Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        public SqlDataReader Lector
        {
            get { return _lector; }
            set { _lector = value; }
        }

        public SqlCommand Comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        public void SetearConsulta(string consulta)
        {
            //Primero indico al SqlCommand que la consulta que se hará será de tipo string:
            Comando.CommandType = System.Data.CommandType.Text;
            //Luego seteo la consulta que se ingresó por parámetro: 
            Comando.CommandText = consulta;
        }

        public void EjecutarConsulta()
        {
            //Establezco la conexión entre el objeto SqlCommand (Comando) y la base de datos mediante el objeto SqlConnection:
            Comando.Connection = Conexion;
            //Una vez establecida, abro la conexión:
            try
            {
                Conexion.Open();
            } catch (Exception ex)
            {
                Console.WriteLine("Algo salió mal al abrir la conexión.");
                Console.WriteLine(ex.Message);
            }
            //Y ejecuto la consulta hecha previamente en el método SetearConsulta(string consulta):
            Comando.ExecuteNonQuery();
        }

        public void CerrarConexion()
        {
            /*
             Es importante cerrar la conexión a la base de datos después de haber terminado de
            interactuar con ella para liberar los recursos del sistema y evitar problemas de
            rendimiento. Además, es importante cerrar cualquier objeto "SqlDataReader" o
            "SqlCommand" que se haya creado para liberar los recursos asociados con ellos.
            */
            if (Lector != null)
                Lector.Close();
            if (Comando != null)
                Comando.Dispose();
            Conexion.Close();

        }
    }
}
