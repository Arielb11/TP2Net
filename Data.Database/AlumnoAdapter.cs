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
    public class AlumnoAdapter:Adapter
    {

        //Done
        public List<Alumno> GetAll()
        {


            //Instanciamos el objeto de lista para retornar
            List<Alumno> alumnos = new List<Alumno>();

            
            try
            {

                //Creamos la sentencia a ejecutar
                SqlCommand cmdAlumnos = new SqlCommand("SELECT * FROM alumnos", SqlConnection);

                //Apertura de la conexión a la base de datos
                this.OpenConnection();

                //Objeto DataReader, recuperará los datos de la base de datos
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                //Read() lee una fila de las devueltas por el comando sql
                //carga los datos en drUsuarios para poder accederlos,
                //devuelve verdadero mientras haya podido leer datos, 
                //y avanza a la fila siguiente para el próximo read.


                while (drAlumnos.Read())
                {
                    Alumno alu = new Alumno();

                    alu.ID = (int)drAlumnos["id_usuario"];
                    alu.IdAlumno = (int)drAlumnos["id_alumno"];
                    alu.IdCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (int)drAlumnos["nota"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    
                    alumnos.Add(alu);

                }

                //Cerramos el DataReader y la conexión a la DataBase
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            
            return alumnos;
        }

        //Done
        public Alumno GetOne(int ID)
        {

            Alumno alu = new Alumno();

            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("SELECT * FROM alumnos WHERE id_alumno = @id", SqlConnection);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                if (drAlumnos.Read())
                {
                    alu.IdAlumno = (int)drAlumnos["id_alumno"];
                    alu.IdCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (int)drAlumnos["nota"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.ID = (int)drAlumnos["id_usuario"];
                }
                drAlumnos.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos del alumno", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return alu;
        }

        //Done
        public void Delete(int ID)
        {

            try
            {
                //Abro la conexión
                this.OpenConnection();

                //Creo la sentencia SQL
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos WHERE id_alumno = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecuto la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el alumno", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        //Done
        public void Save(Alumno alu)
        {
            if (alu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alu.IdAlumno);
            }
            else if (alu.State == BusinessEntity.States.New)
            {
                this.Insert(alu);
            }
            else if (alu.State == BusinessEntity.States.Modified)
            {
                this.Update(alu);
            }
            alu.State = BusinessEntity.States.Unmodified;
        }


        //Check It out
        protected void Update(Alumno alu)
        {
            try
            {
                
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos SET id_curso = @id_curso, nota = @nota, " +
                    "condicion = @condicion, id_usuario = @id_usuario WHERE id_alumno = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alu.IdAlumno;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = alu.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alu.IdCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alu.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alu.Condicion;

                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManeja = new Exception("Error al modificar datos del alumno", e);
                throw excepcionManeja;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        //Done
        protected void Insert(Alumno alu)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos (id_curso, nota, condicion, id_usuario) " +
                    "VALUES (@id_curso, @nota, @condicion, @id_usuario) " +
                    "SELECT @@identity",    //Esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConnection);

                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = alu.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alu.IdCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alu.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alu.Condicion;
                alu.IdAlumno = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el ID que asignó al BD automáticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


    }
}
