using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic
    {
        EspecialidadAdapter especialidadData;


        public EspecialidadLogic()
        {
            especialidadData = new EspecialidadAdapter();
        }

        /*
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = especialidadData.GetAll();
            return especialidades;
        }
        */
        /*
        public void Save(Especialidad especialidad)
        {
            especialidadData.Save(especialidad);
        }
        */
    }
}
