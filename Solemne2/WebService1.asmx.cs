using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CompraTicket;

namespace Solemne2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet verListadoEvento() {
             Evento ev = new Evento();
            String error = "";
            DataSet dt = ev.verListadoEvento(ref error);

            return dt;
        }

        [WebMethod]
        public void compraTicket(string cod_evento, string fecha_compra, string fono_contacto,
                                    string nombre_cliente, string num_ticket, string rut_cliente)
        {
            CompraTicketPadre cm = new CompraTicketPadre();

            cm.ComprarTicket(cod_evento, fecha_compra, fono_contacto, nombre_cliente, num_ticket, rut_cliente);
        }


    }
}
