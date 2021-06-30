using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class EspecialidadAdapter
    {

        /*
        private static List<Especialidad> _Especialidades;

        private static List<Especialidad> Especialidad
        {
            get { return _Especialidades; }
        }



        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            return especialidades;
        }

        

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Especialidad esp in Especialidad)
                {
                    if (esp.ID > NextID)
                    {
                        NextID = esp.ID;
                    }
                }
                especialidad.ID = NextID + 1;
                Especialidad.Add(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                Especialidad[Especialidad.FindIndex(delegate (Especialidad e) { return u.ID == especialidad.ID; })] = especialidad;
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }


        public void Delete(int ID)
        {
            Especialidad.Remove(this.GetOne(ID));
        }




        public Especialidad GetOne(int ID)
        {
            return Especialidad.Find(delegate (Especialidad e) { return e.ID == ID; });
        }
        */

    }
}
