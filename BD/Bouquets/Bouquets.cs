
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Natuflora.BD.Bouquets
{
    /// <summary>
    /// 
    /// </summary>
    public class BDBouquets : BD
    {
        
        //log
        //protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BDBouquetera));

        public BDBouquets()
        {

        }

        #region PO

            public DataSet ConsultarCostomer()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("na_consultar_cliente_despacho", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@orden ", SqlDbType.Char);
                sqlParam.Value = "idc_cliente_despacho";
                

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

            public DataSet ConsultarCliente()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("na_editar_transportador_por_cliente_despacho", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion ", SqlDbType.Char);
                sqlParam.Value = "consultar_cliente";
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }
            public DataSet ConsultarTranportadorXCLiente(int idCliente)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("na_editar_transportador_por_cliente_despacho", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion ", SqlDbType.Char);
                sqlParam.Value = "consultar_transportador";
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value = idCliente;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

            public DataSet ConsultarCarrier()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("na_editar_transportador", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion ", SqlDbType.Char);
                sqlParam.Value = "consultar";
                sqlParam = cmd.Parameters.Add("@idc_transportador  ", SqlDbType.Char);
                sqlParam.Value = "";
                sqlParam = cmd.Parameters.Add("@nombre_transportador   ", SqlDbType.Char);
                sqlParam.Value = "";
                sqlParam = cmd.Parameters.Add("@direccion_transportador   ", SqlDbType.Char);
                sqlParam.Value = "";
                sqlParam = cmd.Parameters.Add("@cuenta_transportador   ", SqlDbType.Char);
                sqlParam.Value = "";


                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

            public DataSet ConsultarVendedor()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("na_editar_vendedor", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion ", SqlDbType.Char);
                sqlParam.Value = "consultar";
                sqlParam = cmd.Parameters.Add("@id_vendedor   ", SqlDbType.Char);
                sqlParam.Value = "";
                sqlParam = cmd.Parameters.Add("@correo   ", SqlDbType.Char);
                sqlParam.Value = "";

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

            public DataSet ConsultarPO(int idVendedor,string fecha)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_editar_po", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@id_transportador", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
                sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
                sqlParam.Value = "";
                sqlParam = cmd.Parameters.Add("@fecha_despacho_miami", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;            
                sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
                sqlParam.Value = "consultar_po";
                sqlParam = cmd.Parameters.Add("@id_vendedor ", SqlDbType.Int);
                if (idVendedor == 0)
                {
                    sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else {
                    sqlParam.Value = idVendedor; 
                }
                
                sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                
                //DateTime date = DateTime.Parse(fecha.ToString());
                sqlParam.Value = fecha;
                

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(" BD: Error: " + ex.Message);
                    //throw new Exception("Error");
                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

            public int ActualizarPO(int idPO,int idTransportador, int idDespacho, int idCuentaInterna, string poNumber, string fDespacho, string fEmision, string fDelivery, string fVuelo, int NumSol)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;
                int resultado;
                conn = new SqlConnection(strConnString);
                conn.Open();
                DataSet ds = new DataSet();


                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("bouquet_editar_po", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@id_transportador", SqlDbType.Int);
                sqlParam.Value = idTransportador;
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value = idDespacho;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = idCuentaInterna;
                sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
                sqlParam.Value = poNumber;
                sqlParam = cmd.Parameters.Add("@numero_solicitud", SqlDbType.Char);
                sqlParam.Value = NumSol;
                sqlParam = cmd.Parameters.Add("@fecha_despacho_miami", SqlDbType.DateTime);
                sqlParam.Value = fDespacho;
                if (String.IsNullOrEmpty(fEmision))
                {
                    sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                    sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                    sqlParam.Value = fEmision;
                }
                if (String.IsNullOrEmpty(fDelivery))
                {
                    sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                    sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                    sqlParam.Value = fDelivery;
                }
                
                sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
                sqlParam.Value = fVuelo;
                sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
                sqlParam.Value = idPO;
                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
                sqlParam.Value = "actualizar_po";
                sqlParam = cmd.Parameters.Add("@id_vendedor ", SqlDbType.Int);
                sqlParam.Value = sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                sqlParam.Value = System.DateTime.Today;


                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    resultado = int.Parse(dt.Rows[0][0].ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return resultado;

            }


            public int InsertarPO(int idTransportador,int idDespacho,int idCuentaInterna,string poNumber,string fDespacho,string fEmision,string fDelivery,string fVuelo, int NumSol)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;
                int resultado=0;
                conn = new SqlConnection(strConnString);
                conn.Open();
                DataSet ds = new DataSet();


                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("bouquet_editar_po", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@id_transportador", SqlDbType.Int);
                sqlParam.Value =  idDespacho; 
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value =idTransportador;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = idCuentaInterna;
                sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
                sqlParam.Value = poNumber;
                sqlParam = cmd.Parameters.Add("@numero_solicitud", SqlDbType.Int);
                sqlParam.Value = NumSol; 
                sqlParam = cmd.Parameters.Add("@fecha_despacho_miami", SqlDbType.DateTime);
                sqlParam.Value = fDespacho;
                if (String.IsNullOrEmpty(fEmision))
                {
                    sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                    sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                    sqlParam.Value = fEmision;            
                }
                if (String.IsNullOrEmpty(fDelivery))
                {
                    sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                    sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                }
                else
                {
                    sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                    sqlParam.Value = fDelivery;
                }
                


                sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
                sqlParam.Value = fVuelo;
                sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
                sqlParam.Value = sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
                sqlParam.Value = "insertar_po";
                sqlParam = cmd.Parameters.Add("@id_vendedor ", SqlDbType.Int);
                sqlParam.Value = sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                sqlParam.Value = System.DateTime.Today;
                
                
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    int colPO = dt.Columns.IndexOf("id_po");
                    try
                    {
                        resultado = int.Parse(dt.Rows[0][colPO].ToString());
                    }
                    catch (Exception ex) 
                    {
                    
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return resultado;

            }

            public int EliminarPO(int idPO)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;
                int resultado;
                conn = new SqlConnection(strConnString);
                conn.Open();
                DataSet ds = new DataSet();


                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("bouquet_editar_po", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@id_transportador", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
                sqlParam = cmd.Parameters.Add("@fecha_despacho_miami", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
                sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
                sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
                sqlParam.Value = idPO;
                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
                sqlParam.Value = "eliminar_po";
                sqlParam = cmd.Parameters.Add("@id_vendedor ", SqlDbType.Int);
                sqlParam.Value = sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                sqlParam.Value = System.DateTime.Today;


                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    resultado = int.Parse(dt.Rows[0][0].ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return resultado;

            }

            public DataSet CalcularFechaFlight(string miamiDate)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_consultar_fecha_vuelo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                sqlParam.Value = miamiDate;


                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }

        #endregion 


       #region DETALLE

        public DataSet DetallePO(int idPO, int idCuentaInterna)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;
            
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPO;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            //sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet DetallePO_anteriores(int idPO)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_po_anteriores";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPO;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarHistorial(int idDetallePO)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_detalle_po";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetallePO;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet InsertarDetalle(int idCuentainterna,
                                    int idTapa,
                                    int idPo, 
                                    int cantidadPiezas,
                                    string marca, 
                                    bool ethyblockSachet,
                                    //decimal precioMiamiPieza,
                                    int idFarm,
                                    int idVariedadFlor,
                                    int idGradoFlor,
                                    byte[] image,
                                    int idCaja, 
                                    //int idCapuchonCultivo, 
                                    //string unidades,
                                    //int comida,
                                    string fechaVuelo,
                                    string itemNumber,
                                    int detalleAnterior)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;            
            
            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            int ethy = 0;
            if (ethyblockSachet == true) { ethy = 1; }

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "Insertar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedadFlor;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGradoFlor;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPo;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentainterna;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = idTapa;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            if (image == null) 
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            
            } 
            else 
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = image;            
            }
            
                sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
           

            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = cantidadPiezas;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = marca;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = ethy;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            if (fechaVuelo == "") { sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null; }
            else 
            {
                sqlParam.Value = fechaVuelo;
            }
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@numero_item", SqlDbType.Char);
            sqlParam.Value = itemNumber;
            sqlParam = cmd.Parameters.Add("@id_detalle_po_anterior", SqlDbType.Int);
            if (detalleAnterior == 0)
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else 
            {
                sqlParam.Value = detalleAnterior;
            }
            

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }
        
        public DataSet InsertarDetalle_fecha(int idCuentainterna,
                                    int idTapa,
                                    int idPo,
                                    int cantidadPiezas,
                                    string marca,
                                    bool ethyblockSachet,
                                    //decimal precioMiamiPieza,
                                    int idFarm,
                                    int idVariedadFlor,
                                    int idGradoFlor,
                                    byte[] image,
                                    int idCaja,
                                    //int idCapuchonCultivo,
                                    //string unidades,
                                    //int comida,
                                    string fechaVuelo,
                                    string itemNumber,
                                    int idDetalle,
                                    string valorUpc,
                                    string idUpc)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            int ethy = 0;
            if (ethyblockSachet == true) { ethy = 1; }

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "copiar_detalle_po";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedadFlor;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGradoFlor;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPo;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetalle;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentainterna;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = idTapa;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            if (image == null)
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo

            }
            else
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = image;
            }
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
           

            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = cantidadPiezas;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = marca;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = ethy;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value =idUpc;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = valorUpc;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@numero_item", SqlDbType.Char);
            sqlParam.Value = itemNumber;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }
        public DataSet InsertarUPC( int idDetallePo, string valorUpc, int ordenUpc, string idUpc)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_upc";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetallePo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = idUpc;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = ordenUpc;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = valorUpc;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }

        public DataSet ActualizarDetalle(int idDetallePo,
                                    int idCuentainterna,
                                    int idTapa,
                                    int idPo,
                                    int cantidadPiezas,
                                    string marca,
                                    bool ethyblockSachet,
                                    //decimal precioMiamiPieza,
                                    int idFarm,
                                    int idVariedadFlor,
                                    int idGradoFlor,
                                    byte[] image,
                                    int idCaja,
                                    //int idCapuchonCultivo,
                                    //string unidades,
                                    //int comida,
                                    string fechaVuelo,
                                    string itemNumber)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            int ethy = 0;
            if (ethyblockSachet == true) { ethy = 1; }
            
            DateTime hoy = DateTime.Today;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar_detalle_po";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedadFlor;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGradoFlor;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPo;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetallePo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentainterna;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = idTapa;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            if (image == null)
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo

            }
            else
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = image;
            }
                        
                sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = cantidadPiezas;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = marca;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = ethy;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            if (fechaVuelo == "") { sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null; }
            else
            {
                sqlParam.Value = fechaVuelo;
            }
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@numero_item", SqlDbType.Char);
            sqlParam.Value = itemNumber;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }

        public DataSet EliminarImagen(int idBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_imagen", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@id_bouquet", SqlDbType.Int);
            sqlParam.Value = idBouquet;
            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }

        public DataSet ActualizarUPC(int idDetalleVersionBouquet, string valorUpc, int ordenUpc, string idUpc)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar_upc";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = idUpc;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = ordenUpc;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = valorUpc;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return ds;

        }

        public DataSet ActualizarFarm(int idDetallePo, int idFarm, int idCuentaInterna, string fechaVuelo, int piezas)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar_finca";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetallePo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = piezas;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            if (fechaVuelo == "") { sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null; }
            else
            {
                sqlParam.Value = fechaVuelo;
            }
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet CancelarDetalle(int idDetallePo,int idCuentaInterna,string Observaciones)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "cancelar_detalle_po";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetallePo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = Observaciones;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarFarm()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_todos_farm", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@orden ", SqlDbType.Char);
            sqlParam.Value = "  ";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarLid()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_todos_tapa", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@orden ", SqlDbType.Char);
            sqlParam.Value = "  ";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarBox()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_caja_por_tipo_caja", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@id_tipo_caja", SqlDbType.Int);
            sqlParam.Value =0;
            sqlParam = cmd.Parameters.Add("@orden ", SqlDbType.Char);
            sqlParam.Value = "  ";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarComida()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_comida_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarCapuchon(int idPO)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_capuchon", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPO;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet BusquedaPO(string fechaInicial, string fechaFinal,int idPO)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@id_transportador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@fecha_despacho_miami", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_emision", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_delivery", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = idPO;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_po";
            sqlParam = cmd.Parameters.Add("@id_vendedor ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;            
            sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;

            sqlParam = cmd.Parameters.Add("@fecha_inicial", SqlDbType.DateTime);
            sqlParam.Value = fechaInicial;
            sqlParam = cmd.Parameters.Add("@fecha_final", SqlDbType.DateTime);
            sqlParam.Value = fechaFinal;




            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarFechaVuelo(int idFarm, string Fecha )
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_fecha_vuelo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            sqlParam.Value = Fecha;
            sqlParam = cmd.Parameters.Add("@id_farm ", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@accion ", SqlDbType.Char);
            sqlParam.Value = "consultar_fecha_por_finca";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet CalcularDiaVuelo(string idFarm, string Fecha)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Select dbo.calcular_dia_vuelo_mass_market(@fecha,@idc_farm)", sqlConnection);
            cmd.CommandType = CommandType.Text;
            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            sqlParam.Value = Fecha;
            sqlParam = cmd.Parameters.Add("@idc_farm ", SqlDbType.Char);
            sqlParam.Value = idFarm;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarImagen(int idVariedad, int idGrado)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_detalle_po", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_bouquet";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGrado;

            
            sqlParam = cmd.Parameters.Add("@id_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ethyblock_sachet", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlBoolean.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@id_upc", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@orden_upc", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_upc", SqlDbType.NVarChar);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

      #endregion 
        
        
        #region RECETA 

        public DataSet ConsultarTipoFlor()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_todos_tipo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@orden", SqlDbType.NVarChar, 255);
            sqlParam.Value = "nombre_tipo_flor";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarVariedad(int idTipoFlor)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_variedad_por_tipo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
            sqlParam.Value = idTipoFlor;
            sqlParam = cmd.Parameters.Add("@orden", SqlDbType.NVarChar, 255);
            sqlParam.Value = "nombre_variedad_flor";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarGrado(int idTipoFlor)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("na_consultar_grado_por_tipo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
            sqlParam.Value = idTipoFlor;
            sqlParam = cmd.Parameters.Add("@orden", SqlDbType.NVarChar, 255);
            sqlParam.Value = "nombre_grado_flor";


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet BouquetConsulatarFlor(string accion,int idTipoFlor)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = accion;

            sqlParam = cmd.Parameters.Add("@id_tipo_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = idTipoFlor;
            


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet InsertarFormula(string nombreFormulaBouquet, int idCuentaInterna, int idVersionBouquet, string especificacion, string construccion,string cadenaFormula,int opcionMenu,int unidades, decimal precio, int comida,int idDetalleVersionBouquet,int idFormatoUpc)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_formula";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = nombreFormulaBouquet;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = especificacion;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = construccion;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = cadenaFormula;
            sqlParam = cmd.Parameters.Add("@opcion_menu", SqlDbType.Int);
            sqlParam.Value = opcionMenu;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = unidades;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Decimal);
            sqlParam.Value = precio * unidades;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = comida;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            if (idDetalleVersionBouquet == 0) 
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }else 
            {
                sqlParam.Value = idDetalleVersionBouquet; 
            }

            sqlParam = cmd.Parameters.Add("@id_formato_upc", SqlDbType.Int);
            if (idFormatoUpc == 0)
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                sqlParam.Value = idFormatoUpc;
            }


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsecutivoBoquet(int idVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_numero_consecutivo";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@opcion_menu", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarRecetas(int idVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_todas_recetas";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarFormula(int idDetalleVersion)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_formula";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersion;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        
        public DataSet EliminarSustitucion(int idDetalleFormulaBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "eliminar_sustitucion";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleFormulaBouquet;
            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet EliminarReceta(int idDetalleVersion)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "eliminar_receta";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersion;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet VariedadSinFormula(int idGrado)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_variedad_sin_formula";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idGrado;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;
        }

        public DataSet ConsultarDetalleFormula_3(int idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_detalle_formula_opcion3";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarDetalleFormula_2(int idVersionBouquet,int idCuentaInterna)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_favoritos";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet InsertarObservacion(int idVariedad,int idGrado,int cantidadTallos,int idFormulaBouquet,string Observacion,int VariedadSustitucion,int GradoSustitucion, int idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar_restriccion_detalle_formula";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = idFormulaBouquet;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idGrado;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = cantidadTallos;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            if (Observacion != "")
            {
                sqlParam.Value = Observacion;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }
            
            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null; 
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo_sustitucion", SqlDbType.Int);
            if (VariedadSustitucion != -1)
            {
                sqlParam.Value = VariedadSustitucion;
            }
            else 
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }  
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo_sustitucion", SqlDbType.Int);
            if (GradoSustitucion != -1)
            {
                sqlParam.Value = GradoSustitucion;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarSleeve()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Consultar";
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_formula_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultargvSleeve(int idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_capuchon_formula_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet InsertarSleeve(int idCapuchonCultivo,int idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "insertar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = idCapuchonCultivo ;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_capuchon_formula_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet EliminarSleeve(int idcapuchonformula, int idDetalle)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "eliminar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo ", SqlDbType.Int);
            sqlParam.Value = idcapuchonformula;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = idDetalle;
            sqlParam = cmd.Parameters.Add("@id_capuchon_formula_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarSticker()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Consultar";
            sqlParam = cmd.Parameters.Add("@id_sticker  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_sticker_bouquet  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultargvSticker(int idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_sticker  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet  ", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_sticker_bouquet  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet InsertarSticker(int idDetalleVersionBouquet,int IdSticker)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "insertar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_sticker  ", SqlDbType.Int);
            sqlParam.Value = IdSticker;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@id_sticker_bouquet  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet EliminarSticker(int idstickerbouquet, int idDetalle)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "eliminar_asignacion";
            sqlParam = cmd.Parameters.Add("@id_sticker  ", SqlDbType.Int);
            sqlParam.Value = idstickerbouquet;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalle;
            sqlParam = cmd.Parameters.Add("@id_sticker_bouquet  ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarRecetas(string texto, string items, string texto2, string items2)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@texto", SqlDbType.Char);
            if (texto != "")
            {
                sqlParam.Value = texto;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }
            sqlParam = cmd.Parameters.Add("@items_a_buscar", SqlDbType.Char);
            if (items != "")
            {
                sqlParam.Value = items;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }
            sqlParam = cmd.Parameters.Add("@texto2", SqlDbType.Char);
            if (texto2 != "")
            {
                sqlParam.Value = texto2;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }
            sqlParam = cmd.Parameters.Add("@items_a_buscar2", SqlDbType.Char);
            if (items2 != "")
            {
                sqlParam.Value = items2;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarFormatoUpc()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_formato_upc", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ConsultarTodoFlor()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_todos";

            sqlParam = cmd.Parameters.Add("@id_tipo_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ValidarComida(int idComida, int idVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_comida_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "alerta_comida";
            sqlParam = cmd.Parameters.Add("@nombre_comida", SqlDbType.NVarChar,255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet ", SqlDbType.Int);
            sqlParam.Value = idComida;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet   ", SqlDbType.Int);
            sqlParam.Value = idVersionBouquet;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        #endregion 

        public DataSet Buscar(string items, string texto, string items2, string texto2)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@texto", SqlDbType.Char);
            if (texto != "")
            {
                sqlParam.Value = texto;
            }
            else 
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }            
            sqlParam = cmd.Parameters.Add("@items_a_buscar", SqlDbType.Char);
            if (items != "")
            {
                sqlParam.Value = items;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }            
            sqlParam = cmd.Parameters.Add("@texto2", SqlDbType.Char);
            if (texto2 != "")
            {
                sqlParam.Value = texto2;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }
            sqlParam = cmd.Parameters.Add("@items_a_buscar2", SqlDbType.Char);
            if (items2 != "")
            {
                sqlParam.Value = items2;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        #region BouquetNotSenttoFarm

            public DataSet NotSenttoFarmConsultar()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_editar_solicitud_confirmacion_cultivo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
                sqlParam.Value = "Consultar";
                sqlParam = cmd.Parameters.Add("@id_farm_detalle_po", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@aceptada", SqlDbType.Bit);
                sqlParam.Value = System.Data.SqlTypes.SqlByte.Null;
                sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
                sqlParam = cmd.Parameters.Add("@farm_price", SqlDbType.Decimal);
                sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
                sqlParam = cmd.Parameters.Add("@farm_price_modificado", SqlDbType.Decimal);
                sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
  
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }
        public DataSet NotSenttoFarmInsertar(int idFarmDetallePo, int idCuentaInterna, bool aceptada, string observacion, decimal farmPrice, decimal farmPrice_mod)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_editar_solicitud_confirmacion_cultivo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
                sqlParam.Value = "insertar";
                sqlParam = cmd.Parameters.Add("@id_farm_detalle_po", SqlDbType.Int);
                sqlParam.Value = idFarmDetallePo;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
                sqlParam.Value = idCuentaInterna;
                sqlParam = cmd.Parameters.Add("@aceptada", SqlDbType.Bit);
                sqlParam.Value = aceptada;
                sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
                sqlParam.Value = observacion;
                sqlParam = cmd.Parameters.Add("@farm_price", SqlDbType.Decimal);
                sqlParam.Value = farmPrice;
                sqlParam = cmd.Parameters.Add("@farm_price_modificado", SqlDbType.Decimal);
                sqlParam.Value = farmPrice_mod;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }
    
        public DataSet PrecioFinca(int idDetalle,int idFarm)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_consultar_farm_price", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@id_detalle_po", SqlDbType.Int);
            sqlParam.Value = idDetalle;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }


        #endregion


        #region AsignarGradosFlorCultivo
        public DataSet ConsultarAsignacionGrado()
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_editar_asignacion_grado_flor_cultivo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
                sqlParam.Value = "consultar";
                sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null; 
                sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo ", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna ", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
                sqlParam = cmd.Parameters.Add("@id_tipo_flor_grado_flor_cultivo ", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;




                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }
            public DataSet AsignarGrado(int idTipoFlor, int idGradoFlorCultivo,int idCuentainterna)
            {
                SqlConnection conn = null;
                string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

                conn = new SqlConnection(strConnString);
                conn.Open();

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("bouquet_editar_asignacion_grado_flor_cultivo", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = null;

                sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
                sqlParam.Value = "Insertar";
                sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
                sqlParam.Value = idTipoFlor;
                sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo ", SqlDbType.Int);
                sqlParam.Value = idGradoFlorCultivo;
                sqlParam = cmd.Parameters.Add("@id_cuenta_interna ", SqlDbType.Int);
                sqlParam.Value = idCuentainterna;
                sqlParam = cmd.Parameters.Add("@id_tipo_flor_grado_flor_cultivo ", SqlDbType.Int);
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


                

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(" BD: Error: " + ex.Message);
                    throw new Exception("Error");

                }
                finally
                {
                    conn.Close();
                }
                return dataSet;

            }
        public DataSet EliminarGrado(int idTipoFlor, int idGradoFlorCultivo)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_asignacion_grado_flor_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Eliminar";
            sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
            sqlParam.Value = idTipoFlor;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tipo_flor_grado_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = idGradoFlorCultivo;




            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ModificarGrado(int idTipoFlor, int idGradoFlorCultivo, int idTipoFlorGradoFlorCultivo)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_asignacion_grado_flor_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Modificar";
            sqlParam = cmd.Parameters.Add("@id_tipo_flor", SqlDbType.Int);
            sqlParam.Value = idTipoFlor;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = idGradoFlorCultivo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tipo_flor_grado_flor_cultivo ", SqlDbType.Int);
            sqlParam.Value = idTipoFlorGradoFlorCultivo;




            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        #endregion

        #region BOXCHARGE

        public DataSet ConsultarBoxCharge()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_descuento_box_charge", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@id_farm_detalle_po ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
            sqlParam.Value = " ";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_descuento", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
             


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet InsertarBoxCharge(int idFarmDetallePo,int idCuentaInterna,decimal valorDescuento)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_descuento_box_charge", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Insertar";
            sqlParam = cmd.Parameters.Add("@id_farm_detalle_po ", SqlDbType.Int);
            sqlParam.Value = idFarmDetallePo;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@valor_descuento", SqlDbType.Decimal);
            sqlParam.Value = valorDescuento;



            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        #endregion

        #region VARIEDAD_RESTRINGIDA

        public DataSet RestriccionInsertar(int idVariedad,int idDespacho, string observaciones,int cuentaInterna)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_variedad_restringida_cliente", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "Insertar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = cuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
            sqlParam.Value = idDespacho;
            sqlParam = cmd.Parameters.Add("@id_variedad_restringida_cliente", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = observaciones;
            
             


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet RestriccionConsultar()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_variedad_restringida_cliente", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "Consultar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_restringida_cliente", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet RestriccionEliminar(int id,int cuentaInterna)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_variedad_restringida_cliente", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "Deshabilitar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = cuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_despacho", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_restringida_cliente", SqlDbType.Int);
            sqlParam.Value = id;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }


        #endregion

        #region DEFINE_BOQUET_RECIPE

        public DataSet ConsultarBouquet()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_version_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ConsultarBouquet(Int32 idversion)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_version_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = idversion;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet InsertarBouquet(int idVariedad, int idGrado, byte[] imagen,int idCaja)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_version_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "Insertar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGrado;
            if (imagen == null)
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo

            }
            else
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = imagen;
            }
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;

            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            sqlParam = cmd.Parameters.Add("@id_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ActualizarBouquet(int idVersion,int idVariedad, int idGrado, byte[] imagen, int idCaja)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_version_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar";
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGrado;
            if (imagen == null)
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;// campo imagen nulo

            }
            else
            {
                sqlParam = cmd.Parameters.Add("@imagen", SqlDbType.Image);
                sqlParam.Value = imagen;
            }
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;

            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami_pieza", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            sqlParam = cmd.Parameters.Add("@id_version_bouquet ", SqlDbType.Int);
            sqlParam.Value = idVersion;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }


        #endregion

        #region NOT_FARM_CONFIRMED

        public DataSet NotFarmConfirmedConsultar()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_confirmacion_bouquet_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@id_solicitud_confirmacion_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@aceptada", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlByte.Null;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet NotFarmConfirmedInsertar(int idSolicitudConfirmacionCultivo, int idCuentaInterna,bool aceptada, string observacion,int piezas)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_confirmacion_bouquet_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar";
            sqlParam = cmd.Parameters.Add("@id_solicitud_confirmacion_cultivo", SqlDbType.Int);
            sqlParam.Value = idSolicitudConfirmacionCultivo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@aceptada", SqlDbType.Bit);
            sqlParam.Value = aceptada;
            sqlParam = cmd.Parameters.Add("@observacion", SqlDbType.Char);
            sqlParam.Value = observacion;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value =piezas;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        #endregion 

        #region EditGeneralInfo
        public DataSet CapuchonesConsultar()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@nombre_capuchon", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ancho_superior", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@ancho_inferior", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@alto", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@decorado", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlByte.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet CapuchonesInsertar(string nombre_capuchon,decimal ancho_superior,decimal ancho_inferior,decimal alto,bool decorado)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar";
            sqlParam = cmd.Parameters.Add("@nombre_capuchon", SqlDbType.Char);
            sqlParam.Value = nombre_capuchon;
            sqlParam = cmd.Parameters.Add("@ancho_superior", SqlDbType.Decimal);
            sqlParam.Value = ancho_superior;
            sqlParam = cmd.Parameters.Add("@ancho_inferior", SqlDbType.Decimal);
            sqlParam.Value = ancho_inferior;
            sqlParam = cmd.Parameters.Add("@alto", SqlDbType.Decimal);
            sqlParam.Value = alto;
            sqlParam = cmd.Parameters.Add("@decorado", SqlDbType.Bit);
            sqlParam.Value = decorado;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet CapuchonesEliminar(int id_capuchon_cultivo)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_capuchon_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "eliminar";
            sqlParam = cmd.Parameters.Add("@nombre_capuchon", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@ancho_superior", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@ancho_inferior", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@alto", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@decorado", SqlDbType.Bit);
            sqlParam.Value = System.Data.SqlTypes.SqlByte.Null;
            sqlParam = cmd.Parameters.Add("@id_capuchon_cultivo", SqlDbType.Int);
            sqlParam.Value = id_capuchon_cultivo;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet ComidaConsultar()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_comida_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@nombre_comida ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ComidaInsertar(string nombre)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_comida_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar";
            sqlParam = cmd.Parameters.Add("@nombre_comida ", SqlDbType.Char);
            sqlParam.Value = nombre;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet ", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet ComidaEliminar(int idComida)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_comida_bouquet", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "eliminar";
            sqlParam = cmd.Parameters.Add("@nombre_comida ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet ", SqlDbType.Int);
            sqlParam.Value = idComida;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet StickerConsultar()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar";
            sqlParam = cmd.Parameters.Add("@nombre_sticker", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_sticker", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet StickerInsertar(string nombre)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar";
            sqlParam = cmd.Parameters.Add("@nombre_sticker", SqlDbType.Char);
            sqlParam.Value = nombre;
            sqlParam = cmd.Parameters.Add("@id_sticker", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet StickerEliminar(int idSticker)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_sticker_cultivo", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "eliminar";
            sqlParam = cmd.Parameters.Add("@nombre_sticker", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_sticker", SqlDbType.Int);
            sqlParam.Value = idSticker;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        #endregion


        #region PEDIDOS_NEW_APL

        public DataSet PedidosConsultarCompradores()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_comprador";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@descripcion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@fecha_inicial", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_final", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@unidades_por_pieza", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_unitario", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@comentario", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
           

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosInsertarPedido(int idCuentaInterna,int idFarm,string descripcion,int idComprador)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_pedido";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@descripcion", SqlDbType.Char);
            sqlParam.Value = descripcion;
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = idComprador;
            sqlParam = cmd.Parameters.Add("@id_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@fecha_inicial", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_final", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@unidades_por_pieza", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_unitario", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@comentario", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosConsultarProductos(int idFarm)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_productos";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@descripcion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@fecha_inicial", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_final", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@unidades_por_pieza", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@valor_unitario", SqlDbType.Decimal);
            sqlParam.Value = System.Data.SqlTypes.SqlDecimal.Null;
            sqlParam = cmd.Parameters.Add("@comentario", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosInsertarDetalle(int idOrdenPedido, int idVariedad, int idGrado, int idTapa, int idCaja, string marca, string fechaInicial, string fechaFinal, int unidades, int piezas, decimal valor, string comentario)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_detalle_pedido";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@descripcion", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = idOrdenPedido;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGrado;
            sqlParam = cmd.Parameters.Add("@id_tapa", SqlDbType.Int);
            sqlParam.Value = idTapa;
            sqlParam = cmd.Parameters.Add("@id_caja", SqlDbType.Int);
            sqlParam.Value = idCaja;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.Char);
            sqlParam.Value = marca;
            sqlParam = cmd.Parameters.Add("@fecha_inicial", SqlDbType.DateTime);
            sqlParam.Value = fechaInicial;
            sqlParam = cmd.Parameters.Add("@fecha_final", SqlDbType.DateTime);
            sqlParam.Value = fechaFinal;
            sqlParam = cmd.Parameters.Add("@unidades_por_pieza", SqlDbType.Int);
            sqlParam.Value = unidades;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = piezas;
            sqlParam = cmd.Parameters.Add("@valor_unitario", SqlDbType.Decimal);
            sqlParam.Value = valor;
            sqlParam = cmd.Parameters.Add("@comentario", SqlDbType.Char);
            sqlParam.Value = comentario;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosConsultarPendientes(int idComprador)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_despachar_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_pedidos_pendientes";
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = idComprador;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_estado_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@fecha_estimada_despacho_flor", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosInsertarDetallePendientes(int idCuentaInterna, int idDetalleOrdenPedidoCultivo, int idEstadoDespachoOrdenPedidoCultivo, int idVariedad, int idGrado, string fecha, int cantidadPiezas)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_despachar_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_detalle_pedido";
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = idDetalleOrdenPedidoCultivo;
            sqlParam = cmd.Parameters.Add("@id_estado_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = idEstadoDespachoOrdenPedidoCultivo;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = idGrado;
            sqlParam = cmd.Parameters.Add("@fecha_estimada_despacho_flor", SqlDbType.DateTime);
            sqlParam.Value = fecha;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = cantidadPiezas;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosConsultarEstado()
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_despachar_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "estado_despacho_pedido";
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_estado_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@fecha_estimada_despacho_flor", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosLigarConsultarPendientes(int idComprador)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_despachar_pedido", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_pedidos_pendientes";
            sqlParam = cmd.Parameters.Add("@accion2", SqlDbType.Char);
            sqlParam.Value = "consultar_reprogramacion";
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = idComprador;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_estado_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_grado_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@fecha_estimada_despacho_flor", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet PedidosLigarInsertarRemision(string numeroRemision,int idCuentaInterna)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_etiqueta", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_numero_remision";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@numero_remision ", SqlDbType.Char);
            sqlParam.Value = numeroRemision;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_recibo_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
        public DataSet PedidosLigarInsertarEtiqueta(int idDespacho,int idCuentaInterna,int idDetalle,int idReciboFlor)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_etiqueta", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "insertar_etiqueta";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@numero_remision ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = idDetalle;
            sqlParam = cmd.Parameters.Add("@id_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = idDespacho;
            sqlParam = cmd.Parameters.Add("@id_recibo_flor", SqlDbType.Int);
            sqlParam.Value = idReciboFlor;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }

        public DataSet PedidosLigarReimprimirEtiqueta(int idComprador, string  numeroRemision)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("opc_crear_etiqueta", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "consultar_numero_remision";
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt16.Null;
            sqlParam = cmd.Parameters.Add("@numero_remision ", SqlDbType.Char);
            sqlParam.Value = numeroRemision;
            sqlParam = cmd.Parameters.Add("@id_detalle_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt16.Null;
            sqlParam = cmd.Parameters.Add("@id_despacho_orden_pedido_cultivo", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt16.Null;
            sqlParam = cmd.Parameters.Add("@id_recibo_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt16.Null;
            sqlParam = cmd.Parameters.Add("@id_comprador", SqlDbType.Int);
            sqlParam.Value = idComprador;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }


        public DataSet InsertarEtiqueta(int idUsuario, int idEtiqueta)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("wbl_etiqueta_impresa", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_etiqueta", SqlDbType.Int);
            sqlParam.Value = idEtiqueta;
            sqlParam = cmd.Parameters.Add("@id_usuario", SqlDbType.Int);
            sqlParam.Value = idUsuario;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "Insertar";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //log.Error("InsertarEtiqueta", ex);
                throw new Exception("InsertarEtiqueta");
            }
            return dataSet;
        }

        public DataSet EliminarEtiquetas(int idUsuario)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("wbl_etiqueta_impresa", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_etiqueta", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_usuario", SqlDbType.Int);
            sqlParam.Value = idUsuario;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "eliminar_etiquetas";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(" BD: Error: " + ex.Message);
                //log.Error("EliminarEtiquetas", ex);
                throw new Exception("EliminarEtiquetas");
            }
            return dataSet;
        }

        #endregion

        #region ENVIO_OREDENES_MASS_MARKET

        public DataSet MassMarketGenerarConsecutivo(int idFarm,byte[] archivo,int idCuentaInterna,string extensionArchivo,string po)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("mmk_editar_envio_orden", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@archivo", SqlDbType.Image);
            sqlParam.Value = archivo;
            sqlParam = cmd.Parameters.Add("@extension_archivo", SqlDbType.NVarChar, 255);
            sqlParam.Value = extensionArchivo;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value =idCuentaInterna;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "generar_consecutivo";
            sqlParam = cmd.Parameters.Add("@numero_solicitud", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.NVarChar, 255);
            sqlParam.Value = po;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@nombre_hoja", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("MassMarketGenerarConsecutivo");
            }
            return dataSet;
        }

        public DataSet MassMarketCrearDetalle(string fechaVuelo, int cantidadPiezas, int numeroSolicitud, int idFarm, string marca, string nombreHoja)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("mmk_editar_envio_orden", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@archivo", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;
            sqlParam = cmd.Parameters.Add("@extension_archivo", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = fechaVuelo;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = cantidadPiezas;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "crear_detalle";
            sqlParam = cmd.Parameters.Add("@numero_solicitud", SqlDbType.Int);
            sqlParam.Value = numeroSolicitud;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.NVarChar, 255);
            if (marca == "") { sqlParam.Value = System.Data.SqlTypes.SqlChars.Null; }
            else 
            {
                sqlParam.Value = marca;
            }            
            sqlParam = cmd.Parameters.Add("@nombre_hoja", SqlDbType.NVarChar, 255);
            if (nombreHoja == "") { sqlParam.Value = System.Data.SqlTypes.SqlChars.Null; }
            else
            {
                sqlParam.Value = nombreHoja;
            }  
            
            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("MassMarketGenerarConsecutivo");
            }
            return dataSet;
        }

        public DataSet MassMarketConsultarArchivo(int idFarm, int numeroSolicitud)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("mmk_editar_envio_orden", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_farm", SqlDbType.Int);
            sqlParam.Value = idFarm;
            sqlParam = cmd.Parameters.Add("@archivo", SqlDbType.Image);
            sqlParam.Value = System.Data.SqlTypes.SqlBytes.Null;
            sqlParam = cmd.Parameters.Add("@extension_archivo", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@fecha_vuelo", SqlDbType.DateTime);
            sqlParam.Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlParam = cmd.Parameters.Add("@cantidad_piezas", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar_archivo";
            sqlParam = cmd.Parameters.Add("@numero_solicitud", SqlDbType.Int);
            sqlParam.Value = numeroSolicitud;
            sqlParam = cmd.Parameters.Add("@po_number", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@marca", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@nombre_hoja", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("MassMarketGenerarConsecutivo");
            }
            return dataSet;
        }

        #endregion

        #region EDITAR GRUPOS DE FLOR

        public DataSet EditarGrupos_CrearGrupos(string nombreGrupo)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = nombreGrupo;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "crear_grupo_flor";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_CrearGrupos");
            }
            return dataSet;
        }
        public DataSet EditarGrupos_EditarGrupo(string nombreGrupo, int idGrupo)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = idGrupo;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = nombreGrupo;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "editar_grupo_flor";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_EditarGrupo");
            }
            return dataSet;
        }
        public DataSet EditarGrupos_ConsultarGrupo()
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar_grupo_flor";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_ConsultarGrupo");
            }
            return dataSet;
        }
        public DataSet EditarGrupos_EliminarGrupo(int idGrupo)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = idGrupo;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "eliminar_grupo_flor";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_EliminarGrupo");
            }
            return dataSet;
        }
        public DataSet EditarGrupos_CrearGrupoVariedad(int idGrupo, int idVariedad)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = idGrupo;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "crear_grupo_flor_variedad";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_CrearGrupoVariedad");
            }
            return dataSet;
        }
        public DataSet EditarGrupos_EliminarGrupoVariedad(int idGrupo, int idVariedad)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = idGrupo;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "eliminar_grupo_flor_variedad";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_EliminarGrupoVariedad");
            }
            return dataSet;
        }

        public DataSet EditarGrupos_ConsultarGrupoVariedad(int idGrupo)
        {
            DataSet dataSet = new DataSet();

            //Create a SqlDataAdapter for the Suppliers table.
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("p&g_editar_grupo_flor", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;

            SqlParameter sqlParam = null;
            sqlParam = cmd.Parameters.Add("@id_grupo_flor", SqlDbType.Int);
            sqlParam.Value = idGrupo;
            sqlParam = cmd.Parameters.Add("@nombre_grupo_flor", SqlDbType.NVarChar, 255);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.NVarChar, 255);
            sqlParam.Value = "consultar_grupo_flor_variedad";

            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("EditarGrupos_ConsultarGrupoVariedad");
            }
            return dataSet;
        }

        #endregion 
    
        public DataSet InsertarObservacion(int? idVariedad, int? idGrado, int? cantidadTallos, int? idFormulaBouquet, string Observacion, int? VariedadSustitucion, int? GradoSustitucion, int? idDetalleVersionBouquet)
        {
            SqlConnection conn = null;
            string strConnString = ConfigurationManager.ConnectionStrings["CSBD_"].ConnectionString;

            conn = new SqlConnection(strConnString);
            conn.Open();

            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("bouquet_editar_recetas", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@accion", SqlDbType.Char);
            sqlParam.Value = "actualizar_restriccion_detalle_formula";
            sqlParam = cmd.Parameters.Add("@id_formula_bouquet", SqlDbType.Int);
            sqlParam.Value = idFormulaBouquet;
            sqlParam = cmd.Parameters.Add("@id_version_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_cuenta_interna", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@nombre_formula_bouquet", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idVariedad;
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo", SqlDbType.Int);
            sqlParam.Value = idGrado;
            sqlParam = cmd.Parameters.Add("@cantidad_tallos", SqlDbType.Int);
            sqlParam.Value = cantidadTallos;
            sqlParam = cmd.Parameters.Add("@id_detalle_version_bouquet", SqlDbType.Int);
            sqlParam.Value = idDetalleVersionBouquet;
            sqlParam = cmd.Parameters.Add("@especificacion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@construccion_bouquet ", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@observacion ", SqlDbType.Char);
            if (Observacion != "")
            {
                sqlParam.Value = Observacion;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            }

            sqlParam = cmd.Parameters.Add("@cadena_formula", SqlDbType.Char);
            sqlParam.Value = System.Data.SqlTypes.SqlChars.Null;
            sqlParam = cmd.Parameters.Add("@id_variedad_flor_cultivo_sustitucion", SqlDbType.Int);
            if (VariedadSustitucion != -1)
            {
                sqlParam.Value = VariedadSustitucion;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            sqlParam = cmd.Parameters.Add("@id_grado_flor_cultivo_sustitucion", SqlDbType.Int);
            if (GradoSustitucion != -1)
            {
                sqlParam.Value = GradoSustitucion;
            }
            else
            {
                sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            sqlParam = cmd.Parameters.Add("@unidades", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@precio_miami", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlParam = cmd.Parameters.Add("@id_comida_bouquet", SqlDbType.Int);
            sqlParam.Value = System.Data.SqlTypes.SqlInt32.Null;


            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" BD: Error: " + ex.Message);
                throw new Exception("Error");

            }
            finally
            {
                conn.Close();
            }
            return dataSet;

        }
    }
}