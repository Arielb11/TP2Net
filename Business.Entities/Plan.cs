using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan
    {
        string descripcion;
        int idEspecialidad;

        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }

        public int IdEspecialidad
        {
            set { this.idEspecialidad = value; }
            get { return this.idEspecialidad; }
        }





    }
}
