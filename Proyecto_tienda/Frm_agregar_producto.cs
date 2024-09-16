using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_tienda
{
    public partial class Frm_agregar_producto : Form
    {
        //Creamos el objeto del manejador
        Manejador_productos mp;

        //Variables para las columnas y filas de la tabla
        int fila = 0, columna = 0;

        //Variables publicas estaticas para usar en otro formulario
        public static int id_producto = 0;
        public static string nombre = "", descripcion = "";
        public static double precio = 0;

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvProductos.Visible = true;
            mp.MostrarProductos(dtgvProductos, txtBuscar.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            id_producto = 0; nombre = ""; descripcion = ""; precio = 0;
            dtgvProductos.Visible = false;
            Frm_vista_productos frap = new Frm_vista_productos();
            frap.ShowDialog();
            txtBuscar.Focus();
        }

        public Frm_agregar_producto()
        {
            InitializeComponent();
            mp = new Manejador_productos();
        }

        private void dtgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;

            switch (columna)
            {
                case 4:
                    {
                        id_producto = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
                        descripcion = dtgvProductos.Rows[fila].Cells[2].Value.ToString();
                        precio = double.Parse(dtgvProductos.Rows[fila].Cells[3].Value.ToString());
                        Frm_vista_productos frap = new Frm_vista_productos();
                        frap.ShowDialog();
                        dtgvProductos.Visible = false;
                    }
                    break;
                case 5:
                    {
                        id_producto = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        mp.Eliminar(id_producto, dtgvProductos.Rows[fila].Cells[1].Value.ToString());
                        dtgvProductos.Visible = false;
                    }
                    break;
            }
        }
    }
}
