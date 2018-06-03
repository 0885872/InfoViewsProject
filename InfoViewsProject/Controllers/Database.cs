using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InfoViewsProject.Models;

namespace InfoViewsProject.Controllers
{
    public class Database
    {
        public List<string[]> getReservations()
        {
            List<string[]> reservations = new List<string[]>();
            String connString = "Server=drakonit.nl;Database=timbrrf252_roomreserve;Uid=timbrrf252_ictlab;Password=ictlabhro;SslMode=none";
            using (MySqlConnection connMysql = new MySqlConnection(connString))
            {
                using (MySqlCommand cmdd = connMysql.CreateCommand())
                {
                    cmdd.CommandText = "SELECT * FROM reservations";
                    cmdd.CommandType = System.Data.CommandType.Text;

                    cmdd.Connection = connMysql;

                    connMysql.Open();

                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] res = new string[5];
                            res[0] = reader["reservation_id"].ToString();
                            res[1] = reader["room_id"].ToString();
                            res[2] = reader["start"].ToString(); 
                            res[3] = reader["end"].ToString();
                            res[4] = reader["valid"].ToString();
                            res[2] = Convert.ToDateTime(res[2]).ToString("yyyy/MM/dd HH:mm");
                            res[3] = Convert.ToDateTime(res[3]).ToString("yyyy/MM/dd HH:mm");
                            reservations.Add(res);
                        }
                    }
                }
                connMysql.Close();
                return reservations;
            }
        }

        public void setReservations(List<string[]> reservationsToSave)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {

                conn.ConnectionString = "Server=drakonit.nl;Database=timbrrf252_roomreserve;Uid=timbrrf252_ictlab;Password=ictlabhro;SslMode=none";
                conn.Open();
                //String sql = "INSERT INTO reservations (group_id,user_name, user_mail, user_password, user_role, active) VALUES (" + groupid + ",'" + userModel.Name + "','" + userModel.Mail + "','" + userModel.Password + "', 'user', 0);";
                //MySqlCommand command = new MySqlCommand(sql, conn);
                //command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
