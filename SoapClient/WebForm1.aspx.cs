using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoapClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();

            DataSet dt = ws.verListadoEvento();

            gv_datos.DataSource = dt;
            gv_datos.DataBind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string evento = txt_evento.Text;
            string fecha = txt_fecha.Text;
            string fono = txt_fono.Text;
            string nombre = txt_nombre.Text;
            string num = txt_num.Text;
            string rut = txt_rut.Text;

            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
            ws.compraTicket(evento, fecha, fono, nombre, num, rut);

            DataSet dt = ws.verListadoEvento();

            gv_datos.DataSource = dt;
            gv_datos.DataBind();
        }
    }
}