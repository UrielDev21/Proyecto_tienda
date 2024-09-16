using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acceso_datos; 

namespace Controller
{
    public class Manejador_productos
    {
        /*Creamos el objeto para que se puedan usar los metodos 
        y hacer los Query en la base de datos*/
        Funciones f = new Funciones();

        //Metodo para guardar en la base de datos
        public void Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"call p_insertar_productos('{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
