<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lesson5_2.aspx.cs" Inherits="Lesson5_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 254px">
    <form id="form1" runat="server">
    <div>
    
    </div>
       
        <asp:TextBox ID="txtInput" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="btmSubmit" runat="server" OnClick="Button1_Click" Text="下一頁" Font-Size="Large" />
        <p>
        <asp:Image ID="Image2" runat="server" />
        <asp:Image ID="Image3" runat="server" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
