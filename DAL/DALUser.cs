using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BE;


namespace DAL
{
    public class DALUser
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=PatronState;Integrated Security=True");
        public void updateUser(BEUser user)
        {
            string query = "UPDATE Users SET points = " + user.Points + ", Id_state = " + user.getStateId() + " WHERE id =" + user.Id;
            Escribir(query, null);

        }
        public void createUser(BEUser user)
        {
            string query = "insert into Users (Name,Points,Id_state) Values('" + user.Name + "', " + 0 + ", " + 1 + ")";
            Escribir(query,null);
        }
        public List<BEUser> getUsers()
        {
            string query = "select * from Users  join State on Users.Id_state = State.Id ";
            DataTable table = Leer(query, null);
            List<BEUser> list = new List<BEUser>();
            
            foreach(DataRow row in table.Rows)
            {
                BEUser user = new BEUser(Convert.ToInt32(row["Id"]), Convert.ToString(row["Name"]), Convert.ToInt32(row["Points"]), Convert.ToString(row["Beneficios"]), Convert.ToString(row["Nombre"]));

                 list.Add(user);
            }
            return list;
        }
        public DataTable Leer(string consulta, Hashtable hdatos)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;

            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);

                if (hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }

                adaptador.Fill(table);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return table;
        }

        public void Escribir(string consulta, Hashtable hdatos)
        {
            conexion.Open();
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;

            try
            {
                if (hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
