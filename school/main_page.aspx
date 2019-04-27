<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_page.aspx.cs" Inherits="school.main_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link href="css/css_main.css" rel="stylesheet" />
    <title>School management</title>
</head>
<body>
    <form id="form1" runat="server" class="form_routing">       
        <asp:Button ID="btn_change_students" runat="server" Text="add\update student" 
            OnClick="change_students" CssClass="btn btn-info add_update_student" />
        <asp:Button ID="btn_change_classes" runat="server" Text="add\update class"
            OnClick="change_classes" CssClass="btn btn-info add_update_class" />
        <asp:Button ID="btn_show_students" runat="server" Text="show students" 
            OnClick="show_students"  CssClass="btn btn-info show_students" />
        <asp:Button ID="btn_show_classes" runat="server" Text="show classes" 
            OnClick="show_classes" CssClass="btn btn-info show_classes" />
    </form>
</body>
</html>
