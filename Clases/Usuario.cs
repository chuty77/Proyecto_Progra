using Proyecto_Progra.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Progra.Clases
{
    public class Usuario
    {
          public int ID_USUARIO { get; set; }
            public string NOMBRE { get; set; }
            public string APELLIDOS { get; set; }
            public string CONTRASENA { get; set; }
            public string DIRECCION { get; set; }
            public string TELEFONO { get; set; }
            public string EMAIL { get; set; }


        Proyecto_FinalEntities1 db = new Proyecto_FinalEntities1();
         public bool Autententicar()
        {
            return db.USUARIO.Where(u => u.EMAIL == this.EMAIL
            && u.CONTRASENA == this.CONTRASENA)
            .FirstOrDefault() != null;

        }
    }
    
}
