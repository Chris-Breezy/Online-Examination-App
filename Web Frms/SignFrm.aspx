<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.SignFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar">
        <nav>
            <ul style="margin-left: 120px; text-align: left;">
                <asp:Label ID="Label5" runat="server" Text="Online Examination Program"></asp:Label>
                <li><a href="">Home</a></li>
                <li><a href="">Stats</a></li>
                <%--<li style="margin-left: 510px;"></li>--%>   
            </ul>
            </nav>
    </div>
    <div>
    <center>
        <fieldset style="margin-top:140px; width:300px; height:200px;">
        <legend><b>Sign In</b></legend>
        <table style="margin-top:50px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox ID="tUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox ID="tPass" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:CheckBox ID="ckShow" Text="Show Pass:" runat="server" AutoPostBack="True" 
                        oncheckedchanged="ckShow_CheckedChanged" />
                </td>
            </tr>
            <tr>
                
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="bEnter" runat="server" Text="Sign In" Width="78px" 
                        onclick="bEnter_Click" />
                </td>
                
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lError" runat="server" Text=""></asp:Label> 
                </td>
            </tr>
        </table>
    </fieldset>    
    </center>
    
    </div>
    </form>
</body>
</html>
