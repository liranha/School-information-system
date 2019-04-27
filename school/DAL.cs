using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace school
{

    public static class DAL
    {
        static string conn_string = ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
        
        //get all classes from data base
        public static DataTable get_all_classes()
        {
            string sql = "select * from Class";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(conn_string);

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);


            connection.Close();
            return dt;
        }

        //get all students per class from data base
        public static DataTable get_all_students_in_class(string class_name)
        {
            string sql = "select * from Student where class_name = N'" + class_name + "'";

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(conn_string);

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);


            connection.Close();
            return dt;
        }
    }
}