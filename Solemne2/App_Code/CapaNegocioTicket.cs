using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;

/// <summary>
/// Descripción breve de Class1
/// </summary>
/// 


namespace ParametrosSistema
{

    public static class Parametros   // El uso de static permite definir constantes
    {        
        public const string version = "versión 2.0";
    }
}


namespace CompraTicket
{
    public class CompraTicketPadre
    {
        string cod_evento = "";
        string fecha_compra = "";
        string fono_contacto = "";
        string nombre_cliente = "";
        string num_ticket = "";
        string rut_cliente = "";

        public Evento obj_evento = new Evento();

        public void CancelarTicket()
        {

        }

        
        public string ComprarTicket(string cod_evento, string fecha_compra, string fono_contacto,
                                    string nombre_cliente, string num_ticket, string rut_cliente)
        {
            string resultado = "OK";
            string string_de_conexion = "";
            string sqlInsert="", sqlUpdEvento="", sqlUpdTicket="";

            // Se deja definido el SQL que se ejecutara sobre la BD Access
            sqlInsert = "INSERT INTO tb_compraticket "+
                "(cod_evento, fecha_compra, fono_contacto, nombre_cliente, num_ticket, rut_cliente)" +
                "VALUES (" +
                "'" + cod_evento + "','" + fecha_compra + "','" + fono_contacto +
                "','" + nombre_cliente + "','" + num_ticket + "','" + rut_cliente +
                "')";
            
            sqlUpdTicket = "update tb_ticket set estado = 'C' where num_ticket='" + num_ticket + "'";

            sqlUpdEvento = "update tb_evento set cantidad_cupos_disponibles = (cantidad_cupos_disponibles - 1) where cod_evento='" + cod_evento + "'";

            // Se genera la conección a la BD, el parametro es el string de conección
            string_de_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(@"Datos\CompraTickets.mdb");

            OleDbConnection cnn = new OleDbConnection(string_de_conexion);
            //Se crea objeto para ejecutar comando sql (distinto de select)          
            OleDbCommand insertCommand = new OleDbCommand(sqlInsert, cnn);
            OleDbCommand updTicketCommand = new OleDbCommand(sqlUpdTicket, cnn);
            OleDbCommand updEventoCommand = new OleDbCommand(sqlUpdEvento, cnn);
            int count_ins = 0;

            try
            {
                cnn.Open();
                count_ins = insertCommand.ExecuteNonQuery();
                count_ins = updTicketCommand.ExecuteNonQuery();
                count_ins = updEventoCommand.ExecuteNonQuery();

            }
            catch (OleDbException ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            if (resultado == "OK")
            {
                resultado = resultado + " - " + Convert.ToString(count_ins) + " compra realizada.";
            }
            return resultado;
        }  // CompraTicket        

    }//fin clase ComprarTicketPadre


    public class CompraTicketHijo: CompraTicketPadre
    {
        public DataSet MostrarTicketComprados(ref string error)
        {
            string sql = "";

            sql = "SELECT num_ticket, cod_evento, estado FROM tb_ticket WHERE estado='C'";   // Consulta sql

            string string_de_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(@"Datos\CompraTickets.mdb");
            
            OleDbConnection cnn = new OleDbConnection(string_de_conexion);
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            try   // Ambiente controlado de ejecución, por errores externos
            {
                cnn.Open();
                da.Fill(ds);
            }
            catch (OleDbException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            // Procesamiento DataSet
            ds = CambiaNombresColumnas(ds);
            //

            return ds;
        }  // MostrarTicketComprados

        private DataSet CambiaNombresColumnas(DataSet ds)
        {            
            // Cambiamos nombres de columnas en la tabla 0 del dataset.
            ds.Tables[0].Columns[0].ColumnName = "Número ticket";
            ds.Tables[0].Columns[1].ColumnName = "Código evento";
            ds.Tables[0].Columns[2].ColumnName = "Estado";
            return ds;
        }


    }//fin clase CompraTicketHijo

    public class Evento
    {
        string cantidad_cupos_disponibles= "";
        string cod_evento = "";
        string fecha = "";
        string lugar = "";
        string nombre_evento = "";
        
        
        public DataSet verListadoEvento(ref string error)
        {
            string sql = "";

            sql = "SELECT * FROM tb_evento";   // Consulta sql

            string string_de_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(@"Datos\CompraTickets.mdb");
            
            OleDbConnection cnn = new OleDbConnection(string_de_conexion);
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            try   // Ambiente controlado de ejecución, por errores externos
            {
                cnn.Open();
                da.Fill(ds);
            }
            catch (OleDbException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return ds;
        }  // verListadoEvento


        public string IngresarEvento(string cod_evento, string nombre_evento, string lugar, string fecha, int cantidad_cupos_disponibles)
        {
            string resultado = "OK";
            string string_de_conexion = "";
            string sqlInsert;

            // Se deja definido el SQL que se ejecutara sobre la BD Access
            sqlInsert = "INSERT INTO tb_evento "+
                "(cod_evento, nombre_evento, lugar, fecha, cantidad_cupos_disponibles)" +
                "VALUES (" +
                "'" + cod_evento + "','" + nombre_evento + "','" + lugar + "','" + fecha + "'," + cantidad_cupos_disponibles + 
                ")";

            // Se genera la conección a la BD, el parametro es el string de conección
            string_de_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(@"Datos\CompraTickets.mdb");

            OleDbConnection cnn = new OleDbConnection(string_de_conexion);
            //Se crea objeto para ejecutar comando sql (distinto de select)          
            OleDbCommand insertCommand = new OleDbCommand(sqlInsert, cnn);
            int count_ins = 0;

            try
            {
                cnn.Open();
                count_ins = insertCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            if (resultado == "OK")
            {
                resultado = resultado + " - " + Convert.ToString(count_ins) + " registro(s) insertado(s).";
            }
            return resultado;
        }  // IngresarEvento        

    }//fin clase Evento

} // namespace CompraTicket