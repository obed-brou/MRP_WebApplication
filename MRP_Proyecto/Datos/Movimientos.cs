using MRP_Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Datos
{
    public class Movimientos:Conexion
    {
        public void Crear_Usuario(Usuario_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Usuario", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Usuario", modelo.Usuario));
                comando.Parameters.Add(new SqlParameter("@Password", modelo.Password));
                comando.Parameters.Add(new SqlParameter("@Tipo", modelo.Tipo));
                comando.Parameters.Add(new SqlParameter("@Nombre", modelo.Nombre));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally 
            {
                Desconectar();
            }
        }

        public void Crear_Proveedor(Proveedor_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Proveedor", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Nombre", modelo.Nombre));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_Producto(Producto_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Producto", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Tipo_Producto", modelo.Tipo_Producto));
                comando.Parameters.Add(new SqlParameter("@Descripcion", modelo.Descripcion));
                comando.Parameters.Add(new SqlParameter("@IdProveedor", modelo.IdProveedor));
                comando.Parameters.Add(new SqlParameter("@TiempoEspera", modelo.TiempoEspera));
                comando.Parameters.Add(new SqlParameter("@UnidadMedida", modelo.UnidadMedida));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_Lista(Lista_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Lista", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Nombre_Lista", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@Comentario", modelo.Comentario));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_ListaDetalle(ListaDetalle_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_ListaDetalle", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdLista", modelo.IdLista));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@Precio", modelo.Precio));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }


        public void Agregar_Inventario(Inventario_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Inventario", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@Fecha", modelo.Fecha));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }


        public void Agregar_InventarioDetalle(InventarioDetalle_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_InventarioDetalle", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdInventario", modelo.IdInventario));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@Descripcion", modelo.Descripcion));
                comando.Parameters.Add(new SqlParameter("@Tipo_Producto", modelo.Tipo_Producto));
                comando.Parameters.Add(new SqlParameter("@InvInicial", modelo.InvInicial));
                comando.Parameters.Add(new SqlParameter("@InvFinal", modelo.InvFinal));
                comando.Parameters.Add(new SqlParameter("@Mermas", modelo.Mermas));
                comando.Parameters.Add(new SqlParameter("@MotivoMermas", modelo.MotivoMermas));
                comando.Parameters.Add(new SqlParameter("@Ultimo_Surtido", modelo.Fecha_Ultimo_Surtido));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_Cliente(Cliente_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Cliente", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdCliente", modelo.IdCliente));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@IdLista", modelo.IdLista));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_Pedido(Pedido_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Pedido", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@IdCliente", modelo.IdCliente));
                comando.Parameters.Add(new SqlParameter("@Fecha", modelo.Fecha));
                comando.Parameters.Add(new SqlParameter("@EstadoPedido", modelo.EstadoPedido));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_PedidoDetalle(PedidoDetalle_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_PedidoDetalle", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdPedido", modelo.IdPedido));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@Descripcion", modelo.Descripcion));
                comando.Parameters.Add(new SqlParameter("@Cantidad", modelo.Cantidad));
                comando.Parameters.Add(new SqlParameter("@UnidadMedida", modelo.UnidadMedida));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_Receta(Receta_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_Recetas", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@NombreReceta", modelo.NombreReceta));
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@Descripcion", modelo.Descripcion));
                comando.Parameters.Add(new SqlParameter("@TiempoFabricacion_dias", modelo.TiempoFabricacion_dias));
                comando.Parameters.Add(new SqlParameter("@Cantidad", modelo.Cantidad));
                comando.Parameters.Add(new SqlParameter("@UnidadMedida", modelo.UnidadMedida));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Agregar_InsumosRecetas(InsumosRecetas_Model modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Guardar_InsumosRecetas", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@IdReceta", modelo.IdReceta));
                comando.Parameters.Add(new SqlParameter("@IdUsuario", modelo.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@Codigo", modelo.Codigo));
                comando.Parameters.Add(new SqlParameter("@Descripcion", modelo.Descripcion));
                comando.Parameters.Add(new SqlParameter("@Cantidad", modelo.Cantidad));
                comando.Parameters.Add(new SqlParameter("@UnidadMedida", modelo.UnidadMedida));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}