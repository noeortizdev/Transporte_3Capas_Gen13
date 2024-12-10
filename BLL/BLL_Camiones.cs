using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Camiones
    {
        // Create
        public static string Insertar_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.Insertar_Camion(camion);
        }

        // Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }

        // Update
        public static string Actualizar_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.Actualizar_Camion(camion);
        }

        // Delete
        public static string Eliminar_Camion(int id)
        {
            return DAL_Camiones.Eliminar_Camion(id);
        }
    }
}