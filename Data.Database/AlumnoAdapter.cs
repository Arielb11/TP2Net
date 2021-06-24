using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    class AlumnoAdapter:Adapter
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

    }
}
