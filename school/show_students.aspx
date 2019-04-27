<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show_students.aspx.cs" Inherits="school.show_students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/show_students_script.js"></script>
    <link href="css/css_show_students.css" rel="stylesheet" />
    <title>Show students in class</title>
</head>
<body>
    <button onclick="go_to_main_page()" class="btn-link main_page_link">Back to main page</button>
    <form id="form1" runat="server">
        <asp:GridView ID="gridStudents" runat="server" CssClass="mydatagrid" 
            PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
            HorizontalAlign="Center" VerticalAlign="Center" AllowPaging="True" 
            AutoGenerateColumns="false">
        <Columns>
           <asp:BoundField DataField="first_name" HeaderText="First name" ItemStyle-HorizontalAlign="Center"  />
            <asp:BoundField DataField="last_name" HeaderText="Last name" ItemStyle-HorizontalAlign="Center"  />
            <asp:BoundField DataField="age" HeaderText="Age" ItemStyle-HorizontalAlign="Center"  />
            <asp:BoundField DataField="class_name" HeaderText="Class" ItemStyle-HorizontalAlign="Center"  />
        </Columns>
        </asp:GridView>
        <asp:Button ID="btn_show_students" runat="server" OnClick="btn_show_students_Click" Text="show students" 
            CssClass="show_students" />
        <asp:DropDownList ID="drop_classes" runat="server" CssClass="classes" >
        </asp:DropDownList>
    </form>
</body>
</html>
