using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia: BusinessEntity
    {
        string descripcion;
        int horasSemanales;
        int horasTotales;
        int idPlan;


        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }

        public int HorasSemanales
        {
            set { this.horasSemanales = value; }
            get { return this.horasSemanales; }
        }

        public int HorasTotales
        {
            set { this.horasTotales = value; }
            get { return this.horasTotales; }
        }

        public int IdPlan
        {
            set { this.idPlan = value; }
            get { return this.idPlan; }
        }

    }
}
