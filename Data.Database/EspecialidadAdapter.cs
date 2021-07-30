using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {

        //Done
        public List<Especialidad> GetAll()
        {
            //La línea 77 pertenecía a la implementación sin base de datos
            //return new List<Usuario>(Usuarios);

            //Instanciamos el objeto de lista para retornar
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                //Creamos la sentencia a ejecutar
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConnection);

                //Apertura de la conexión a la base de datos
                this.OpenConnection();

                //Objeto DataReader, recuperará los datos de la base de datos

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                //Read() lee una fila de las devueltas por el comando sql
                //carga los datos en drUsuarios para poder accederlos,
                //devuelve verdadero mientras haya podido leer datos, 
                //y avanza a la fila siguiente para el próximo read.


                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(esp);

                }
                //Cerramos el DataReader y la conexión a la DataBase
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }


        //Done
        public void Save(Especialidad esp)
        {
            if (esp.State == BusinessEntity.States.Deleted)
            {
                this.Delete(esp.ID);
            }
            else if (esp.State == BusinessEntity.States.New)
            {
                this.Insert(esp);
            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                this.Update(esp);
            }
            esp.State = BusinessEntity.States.Unmodified;
        }



        //Check this out
        public void Delete(int ID)
        {
            try
            {
                //Abro la conexión
                this.OpenConnection();

                //Creo la sentencia SQL
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecuto la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el usuario", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }



        //Done
        protected void Update(Especialidad esp)
        {
            try
            {
                

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE id_especialidad = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Descripcion;

                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManeja = new Exception("Error al modificar datos de la especialidad", e);
                throw excepcionManeja;
            }

            finally
            {
                this.CloseConnection();
            }

        }


        //Done
        public Especialidad GetOne(int ID)
        {
            //Parte previa a la base de datos
            //return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });


            Especialidad esp = new Especialidad();

            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", SqlConnection);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de especialidad", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return esp;
        }

        //Done
        protected void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades (desc_especialidad) " +
                    "VALUES (@desc_especialidad) " +
                    "SELECT @@identity",    //Esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConnection);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                esp.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el ID que asignó al BD automáticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


    }
}
