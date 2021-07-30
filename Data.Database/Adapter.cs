using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConnection;

        //Esto es un agregado aparte
        string conexion = null;


        //Nuevo constructor por el profe
        public Adapter()
        {
            conexion = @"Data Source=localhost;Initial Catalog=Academia;Integrated Security=True";
            SqlConnection = new SqlConnection(conexion);
        }


        public SqlConnection SqlConnection
        {
            get { return _sqlConnection; }
            set { _sqlConnection = value; }
        }


        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        
        protected void OpenConnection()
        {
            //string conexion = System.Configuration.ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            //throw new Exception("Metodo no implementado");

            //conexion = @"Data Source=localhost;Initial Catalog=Academia;Integrated Security=True";
            //SqlConnection = new SqlConnection(conexion);
            SqlConnection.Open();
        }

        protected void CloseConnection()
        {
            SqlConnection.Close();
            SqlConnection = null;
        }



        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
