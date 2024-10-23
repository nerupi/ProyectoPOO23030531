using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO23030531.Clases
{
    internal class Clregiones
    {
        private int RegionID;
        private String RegionDescription;
        
        public Clregiones()
        {

        }

        public Clregiones(int regionID, string regionDescription)
        {
            RegionID = regionID;
            RegionDescription = regionDescription;
        }

        public string buscarTodos()
        {
            return ("Select * from Region");
        }
        public Clregiones(int regionID)
        {
            //Busquedas individuales
            this.RegionID = regionID;
        }
    }
}
