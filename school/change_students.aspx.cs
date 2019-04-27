using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace school
{
    public partial class change_students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //when page loading, init drop down of all classes
            DataTable dt = new DataTable();
            dt = DAL.get_all_classes();
            foreach (DataRow row in dt.Rows)
            {
                {
                    string tmp_item = Convert.ToString(row[1]);
                    if (drop_class_name.Items.FindByValue(tmp_item) == null)
                        drop_class_name.Items.Add(Convert.ToString(row[1]));
                }
            }
        }
        //adding new student
        protected void add_student_data(object sender, EventArgs e)
        {
            try
            {
                string str_first_name = help_methods.escape_char(txt_student_first_name.Text.Trim());
                string str_last_name = help_methods.escape_char(txt_student_last_name.Text.Trim());
                string str_class_name = help_methods.escape_char(drop_class_name.Text.Trim());
                string str_id_student = help_methods.escape_char(txt_student_id.Text.Trim());
                string str_age = help_methods.escape_char(txt_age.Text.Trim());

                //validate float age
                if (!help_methods.is_numeric_float(str_age))
                    Response.Write("<script language=javascript>alert('The age is not numeric');</script>");
                else
                {
                    if (is_student_exists(str_id_student))
                        Response.Write("<script language=javascript>alert('The student you have chosen already exists');</script>");
                    else// ok for insert
                    {
                        insert_student(str_first_name, str_last_name, str_class_name, str_age, str_id_student);
                        Response.Redirect("show_students.aspx");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            }
        //insert student by calling stored procedure
        private void insert_student(string first_name, string last_name, string class_name, string age, string id_student)
        {
            try
            {
                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                SqlCommand command = new SqlCommand("add_student", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@id_number", SqlDbType.NVarChar).Value = id_student;
                command.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = first_name;
                command.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = last_name;
                command.Parameters.Add("@class_name", SqlDbType.NVarChar).Value = class_name;
                command.Parameters.Add("@age", SqlDbType.Float).Value = age;

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();



                
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
        //check if student exists in data base
        private bool is_student_exists(string id_student)
        {
            try
            {
                bool flg = false;
                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                string sql = " select count(*) from Student where id_student_number = N'" + id_student + "'";

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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //update all fields of student
        protected void update_student_data(object sender, EventArgs e)
        {
            try
            {
                //get id of studewnt from db
                string id_student = get_id_student();
                //update student
                if (update_student_by_id(id_student))
                    Response.Redirect("show_students.aspx");
    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool update_student_by_id(string id_student)
        {
            try
            {
                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                string str_first_name = help_methods.escape_char(txt_student_first_name.Text.Trim());
                string str_last_name = help_methods.escape_char(txt_student_last_name.Text.Trim());
                string str_class_name = help_methods.escape_char(drop_class_name.Text.Trim());
                string str_id_student = help_methods.escape_char(txt_student_id.Text.Trim());
                string str_age = help_methods.escape_char(txt_age.Text.Trim());

                if (!help_methods.is_numeric_float(str_age))
                    Response.Write("<script language=javascript>alert('The age is not numeric');</script>");
                else if (!is_student_exists(str_id_student))
                    Response.Write("<script language=javascript>alert('The student you have chosen does not exist');</script>");
                else//ok for update
                {
                    update_student(id_student);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //update student parameters by using stored procedure
        private void update_student(string id_student)
        {
            try
            {
                SqlConnection connection = new SqlConnection(help_methods.conn_string);

                string str_first_name = help_methods.escape_char(txt_student_first_name.Text.Trim());
                string str_last_name = help_methods.escape_char(txt_student_last_name.Text.Trim());
                string str_class_name = help_methods.escape_char(drop_class_name.Text.Trim());
                string str_age = help_methods.escape_char(txt_age.Text.Trim());
                string str_id_student_number = help_methods.escape_char(txt_student_id.Text.Trim());

                SqlCommand command = new SqlCommand("update_student", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = str_first_name;
                command.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = str_last_name;
                command.Parameters.Add("@class_name", SqlDbType.NVarChar).Value = str_class_name;
                command.Parameters.Add("@age", SqlDbType.Float).Value = str_age;
                command.Parameters.Add("@id_student_number", SqlDbType.NVarChar).Value = str_id_student_number;
                command.Parameters.Add("@id_student", SqlDbType.Int).Value = id_student;
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string get_id_student()
        {
            SqlConnection connection = new SqlConnection(help_methods.conn_string);
           
            string str_id_student = help_methods.escape_char(txt_student_id.Text.Trim());
      

            int id_student = 0;


            string sql = "select id_student from student where id_student_number = N'" + str_id_student + "'";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                id_student = reader.GetInt32(0);
            }


            connection.Close();
            return Convert.ToString(id_student);
        }
    }
}