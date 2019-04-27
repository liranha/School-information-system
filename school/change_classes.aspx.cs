using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace school
{
    public partial class change_classes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //insert class to data base
        protected void add_class_data(object sender, EventArgs e)
        {
            //validation
            string str_class_name = help_methods.escape_char(txt_class_name.Text.Trim());
            string str_teacher_name = help_methods.escape_char(txt_teacher_name.Text.Trim());

            if (String.IsNullOrEmpty(str_class_name))
                Response.Write("<script language=javascript>alert('The class should not be empty');</script>");
            else if (is_class_exists(str_class_name))
                Response.Write("<script language=javascript>alert('The class you have chosen already exists');</script>");
            else//insert
            {
                insert_class(str_class_name, str_teacher_name);

                Response.Redirect("show_classes.aspx");

            }



        }
        //insert class calling stored procedure
        private static void insert_class(string str_class_name, string str_teacher_name)
        {
            SqlConnection connection = new SqlConnection(help_methods.conn_string);

            SqlCommand command = new SqlCommand("add_class", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@class_name", SqlDbType.NVarChar).Value = str_class_name;
            command.Parameters.Add("@teacher_name", SqlDbType.NVarChar).Value = str_teacher_name;


            connection.Open();

            command.ExecuteReader();

            connection.Close();
        }
        //update class name and teacher name
        protected void update_class_data(object sender, EventArgs e)
        {
            try
            {
                //get class id for update
                int id_class = get_id_class();
                //update by id
                if (update_class_by_id(id_class))
                    Response.Redirect("show_classes.aspx");
            }
            catch (Exception ex)
            { 

                throw ex;
            }
        
           
        }

        private bool update_class_by_id(int id_class)
        {
            try
            {

                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                string str_class_name = help_methods.escape_char(txt_class_name.Text.Trim());
                string str_teacher_name = help_methods.escape_char(txt_teacher_name.Text.Trim());
                //check if class does not exist in data base
                if (!is_class_exists(str_class_name))
                    Response.Write("<script language=javascript>alert('The class you have chosen does not exist');</script>");
                else//ok for update
                {
                    update_class(id_class);
                    return true;
                }

                return false;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //update class calling stored procedure
        private void update_class(int id_class)
        {
            try
            {

                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                string str_class_name = help_methods.escape_char(txt_class_name.Text.Trim());
                string str_teacher_name = help_methods.escape_char(txt_teacher_name.Text.Trim());

                SqlCommand command = new SqlCommand("update_class", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@class_name", SqlDbType.NVarChar).Value = str_class_name;
                command.Parameters.Add("@teacher_name", SqlDbType.NVarChar).Value = str_teacher_name;
                command.Parameters.Add("@id_class", SqlDbType.Int).Value = id_class;
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private int get_id_class()
        {
            SqlConnection connection = new SqlConnection(help_methods.conn_string);
            int id_class = 0;

            string class_name = help_methods.escape_char(txt_class_name.Text);

            string sql = "select id_class from class where class_name = N'" + class_name + "'";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id_class = reader.GetInt32(0);
            }


            connection.Close();
            return id_class;
        }


        bool is_class_exists(string class_name)
        {

            bool flg = false;
            SqlConnection connection = new SqlConnection(help_methods.conn_string);

            string sql = " select count(*) from Class where class_name = N'" + class_name + "'";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            { 
                if (reader.GetInt32(0) > 0)
                    flg = true;
            }
           

            connection.Close();
            return flg;
        }
    }
}