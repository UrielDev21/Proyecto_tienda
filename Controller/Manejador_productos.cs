using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void Modificar(int Id_producto, TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Modificar($"call p_modificar_productos({Id_producto}, '{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Metodo para poder agregar botones al datagridview
        DataGridViewButtonColumn Boton(string texto, Color fondo)
        {
            DataGridViewButtonColumn b = new DataGridViewButtonColumn();
            b.Text = texto;
            b.UseColumnTextForButtonValue = true;
            b.FlatStyle = FlatStyle.Popup;
            b.DefaultCellStyle.BackColor = fondo;
            b.DefaultCellStyle.ForeColor = Color.White;
            return b;
        }
        public void MostrarProductos(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from producto where nombre like '%{filtro}%'", "producto").Tables[0];
            tabla.Columns.Add(Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
