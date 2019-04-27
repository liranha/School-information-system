<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change_students.aspx.cs" Inherits="school.change_students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <script src="js/change_student_script.js"></script>
    <link href="css/css_change_student.css" rel="stylesheet" />
    <title>Change students</title>
</head>
<body>
    <button onclick="go_to_main_page()" class="btn-link main_page_link">Back to main page</button>
    <form id="form1" runat="server" class="form_change_student">
            <label> Id number:</label>
            <asp:TextBox ID="txt_student_id" runat="server" CssClass="text-info id_number"></asp:TextBox>
            <br /><br />
            <label> First name:</label>
            <asp:TextBox ID="txt_student_first_name" runat="server" CssClass="text-info first_name"></asp:TextBox>
            <br /><br />
            <label> Last name:</label>
            <asp:TextBox ID="txt_student_last_name" runat="server" CssClass="text-info last_name"></asp:TextBox>
            <br /><br />
            <label> Age:</label>
            <asp:TextBox ID="txt_age" runat="server" CssClass="text-info age_pos" ></asp:TextBox>
            <br /><br />
            <label> Class:</label>
            <asp:DropDownList ID="drop_class_name" runat="server" CssClass="text-info class_pos"></asp:DropDownList>
            <br /><br /><br />
            <asp:Button ID="btn_add_student" runat="server" Text="Add student" 
                OnClick="add_student_data" CssClass="btn_add"/>
            <br /><br /><br />
            <asp:Button ID="btn_update_student" runat="server" Text="Update student" 
                OnClick="update_student_data" CssClass="btn_update" />
    </form>
</body>
</html>
