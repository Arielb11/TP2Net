using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {


        //TipoCargo tipoCargo;
        int idCurso;
        int idDocente;

        public int IdCurso
        {
            set { this.idCurso = value; }
            get { return this.idCurso; }
        }

        public int IdDocente
        {
            set { this.idDocente = value; }
            get { return this.idDocente; }
        }


    }
}
