using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace school
{
    public partial class main_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void change_students(object sender, EventArgs e)
        {
            Response.Redirect("change_students.aspx");
        }

        protected void change_classes(object sender, EventArgs e)
        {
            Response.Redirect("change_classes.aspx");
        }

        protected void show_students(object sender, EventArgs e)
        {
            Response.Redirect("show_students.aspx");
        }

        protected void show_classes(object sender, EventArgs e)
        {
            Response.Redirect("show_classes.aspx");
        }
    }
}