using datos;
using datos.NAVISION;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace negocio.Componentes
{
    public class EmpleadosCOM
    {
        /// <summary>
        /// Devuelve un DatatTable con la informacion de un empleado
        /// </summary>
        /// <param name="id_proyect"></param>
        /// <returns></returns>
        public DataTable Get(Employee entidad)
        {
            DataTable dt = new DataTable();
            try
            {
                NAVISION context = new NAVISION();
                var query = context.Employee
                                .Where(s => s.Status == 1)
                                .Select(u => new
                                {
                                    u.No_,
                                    u.First_Name,
                                    u.Middle_Name,
                                    u.Last_Name,
                                    u.Initials,
                                    u.Job_Title,
                                    u.Phone_No_,
                                    u.Mobile_Phone_No_,
                                    u.E_Mail,
                                    u.Status,
                                    u.Company_E_Mail,
                                    u.Title,
                                    u.Puesto,
                                    u.Usuario_Red,
                                    u.PuestoId,
                                    nombre_completo =(u.First_Name.Trim()  +" "+ u.Last_Name.Trim() )
                                })
                                .OrderBy(u => u.First_Name);
                dt = To.DataTable(query.ToList());
                //dt.Columns.Add("nombre_completo");
                //foreach (DataRow row in dt.Rows)
                //{
                //    row["nombre_completo"] = row["First_Name"].ToString().Trim() + " " + row["Last_Name"].ToString().Trim();
                //}
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public DataTable GetLogin(string usuario)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<SqlParameter> listparameters = new List<SqlParameter>();
            Datos data = new Datos();
            listparameters.Add(new SqlParameter() { ParameterName = "@pusuario", SqlDbType = SqlDbType.Int, Value = usuario });
            try
            {
                //ds = data.datos_Clientes(listparameters);
                ds = data.enviar("sp_login", listparameters, false, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
    }
}