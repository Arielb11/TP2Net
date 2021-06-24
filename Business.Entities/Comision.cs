using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision
    {
        int anioEspecialidad;
        int idPlan;
        string descripcion;

        public int AnioEspecialidad
        {
            set { this.anioEspecialidad = value; }
            get { return this.anioEspecialidad; }
        }

        public int IdPlan
        {
            set { this.idPlan = value; }
            get { return this.idPlan; }
        }

        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }


    }
}
