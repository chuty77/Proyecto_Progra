using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Proyecto_Progra.Models;

namespace Proyecto_Progra.Clase
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        [StringLength(6, ErrorMessage = "El carnet debe ser maximo de 6 caracteres ")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo letras de la A a la Z")]
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string CONTRASENA { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        [DisplayName("Direccion de Correo")]
        [StringLength(50, ErrorMessage = "El email no debe ser mayor a  50 letras")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EMAIL { get; set; }

        Proyecto_FinalEntities2 db = new Proyecto_FinalEntities2();


            public bool Autententicar()
        {
            return db.USUARIO.Where(u => u.EMAIL == this.EMAIL 
            && u.CONTRASENA == this.CONTRASENA)
            .FirstOrDefault() != null;
                   
        }

        public IEnumerable<USUARIO> Consultar()

        {
            return db.USUARIO.ToList();
        
        }

        public void Guardar(USUARIO modelo)
        {
            db.USUARIO.Add(modelo);
            db.SaveChanges();
        }

        public void Modificar(USUARIO modelo)
        {
            
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            
        }

        /* Consulta si existe un empleado con ese ID */

        public USUARIO Consultar(int id)
        {
          
                return db.USUARIO.FirstOrDefault(e => e.ID_USUARIO == id);
            

        }

        /* Eliminad un empleado dado un ID */

        public void Eliminar(USUARIO modelo)
        {
            
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            

        }

    }
}



   