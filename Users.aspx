﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label_welcome" runat="server" Text="Welcome ... "></asp:Label>
    <div>
    
        <asp:Button ID="Button_Logout" runat="server" onclick="Button_Logout_Click" 
            Text="Logout" />
    
    </div>
    </form>
</body>
</html>
