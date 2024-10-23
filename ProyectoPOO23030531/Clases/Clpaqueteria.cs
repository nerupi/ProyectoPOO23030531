using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO23030531.Clases
{
    internal class Clpaqueteria
    {
        private int ShipperID;
        private string CompanyName;
        private string Phone;

        public string CompanyName1 { get => CompanyName; set => CompanyName = value; }
        public string Phone1 { get => Phone; set => Phone = value; }

        public Clpaqueteria(int shipperID, string companyName, string phone)
        {
            ShipperID = shipperID;
            CompanyName = companyName;
            Phone = phone;
        }
        public Clpaqueteria()
        {

        }

        public Clpaqueteria(int shipperID)
        {
            ShipperID = shipperID;
        }

        public Clpaqueteria(string companyName, string phone)
        {
            CompanyName = companyName;
            Phone = phone;
        }

        public string buscarTodos()
        {
            return ("Select * from Shippers");
        }

        public string grabar()
        {
            string sp = "sp_graba_paqueteria";
            return (sp);
        }

        public string consultari()
        {
            return ("select * from shippers where shipperid = '" + this.ShipperID + "'");
        }
    }
  
}
