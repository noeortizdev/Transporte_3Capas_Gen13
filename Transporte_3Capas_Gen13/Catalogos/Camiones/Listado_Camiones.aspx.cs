using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_3Capas_Gen13.Catalogos.Camiones
{
    public partial class Listado_Camiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Utilizamos la variable "IsPostBack" para controlar la primera vez que carga la página.
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        public void CargarGrid()
        {
            // Cargar la información desde la BLL al GV.
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            // Mostramos los resultados renderizando la información.
            GVCamiones.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioCamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Recupero el ID del renglón afectado.
            int id_Camion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["ID_Camion"].ToString());
            // Invoco mi método para eliminar mi camión.
            string respuesta = BLL_Camiones.Eliminar_Camion(id_Camion);
            // Preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "sucees";
            }

            // Sweet Alert.
            // Recargamos la página.
            CargarGrid();
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Defino si el comando (el click que se detecta) tiene la propiedad "Select".
            if (e.CommandName == "Select")
            {
                // Recupero el índice en función de aquel elemento que haya detonado el evento.
                int varIndex = int.Parse(e.CommandArgument.ToString());
                // Recupero el ID en función del índice que recuperamos anteriormente.
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                // Redirecciono al formulario de edición pasando como parámetro el ID.
                Response.Redirect($"FormularioCamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}