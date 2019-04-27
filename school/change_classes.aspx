<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/change_classes.aspx.cs" Inherits="school.change_classes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
      <script src="js/change_class_script.js"></script>
    <link href="css/css_change_class.css" rel="stylesheet" />
    <title>Change class</title>
   
</head>
<body>
    <button onclick="go_to_main_page()" class="btn-link main_page_link">Back to main page</button>
    <form id="form1" runat="server" class="form_change_class">
        <div>
            <label> Class name:</label>
            <asp:TextBox ID="txt_class_name" runat="server" CssClass="text-info class_name"></asp:TextBox>
            <br /><br />
            <label> Teacher name:</label>
            <asp:TextBox ID="txt_teacher_name" runat="server" CssClass="text-info teacher_name" ></asp:TextBox>
             <br /><br />
            <asp:Button ID="btn_add_class" runat="server" Text="Add class" OnClick="add_class_data" CssClass="btn-default btn_add"/>
             <br /><br />
            <asp:Button ID="btn_update_class" runat="server" Text="Update class" OnClick="update_class_data" CssClass=" btn-default btn_update"/>
        </div>
        
    </form>
</body>
</html>
