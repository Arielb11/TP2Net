using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class AlumnoAdapter:Adapter
    {

        #region datosEnMemoria
        //Región en memoria para hacer consultas
        //Borrarla al acceder a base de datos
        private static List<Alumno> _Alumnos;








        #endregion



        public List<Alumno> GetAll()
        {
            //La línea 77 pertenecía a la implementación sin base de datos
            //return new List<Usuario>(Usuarios);

            //Instanciamos el objeto de lista para retornar
            List<Alumno> alumnos = new List<Alumno>();

            //Aca iría lo del bloque try-catch


            return alumnos;
        }


        public Alumno GetOne(int ID)
        {
            return _Alumnos.Find(delegate (Alumno a) { return a.IdAlumno == ID; });
        }

        public void Delete(int ID)
        {
            _Alumnos.Remove(this.GetOne(ID));
        }


        public void Save(Alumno alumno)
        {
            if (alumno.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Alumno usr in  _Alumnos)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                alumno.ID = NextID + 1;
                _Alumnos.Add(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                _Alumnos[_Alumnos.FindIndex(delegate (Alumno a) { return a.IdAlumno == alumno.IdAlumno; })] = alumno;
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }





    }
}
