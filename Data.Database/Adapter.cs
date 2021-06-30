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
        private SqlConnection sqlConnection;

        //Esto es un agregado aparte
        string conexion = null;


        public SqlConnection _SqlConnection
        {
            get { return sqlConnection; }
            set { sqlConnection = value; }
        }



        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        
        protected void OpenConnection()
        {
            //string conexion = System.Configuration.ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            //throw new Exception("Metodo no implementado");

            conexion = @"Data source = LAPTOP-3IUT7RL9; Initial Catalog = Academia; Integrated Security = True";
            _SqlConnection = new SqlConnection(conexion);
            _SqlConnection.Open();
        }

        protected void CloseConnection()
        {
            _SqlConnection.Close();
            _SqlConnection = null;
            //throw new Exception("Metodo no implementado");
        }



        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
