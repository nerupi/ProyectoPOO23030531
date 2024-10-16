using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO23030531.Clases
{
    internal class clcategorías
    {
        private int CategoryID;
        private String CategoryName;
        private String Description;
        private byte[] Picture;

        public clcategorías() 
        { 
            // mostrar todos los datos de la tabla
        }

        public clcategorías(int categoryID) 
        { 
            // mostrar un solo registro por categoría id
            this.CategoryID = categoryID;
        }

        public clcategorías(int categoryID, string categoryName, string description, byte[] picture)
        {
            // grabar un registro nuevo o modificar los datos del registro existente
            CategoryID = categoryID;
            CategoryName = categoryName;
            Description = description;
            Picture = picture;
        }
        // procedimientos

        // grabar

        // buscar individualmente
        public String buscarIndividual() 
        { 
            return ("Select * from Categories where CategoryID = '" + this.CategoryID +"'"); 
        
        } 
        // buscar todos
        public string buscarTodos()
        {
            return ("Select * from categories");
        }
        // modificar

        // eliminar

    }
}
