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

        //Método que crea una lista de especialidades, y la devuelve
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = especialidadData.GetAll();
            return especialidades;
        }


        //Método que recibe como parámetro un id, y que devuelve un usuario.
        public Especialidad GetOne(int id)
        {
            Especialidad esp = especialidadData.GetOne(id);
            return esp;
        }

        //Método que recibe como parámetro una especialidad, y lo guarda en la base de datos
        public void Save(Especialidad especialidad)
        {
            especialidadData.Save(especialidad);
        }


        //Método que recibe como parámetro un id, y que elimina a un usuario
        public void Delete(int id)
        {
            especialidadData.Delete(id);
        }

    }
}
