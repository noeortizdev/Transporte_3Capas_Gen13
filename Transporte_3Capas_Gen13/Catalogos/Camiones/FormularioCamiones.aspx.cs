using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transporte_3Capas_Gen13.Utilidades;
using VO;

namespace Transporte_3Capas_Gen13.Catalogos.Camiones
{
    public partial class FormularioCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Válido si es Postback.
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar
                    Titulo.Text = "Agregar Camión";
                    subTitulo.Text = "Registro de un nuevo camión";
                    lblDisponibilidad.Visible = false;
                    chkDisponibilidad.Visible = false;
                    imgFoto.Visible = false;
                    lblUrlFoto.Visible = false;
                }
                else
                {
                    // Voy a Actualizar
                    // Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    // Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes.
                    Camiones_VO _camionOriginal = BLL_Camiones.Get_Camiones("@ID_Camion", _id)[0];
                    // Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario.
                    if (_camionOriginal.ID_Camion != 0)
                    {
                        // Si encontré el Camión y coloco sus valores.
                        Titulo.Text = "Actualizar camión";
                        subTitulo.Text = $"Modificar los datos del camión #{_id}";
                        txtMatricula.Text = _camionOriginal.Matricula;
                        txtCapacidad.Text = _camionOriginal.Capacidad.ToString();
                        txtKilometraje.Text = _camionOriginal.Kilometraje.ToString();
                        txtTipo.Text = _camionOriginal.Tipo_Camion.ToString();
                        txtMarca.Text = _camionOriginal.Marca;
                        txtModelo.Text = _camionOriginal.Modelo;
                        chkDisponibilidad.Checked = _camionOriginal.Disponibilidad;
                        imgFoto.ImageUrl = _camionOriginal.UrlFoto;
                    }
                    else
                    {
                        // No encontré el objeto y me voy para atrás.
                        Response.Redirect("Listado_Camiones.aspx");
                    }
                }
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            // Este METODO sirve para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info desde la BD.
            if (subeImagen.Value != "")
            {
                // Recupero el nombre del archivo.
                string fileName = Path.GetFileName(subeImagen.Value);
                // Valido la extención del archivo.
                string fileExt = Path.GetExtension(fileName).ToLower();
                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    // Sweet Alert
                }
                else
                {
                    // Verifico que existe el directorio en el servidor, para poder almacenar la imagen, de los contrario, procedo a crearlo.
                    string pathDir = Server.MapPath("~/Imagenes/Camiones/");
                    // ~ (virgulilla) hace referencia a la dirección completa del servidor, independientemente de donde esté instalado, permitiendo que la validación funcione en diferentes entornos.

                    // Si no existe el directorio, lo creamos.
                    if (!Directory.Exists(pathDir))
                    {
                        // Creo el directorio.
                        Directory.CreateDirectory(pathDir);
                    }

                    // Subo la imagen a la carpeta del servidor.
                    subeImagen.PostedFile.SaveAs(pathDir + fileName);
                    // Recuperamosla ruta de la URL que almacenaremos en la BD.
                    string urlFoto = "/Imagenes/Camiones/" + fileName;
                    // Mostramos en pantalla la URL creada.
                    this.urlFoto.Text = urlFoto;
                    // Mostramos la imagen
                    imgCamion.ImageUrl = urlFoto;
                    // Sweet 
                }
            }
            else
            {
                // Sweet Alert.
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                // Creamos el objeto que enviaremos para actualizar o insertar a la BD.
                // Existen 2 formas de instanciar y llenar un objeto.
                // Forma 1 (por atributos)
                Camiones_VO _camionAux = new Camiones_VO();
                _camionAux.Matricula = txtMatricula.Text;
                _camionAux.Marca = txtMarca.Text;
                _camionAux.Tipo_Camion = txtTipo.Text;
                _camionAux.Modelo = txtModelo.Text;
                _camionAux.Capacidad = Convert.ToInt32(txtCapacidad.Text);
                _camionAux.Kilometraje = Convert.ToDouble(txtKilometraje.Text);
                _camionAux.UrlFoto = imgCamion.ImageUrl;
                _camionAux.Disponibilidad = chkDisponibilidad.Checked;

                // Forma 2 (durante la propia instancia)
                Camiones_VO _camionAux2 = new Camiones_VO()
                {
                    Matricula = txtMatricula.Text,
                    Marca = txtMarca.Text,
                    Tipo_Camion = txtTipo.Text,
                    Modelo = txtModelo.Text,
                    Capacidad = Convert.ToInt32(txtCapacidad.Text),
                    Kilometraje = Convert.ToDouble(txtKilometraje.Text),
                    UrlFoto = imgCamion.ImageUrl,
                    Disponibilidad = chkDisponibilidad.Checked
                };

                // Decido si voy a insertar o actualizar.
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar.
                    _camionAux.Disponibilidad = true;
                    salida = BLL_Camiones.Insertar_Camion(_camionAux);
                }
                else
                {
                    if (imgCamion.ImageUrl == "")
                    {
                        _camionAux.UrlFoto = imgFoto.ImageUrl;
                    }

                    // Actualizar.
                    _camionAux.ID_Camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.Actualizar_Camion(_camionAux);
                }

                // Preparamos la salida para cachar un error y mostrar el Sweet Alert.
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    respuesta = salida;
                    tipo = "warning";
                }
                else
                {
                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            // Sweet Alert.
            SweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Camiones/Listado_Camiones.aspx");
        }
    }
}