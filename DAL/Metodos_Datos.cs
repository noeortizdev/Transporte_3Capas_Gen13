using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Metodos_Datos
    {
        // Método para ejecutar un dataset.
        // Utilizado para ejecutar una consulta SQL que devuelve un conjunto de datos.
        // Que puede contener una o varias tablas con filas y columnas de datos.

        public static DataSet Execute_DataSet(string sp, params object[] parametros)
        {
            // Instanciamos un DS (DataSet) => ADO (Access Data Object)
            DataSet ds = new DataSet(); // Simula una tabla
            // Obtenemos la cadena de conexión.
            string conn = Configuracion.CadenaConexion;
            // Creamos una conexión => SQLConnection Objeto de ADO.
            SqlConnection SQLcon = new SqlConnection(conn);

            try
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
                else
                {
                    // Comando para SQL (sp, conexion) => SqlCommand objeto de ADO.
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    // Defino que el comando será ejecutado como una SP (Stored Procedure).
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Pasamos el SP(El SP significa Stored Procedure)
                    cmd.CommandText = sp;

                    // Validamos si existen y están completos los parámetros.
                    // Si es diferente de "null" y su residuo es diferente de 0.
                    // "parametros" = { clave : valor }
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        // Asignamos los parámetros al comando.
                        for (int i = 0; i < parametros.Length; i = i+2)
                        {
                            // SqlParametrer => Objeto de ADO.
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        // Abrimos la conexión.
                        SQLcon.Open();
                        // Ejecutamos el comando.
                        // SqlDataAdapter => Objeto de ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        // Llenamos el "ds".
                        adapter.Fill(ds);
                        // Cerramos la conexión.
                        SQLcon.Close();
                    }
                }

                // Retorno el DS (DataSet).
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
            }
        }

        // Método que ejecuta un escalar.
        // Ejecuta una consulta SQL que devuelve un solo valor o una sola columna de datos.
        // Retorna el valor de la primera columna y la primera fila del conjunto de resultado.
        public static int Execute_Scalar(string sp, params object[] parametros)
        {
            // Instanciamos un entero.
            int id = 0;
            // Obtenemos la cadena de conexión.
            string conn = Configuracion.CadenaConexion;
            // Creamos una conexión => SQLConnection Objeto de ADO.
            SqlConnection SQLcon = new SqlConnection(conn);

            try
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
                else
                {
                    // Comando para SQL (sp, conexion) => SqlCommand objeto de ADO.
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    // Defino que el comando será ejecutado como una SP (Stored Procedure).
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Pasamos el SP(El SP significa Stored Procedure)
                    cmd.CommandText = sp;

                    // Validamos si existen y están completos los parámetros.
                    // Si es diferente de "null" y su residuo es diferente de 0.
                    // "parametros" = { clave : valor }
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        // Asignamos los parámetros al comando.
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            // SqlParametrer => Objeto de ADO.
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        // Abrimos la conexión.
                        SQLcon.Open();
                        // Ejecutar el comando de forma que reciba un Scalar.
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        // Cerramos la conexión.
                        SQLcon.Close();
                    }
                }

                // Retorno el DS (DataSet).
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
            }
        }

        // Método que ejecuta un NonQuery.
        // Utilizado para ejecutar consultas SQL que no devuelven un conjunto de resultados.
        // Como sentencias INSERT, UPDATE o DELETE.
        // Retorna un valor eneteor que representa el número de filas afectadas por la operación.
        // (por ejemplo, el número de filas insertadas, actualizadas o eliminadas).
        // Metodos datos completo (DataSet, Scalar, nonQuery) => Cambios de Git.
        public static int Execute_NonQuery(string sp, params object[] parametros)
        {
            // Instanciamos un entero.
            int id = 0;
            // Obtenemos la cadena de conexión.
            string conn = Configuracion.CadenaConexion;
            // Creamos una conexión => SQLConnection Objeto de ADO.
            SqlConnection SQLcon = new SqlConnection(conn);

            try
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
                else
                {
                    // Comando para SQL (sp, conexion) => SqlCommand objeto de ADO.
                    SqlCommand cmd = new SqlCommand(sp, SQLcon);
                    // Defino que el comando será ejecutado como una SP (Stored Procedure).
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Pasamos el SP(El SP significa Stored Procedure)
                    cmd.CommandText = sp;

                    // Validamos si existen y están completos los parámetros.
                    // Si es diferente de "null" y su residuo es diferente de 0.
                    // "parametros" = { clave : valor }
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        // Asignamos los parámetros al comando.
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            // SqlParametrer => Objeto de ADO.
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        // Abrimos la conexión.
                        SQLcon.Open();
                        // Ejecuto el comando sin esperar retorno.
                        cmd.ExecuteNonQuery();
                        id = 1;
                        // Cerramos la conexión.
                        SQLcon.Close();
                    }
                }

                // Retorno el DS (DataSet).
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                // Verificamos si la conexión está abierta.
                if (SQLcon.State == ConnectionState.Open)
                {
                    // Cerramos la conexión.
                    SQLcon.Close();
                }
            }
        }
    }
}