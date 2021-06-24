using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso:BusinessEntity
    {
        int anioCalendario;
        int cupo;
        int idComision;
        int idMateria;
        string descripcion;

        public int AnioCalendario
        {
            set { this.anioCalendario = value; }
            get { return this.anioCalendario; }
        }

        public int Cupo
        {
            set { this.cupo = value; }
            get { return this.cupo; }
        }

        public int IdComision
        {
            set { this.idComision = value; }
            get { return this.idComision; }
        }

        public int IdMateria
        {
            set { this.idMateria = value; }
            get { return this.idMateria; }
        }

        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }


    }
}
