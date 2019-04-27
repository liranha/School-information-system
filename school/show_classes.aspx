<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show_classes.aspx.cs" Inherits="school.show_classes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="css/css_show_classes.css" rel="stylesheet" />
    <script src="js/show_classes_script.js"></script>
    <title>Show classes</title>
</head>
<body>
    <button onclick="go_to_main_page()" class="main_page_link">Back to main page</button>
    <form id="form1" runat="server">
        <asp:GridView ID="gridClasses" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
        <Columns>
            <asp:BoundField DataField="class_name" HeaderText="Class name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="teacher_name" HeaderText="Teacher name"  ItemStyle-HorizontalAlign="Center" />
        </Columns>
        </asp:GridView>
    </form>
</body>
</html>
