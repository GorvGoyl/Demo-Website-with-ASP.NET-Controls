<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style18">
        <strong>Registration Page</strong></div>
    <table class="style1">
        <tr>
            <td class="style15">
                User Name:
            </td>
            <td class="style16">
                <asp:TextBox ID="TextBox_Username" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style15">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_Username"
                    ErrorMessage="User Name is required" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                &nbsp;<br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Username"
                    ErrorMessage="This Username is not Allowed" ForeColor="#FF3300" 
                    ValidationExpression="^[a-zA-Z0-9](_(?!(\.|_))|\.(?!(_|\.))|[a-zA-Z0-9]){1,18}[a-zA-Z0-9]$" 
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style11">
                Email:
            </td>
            <td class="style17">
                <asp:TextBox ID="TextBox_Email" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style11">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Email"
                    ErrorMessage="E-Mail is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                &nbsp;
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="TextBox_Email"
                    ErrorMessage=" Enter valid E-Mail ID" ForeColor="#FF3300" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style7">
                Password:
            </td>
            <td class="style21">
                <asp:TextBox ID="TextBox_Password" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
            </td>
            <td class="style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_Password"
                    ErrorMessage="Password is required" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                &nbsp;<br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_Password"
                    ErrorMessage="Password length must be greater than 2" ForeColor="#FF3300" 
                    ValidationExpression="^[a-zA-Z0-9'@ &amp;#.\s]{2,20}$" Display="Dynamic"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style13">
                Confirm Password:
            </td>
            <td class="style19">
                <asp:TextBox ID="TextBox_RePassword" runat="server" TextMode="Password" Width="180px"
                    OnTextChanged="TextBox_RePassword_TextChanged"></asp:TextBox>
            </td>
            <td class="style13">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_RePassword"
                    ErrorMessage="Confirm Password is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                &nbsp;<br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox_Password"
                    ControlToValidate="TextBox_RePassword" 
                    ErrorMessage="Password didn't match" ForeColor="#FF3300" Display="Dynamic"></asp:CompareValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style14">
                Country:
            </td>
            <td class="style20">
                <asp:DropDownList ID="DropDownListCountry" runat="server" Width="180px" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged">
                    <asp:ListItem>Select Country</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>UK</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>North Korea</asp:ListItem>
                    <asp:ListItem>Kazakhstan</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style14">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListCountry"
                    ErrorMessage="Country is required" ForeColor="#FF3300" InitialValue="Select Country"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style10">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style10">
                <asp:Button ID="Button_Submit" runat="server" OnClick="Button_Submit_Click" Text="Submit"
                    Width="87px" />
                <input id="Reset1" type="reset" value="reset" onclick="return Reset1_onclick()" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style6">
            </td>
            <td class="style17">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login Page</asp:HyperLink>
            </td>
            <td class="style8">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Manager.aspx">Manager Page</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #Reset1
        {
            width: 56px;
        }
        .style3
        {
            height: 73px;
        }
        .style6
        {
            height: 70px;
        }
        .style7
        {
            height: 48px;
        }
        .style8
        {
            height: 42px;
        }
        .style10
        {
            height: 44px;
            width: 239px;
        }
        .style11
        {
            height: 45px;
        }
        .style13
        {
            height: 46px;
        }
        .style14
        {
            height: 54px;
        }
        .style15
        {
            height: 43px;
        }
        .style16
        {
            height: 43px;
            width: 239px;
        }
        .style17
        {
            height: 45px;
            width: 239px;
        }
        .style18
        {
            height: 48px;
            width: 319px;
        }
        .style19
        {
            height: 46px;
            width: 239px;
        }
        .style20
        {
            height: 54px;
            width: 239px;
        }
        .style21
        {
            height: 48px;
            width: 239px;
        }
    </style>
</asp:Content>
