using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Esta clase contendrá los elementos básicos que compartirán las entidades de
nuestro sistema y luego heredarán de ella.*/

/*Permite transferir información entre
capas y mantener la comunicación entre ellas minimizando el
acoplamiento y sobre la capa inmediata inferior.*/



namespace Business.Entities
{
    public class BusinessEntity
    {

        public BusinessEntity()
        {
            this.state = States.New;
        }


        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private States state;

        public States State
        {
            get { return state; }
            set { state = value; }
        }


        public enum States
        {
            Deleted, 
            New, 
            Modified,
            Unmodified
        }


    }
}
