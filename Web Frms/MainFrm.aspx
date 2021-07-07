<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.MainFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
    
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <nav>
            <ul style="margin-left: 120px; text-align: left;">
                <asp:Label ID="Label5" runat="server" Text="Online Examination Program"></asp:Label>
                <li><a href="">Home</a></li>
                <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Web Frms/SignFrm.aspx">Sign In</asp:HyperLink></li>
                <%--<li style="margin-left: 510px;"></li>--%>   
            </ul>
            </nav>
    </div>

    </form>
        <div>
            <p style="font-size: 12px; margin-left: 108px; margin-top: 400px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
    

</html>
