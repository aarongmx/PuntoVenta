using CorePuntoVenta.Domain.Productos.Models;
using Dapper;
using Npgsql;
using PuntoVentaUI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaUI.data
{
    public class DaoCategorias
    {
        private string connectionString = "Server=localhost;Port=5432;User ID=postgres;Password=admin;Database=punto";

        public List<CategoriasModels> ObtenerCategorias()
        {
            using (var conexion = new NpgsqlConnection(connectionString))
            {
                return conexion.Query<CategoriasModels>("SELECT * FROM categorias").ToList();
            }
        }
    }
}
