using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumno : BusinessEntity
    {
        string condicion;
        int idAlumno;
        int idCurso;
        int nota;


        public string Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public int IdCurso
        {
            get { return idCurso; }
            set { idCurso = value; }
        }

        public int Nota
        {
            get { return nota; }
            set { nota = value; }
        }


    }
}
