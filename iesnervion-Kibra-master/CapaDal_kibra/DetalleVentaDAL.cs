using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
 CREATE TABLE DetallesVentas
    (
        idDetalles INTEGER IDENTITY,
        precioUnidad MONEY NOT NULL,
        cantidad INTEGER NOT NULL,
        iva INTEGER NOT NULL,
        ordenVenta INTEGER NOT NULL,
        articulo INTEGER NOT NULL,
        CONSTRAINT PK_DetallesVentas PRIMARY KEY (idDetalles),
        CONSTRAINT FK_OrdenesVentas_Detalles FOREIGN KEY (ordenVenta) REFERENCES dbo.OrdenesVentas (idOrdenVenta),
        CONSTRAINT FK_ARTICULOS_DETALLES FOREIGN KEY (articulo) REFERENCES dbo.Articulos (idArticulo)
    )
    GO
 */
namespace CapaDal_kibra
{
    class DetalleVentaDAL
    {
        /// <summary>
        /// Función que dado un identificador devuelve los detalles de una venta
        /// </summary>
        /// <param name="idDetalleVenta">ID asociado a la venta a devolver</param>
        /// <returns>Un objeto DetalleVenta</returns>
        public DetalleVenta getDetalleVenta(int idDetalleVenta)
        {
            //Instancio el helper
            DataBaseHelper helper = new DataBaseHelper();
            //Creo la consulta y le doy valor al parámetro
            SqlCommand comando = new SqlCommand("SELECT idDetalles, precioUnidad, cantidad, iva, ordenVenta, articulo FROM DetallesVentas WHERE idDetalles = @id");
            SqlParameter parameter = new SqlParameter("@id", idDetalleVenta);
            //Usando el helper ejecuto la consulta y la almaceno en una tabla
            DataTable datos = helper.getDatos(comando);
            DataRow datosDetalleVenta = datos.Rows[0];
            //Recojo los datos de la tabla y los meto en un objeto DetalleCompra
            int idDetalles = Convert.ToInt32(datosDetalleVenta[0]);
            double precioUnidad = Convert.ToDouble(datosDetalleVenta[1]);
            int cantidad = Convert.ToInt32(datosDetalleVenta[2]);
            int iva = Convert.ToInt32(datosDetalleVenta[3]);
            OrdenVenta ordenVenta = (OrdenVenta)datosDetalleVenta[4];
            Articulo articlo = (Articulo)datosDetalleVenta[5];
            DetalleVenta detallitos = new DetalleVenta(idDetalles, precioUnidad, cantidad, iva, ordenVenta, articlo);
            return detallitos;
        }
        /*
        CREATE PROCEDURE insertarDetallesVentas (@precioUnidad MONEY, @cantidad INT, @iva INT, @ordenVenta INT, @articulo INT, @res BIT OUTPUT)
        AS
        BEGIN
	        INSERT INTO dbo.DetallesVentas (precioUnidad, cantidad, iva, ordenVenta, articulo) VALUES (@precioUnidad, @cantidad, @iva, @ordenVenta, @articulo)
	        IF(@@ROWCOUNT!=0)
	        BEGIN
		        SET @res=1
	        END
	        ELSE
	        BEGIN
		        SET @res=0
	        END
        END
        GO
         */
        /// <summary>
        /// Función que inserta un detalle de venta en la base de datos dado un objeto DetalleVenta
        /// </summary>
        /// <param name="detalleVenta">Objeto DetalleVenta a insertar</param>
        /// <returns>Un boolean que representa el éxito de la operación. True = éxito</returns>
        public Boolean insertDetalleVenta(DetalleVenta detalleVenta)
        {
            Boolean insertado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarDetallesVentas";
            SqlParameter parametro1 = new SqlParameter("@precioUnidad", detalleVenta.PrecioUnidad);
            SqlParameter parametro2 = new SqlParameter("@cantidad", detalleVenta.Cantidad);
            SqlParameter parametro3 = new SqlParameter("@iva", detalleVenta.Iva);
            SqlParameter parametro4 = new SqlParameter("@ordenVenta", detalleVenta.ordenVenta);
            SqlParameter parametro5 = new SqlParameter("@articulo", detalleVenta.Articulo);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);

            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                insertado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return insertado;
        }
        /*
        CREATE PROCEDURE actualizarDetallesVentas (@idDetalles INT, @precioUnidad MONEY, @cantidad INT, @iva INT, @ordenVenta INT, @articulo INT, @res BIT OUTPUT)
        AS
        BEGIN
	        UPDATE dbo.DetallesVentas SET precioUnidad=@precioUnidad, cantidad=@cantidad, iva=@iva, ordenVenta=@ordenVenta, articulo=@articulo WHERE idDetalles=@idDetalles
	        IF(@@ROWCOUNT!=0)
	        BEGIN
		        SET @res=1
	        END ELSE
	        BEGIN
		        SET @res=0
	        END
        END
        GO
         */
        /// <summary>
        /// Función que actualiza un detalle de venta en la base de datos
        /// </summary>
        /// <param name="detalleVenta">El objeto a actualizar en la base de datos</param>
        /// <returns>Devuelve un boolean con valor true si la operación ha sido exitosa</returns>
        public Boolean updateDetalleVenta(DetalleVenta detalleVenta)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "actualizarDetallesVentas";
            SqlParameter parametro1 = new SqlParameter("@idDetalles", detalleVenta.IdDetalles);
            SqlParameter parametro2 = new SqlParameter("@precioUnidad", detalleVenta.PrecioUnidad);
            SqlParameter parametro3 = new SqlParameter("@cantidad", detalleVenta.Cantidad);
            SqlParameter parametro4 = new SqlParameter("@iva", detalleVenta.Iva);
            SqlParameter parametro5 = new SqlParameter("@ordenVenta", detalleVenta.ordenVenta);
            SqlParameter parametro6 = new SqlParameter("@articulo", detalleVenta.Articulo);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.Parameters.Add(parametro5);
            comando.Parameters.Add(parametro6);

            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                actualizado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return actualizado;
        }
        /*
        CREATE PROCEDURE eliminarDetallesVentas (@idDetalles INT, @res BIT OUTPUT)
        AS
        BEGIN
	        DELETE FROM dbo.DetallesVentas WHERE idDetalles=@idDetalles
	        IF(@@ROWCOUNT!=0)
	        BEGIN
		        SET @res=1
	        END ELSE
	        BEGIN
		        SET @res=0
	        END
        END
        GO
         */
        /// <summary>
        /// Función que elimina un detalle de venta de la base de datos
        /// </summary>
        /// <param name="detalleVenta">Un objeto tipo DetalleVenta</param>
        /// <returns>Devuelve un boolean con valor true si la operación ha sido exitosa</returns>
        public Boolean deleteDetalleVenta(DetalleVenta detalleVenta)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarDetallesVentas";
            SqlParameter parametro1 = new SqlParameter("@idDetalles", detalleVenta.IdDetalles);

            comando.Parameters.Add(parametro1);

            DataBaseHelper helper = new DataBaseHelper();
            try
            {
                eliminado = helper.executeStoredProcedure(comando);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return eliminado;
        }
    }
}
