using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace school
{
    public partial class show_students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAL.get_all_classes();
            foreach (DataRow row in dt.Rows)
            {
                {
                    string tmp_item = Convert.ToString(row[1]);
                    if (drop_classes.Items.FindByValue(tmp_item) == null)
                        drop_classes.Items.Add(Convert.ToString(tmp_item));
                }
            }
            //when page is loading no need in the grid view. the user need to choose the class first
            gridStudents.Visible = false;

        }

        protected void btn_show_students_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAL.get_all_students_in_class(drop_classes.SelectedValue);
            gridStudents.DataSource = dt;
            gridStudents.DataBind();
            //after the user chose class, all studnets will be presented in the grid
            gridStudents.Visible = true;
        }

        protected void drop_classes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}