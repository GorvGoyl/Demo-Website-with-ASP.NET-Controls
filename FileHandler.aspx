<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileHandler.aspx.cs" Inherits="FileHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 290px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

<%--    <asp:scriptmanager id="ScriptManager2" runat="server">
 </asp:scriptmanager>
 
<asp:updatepanel id="up2" runat="server" >
  <contenttemplate>--%>
   

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="ButtonUpload" runat="server" onclick="ButtonUpload_Click" 
        Text="Upload" Width="86px" />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
  
&nbsp;<table class="style1">
        <tr>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                    CellPadding="3" CellSpacing="1" GridLines="None" Height="204px" 
                    onrowcommand="GridView1_RowCommand" Width="516px">
                    <Columns>
                        <asp:TemplateField HeaderText="File">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Eval("File") %>' CommandName="Download" 
                                    Text='<%# Eval("File") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Size" HeaderText="Size in Bytes" />
                        <asp:BoundField DataField="Type" HeaderText="File Types" />
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
            <td class="style2">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
           <!-- Your code here -->
 <%-- </contenttemplate>
  <Triggers>
       <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
   </Triggers>
</asp:updatepanel>--%>
    </form>
</body>
</html>
