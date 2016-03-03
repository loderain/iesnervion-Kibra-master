using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
/*
CREATE TABLE DetallesCompras
(
	idDetalles INTEGER IDENTITY,
	precioUnidad MONEY NOT NULL,
	cantidad INTEGER NOT NULL,
	iva INTEGER NOT NULL,
	ordenCompra INTEGER NOT NULL,
	articulo INTEGER NOT NULL,
	CONSTRAINT PK_DetallesCompras PRIMARY KEY (idDetalles),
	CONSTRAINT FK_OrdenesCompras_Detalles FOREIGN KEY (ordenCompra) REFERENCES dbo.OrdenesCompras (idOrdenCompra),
	CONSTRAINT FK_ARTICULOS_DETALLESC FOREIGN KEY (articulo) REFERENCES dbo.Articulos (idArticulo)
)
GOGOGOGOGOGOGOGOGOGOGO
 */
namespace CapaDal_kibra
{
    class DetalleCompraDAL
    {
        /// <summary>
        /// Función que dado un identificador devuelve los detalles de una compra
        /// </summary>
        /// <param name="idDetalleCompra">ID asociado a la compra a devolver</param>
        /// <returns>Un objeto DetalleCompra</returns>
        public DetalleCompra getDetalleCompra(int idDetalleCompra)
        {
            //Instancio el helper
            DataBaseHelper helper = new DataBaseHelper();
            //Creo la consulta y le doy valor al parámetro
            SqlCommand comando = new SqlCommand("SELECT idDetalles, precioUnidad, cantidad, iva, ordenCompra, articulo FROM DetallesCompras WHERE idDetalles = @id");
            SqlParameter parameter = new SqlParameter("@id", idDetalleCompra);
            //Usando el helper ejecuto la consulta y la almaceno en una tabla
            DataTable datos = helper.getDatos(comando);
            DataRow datosDetalleCompra = datos.Rows[0];
            //Recojo los datos de la tabla y los meto en un objeto DetalleCompra
            int idDetalles = Convert.ToInt32(datosDetalleCompra[0]);
            double precioUnidad = Convert.ToDouble(datosDetalleCompra[1]);
            int cantidad = Convert.ToInt32(datosDetalleCompra[2]);
            int iva = Convert.ToInt32(datosDetalleCompra[3]);
            OrdenCompra ordenCompra = (OrdenCompra) datosDetalleCompra[4];
            Articulo articlo = (Articulo) datosDetalleCompra[5];
            DetalleCompra detallitos = new DetalleCompra(idDetalles, precioUnidad, cantidad, iva, ordenCompra, articlo);
            return detallitos;
        }
        /*
         CREATE PROCEDURE insertarDetallesCompras (@precioUnidad MONEY, @cantidad INT, @iva INT, @ordenCompra INT, @articulo INT, @res BIT OUTPUT)
            AS
            BEGIN
	            INSERT INTO dbo.DetallesCompras (precioUnidad, cantidad, iva, ordenCompra, articulo) VALUES (@precioUnidad, @cantidad, @iva, @ordenCompra, @articulo)
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
        /// Función que inserta un detalle de compra en la base de datos dado un objeto DetalleCompra
        /// </summary>
        /// <param name="detalleCompra">Objeto DetalleCompra a insertar</param>
        /// <returns>Un boolean que representa el éxito de la operación. True = éxito</returns>
        public Boolean insertDetalleCompra(DetalleCompra detalleCompra)
        {
            Boolean insertado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "insertarDetallesCompras";
            SqlParameter parametro1 = new SqlParameter("@precioUnidad", detalleCompra.PrecioUnidad);
            SqlParameter parametro2 = new SqlParameter("@cantidad", detalleCompra.Cantidad);
            SqlParameter parametro3 = new SqlParameter("@iva", detalleCompra.Iva);
            SqlParameter parametro4 = new SqlParameter("@ordenCompra", detalleCompra.OrdenCompra);
            SqlParameter parametro5 = new SqlParameter("@articulo", detalleCompra.Articulo);

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
         CREATE PROCEDURE actualizarDetallesCompras (@idDetalles INT, @precioUnidad MONEY, @cantidad INT, @iva INT, @ordenCompra INT, @articulo INT, @res BIT OUTPUT)
            AS
            BEGIN
	            UPDATE dbo.DetallesCompras SET precioUnidad=@precioUnidad, cantidad=@cantidad, iva=@iva, ordenCompra=@ordenCompra, articulo=@articulo WHERE idDetalles=@idDetalles
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
        /// Función que actualiza un detalle de compra en la base de datos
        /// </summary>
        /// <param name="detalleCompra">El objeto a actualizar en la base de datos</param>
        /// <returns>Devuelve un boolean con valor true si la operación ha sido exitosa</returns>
        public Boolean updateDetalleCompra(DetalleCompra detalleCompra)
        {
            Boolean actualizado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "actualizarDetallesCompras";
            SqlParameter parametro1 = new SqlParameter("@idDetalles", detalleCompra.IdDetalles);
            SqlParameter parametro2 = new SqlParameter("@precioUnidad", detalleCompra.PrecioUnidad);
            SqlParameter parametro3 = new SqlParameter("@cantidad", detalleCompra.Cantidad);
            SqlParameter parametro4 = new SqlParameter("@iva", detalleCompra.Iva);
            SqlParameter parametro5 = new SqlParameter("@ordenCompra", detalleCompra.OrdenCompra);
            SqlParameter parametro6 = new SqlParameter("@articulo", detalleCompra.Articulo);

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
         CREATE PROCEDURE eliminarDetallesCompras (@idDetalles INT, @res BIT OUTPUT)
            AS
            BEGIN
	            DELETE FROM dbo.DetallesCompras WHERE idDetalles=@idDetalles
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
        /// Función que elimina un detalle de compra de la base de datos
        /// </summary>
        /// <param name="idDetalleCompra"></param>
        /// <returns>Devuelve un boolean con valor true si la operación ha sido exitosa</returns>
        public Boolean deleteDetalleCompra(DetalleCompra detalleCompra)
        {
            Boolean eliminado = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "eliminarDetallesCompras";
            SqlParameter parametro1 = new SqlParameter("@idDetalles", detalleCompra.IdDetalles);

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
