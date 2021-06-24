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


        //Por el momento quedan vacíos
        Comision comision;
        Plan plan;

        public BusinessEntity()
        {
            this._State = States.New;
        }


        private int _ID;
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private States _State;

        public States State
        {
            get { return _State; }
            set { _State = value; }
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
