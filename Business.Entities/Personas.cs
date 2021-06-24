using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Personas: BusinessEntity
    {
        string apellido;
        string nombre;
        string direccion;
        string email;
        string telefono;
        int idPlan;
        int legajo;
        DateTime fechaNacimiento;
        //TiposPersonas tipoPersona;

        public string Apellido
        {
            set { this.apellido = value; }
            get { return this.apellido; }
        }

        public string Nombre
        {
            set { this.nombre = value; }
            get { return this.nombre; }
        }

        public string Direccion
        {
            set { this.direccion = value; }
            get { return this.direccion; }
        }

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public string Telefono
        {
            set { this.telefono = value; }
            get { return this.telefono; }
        }

        public int IdPlan
        {
            set { this.idPlan = value; }
            get { return this.idPlan; }
        }

        public int Legajo
        {
            set { this.legajo = value; }
            get { return this.legajo; }
        }

        public DateTime FechaNacimiento
        {
            set { this.fechaNacimiento = value; }
            get { return this.fechaNacimiento; }
        }



    }
}
