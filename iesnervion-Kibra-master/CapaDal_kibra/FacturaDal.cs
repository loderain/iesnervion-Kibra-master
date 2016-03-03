using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
    CREATE TABLE facturas(
	    idFactura INT IDENTITY NOT NULL,
	    fechaGenerada DATE not null,
	    ordenVenta INT not null,
	    CONSTRAINT PK_Factura PRIMARY KEY (idFactura),
	    CONSTRAINT FK_OrdenesVentas_Facturas FOREIGN KEY (ordenventa) REFERENCES OrdenesVentas (idOrdenVenta)	
    )
*/
namespace CapaDal_kibra
{
    class FacturaDal
    {
        public List<Factura> getListaFacturas()
        {
            // Obtener todas las facturas de la BD
            List<Factura> listaFacturas = new List<Factura>();

            DataBaseHelper helper = new DataBaseHelper();
            SqlCommand comando = new SqlCommand("SELECT idFactura, fechaGenerada, ordenVenta FROM Facturas");

            DataTable datos = helper.getDatos(comando);
            foreach (DataRow row in datos.Rows)
            {
                SqlCommand comandoVenta = new SqlCommand("SELECT idOrdenVenta, fecha, empleado, cliente FROM OrdenesVentas WHERE idOrdenVenta = @idVenta");
                OrdenVenta ordenVentaRow = new OrdenVenta();
                Factura fctr = new Factura(Convert.ToInt32(row[0]),Convert.ToDateTime(row[1]), ordenVentaRow);
            }
            return null;
        }

        public Factura getFacturaPorVenta(DetalleVenta detalleVenta) {
            return null;
        }
    }
}
