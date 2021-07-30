using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        string descripcion;
        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }



    }
}
