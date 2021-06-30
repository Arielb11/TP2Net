using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class AlumnoLogic: BusinessLogic
    {
        AlumnoAdapter alumnoData;


        public AlumnoLogic()
        {
            alumnoData = new AlumnoAdapter();
        }

        
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = alumnoData.GetAll();
            return alumnos;
        }

        public Alumno GetOne(int id)
        {
            Alumno alumno = alumnoData.GetOne(id);
            return alumno;
        }

        public void Save(Alumno alumno)
        {
            alumnoData.Save(alumno);
        }




    }
}
