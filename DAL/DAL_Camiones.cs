using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        // Create

        // Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_camiones = Metodos_Datos.Execute_DataSet("SP_listar_camiones", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // Update

        // Delete
    }
}
