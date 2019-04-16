using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Guardllet_Desarrollo.Backend.Data.Customers;
using Guardllet_Desarrollo.Backend.Data.Wallet;

namespace Guardllet_Desarrollo.Frontend.Customers
{
    public partial class MiDinero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["usuario"].ToString();
            int id_datos = ObtenerDatos.id_datos(Convert.ToInt16(id));
            int id_monedero = ObtenerMonedero.id_monedero(Convert.ToInt16(id));

            Dictionary<string, string> datos = ObtenerDatos.Generales(id_datos);
            Byte[] monedero = ObtenerMonedero.CodigoImg(id_monedero);

            string ConvercionImg = "Data:image/jpg;base64," + Convert.ToBase64String(monedero);
            Monedero.ImageUrl = ConvercionImg;
        }
    }
}