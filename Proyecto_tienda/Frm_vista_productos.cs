using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller; 

namespace Proyecto_tienda
{
    public partial class Frm_vista_productos : Form
    {
        //Creamos el objeto del manejador para poder usar los metodos
        Manejador_productos mp; 
        public Frm_vista_productos()
        {
            InitializeComponent();
            mp = new Manejador_productos();
            if (Frm_agregar_producto.id_producto > 0)
            {
                txtNombre.Text = Frm_agregar_producto.nombre;
                txtDescripcion.Text = Frm_agregar_producto.descripcion;
                txtPrecio.Text = Frm_agregar_producto.precio.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Frm_agregar_producto.id_producto > 0)
            {
                mp.Modificar(Frm_agregar_producto.id_producto, txtNombre, txtDescripcion, txtPrecio);
            }
            else
            {
                mp.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
