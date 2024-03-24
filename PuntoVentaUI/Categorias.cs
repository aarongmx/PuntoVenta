using PuntoVentaUI.data;
using PuntoVentaUI.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaUI
{
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            try
            {
                List<CategoriasModels> categorias = listadoCategorias();
                LlenarGridView(categorias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<CategoriasModels> listadoCategorias()
        {
            DaoCategorias dao = new DaoCategorias();
            List<CategoriasModels> listaCategorias = dao.ObtenerCategorias();
            return listaCategorias;
        }

        private void LlenarGridView(List<CategoriasModels> listaCategorias)
        {
            if (listaCategorias != null)
            {
                dataCategorias.DataSource = listaCategorias;
            }
        }
    }
}
