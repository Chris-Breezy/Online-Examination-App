<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.IndexFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .Quizers 
            {
                margin-left: 50px;
            }
            .Dtl 
            {
                margin-left: 1050px;
            }
            .dDown 
            {
                border-top-style: none;
                border-right-style: none;
                border-bottom-style: none;
                border-bottom-style: none;
            }
            .lCorrect 
            {
                padding-bottom: 1em;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
            <ul style="margin-left: 120px; text-align: left;">
                <asp:Label ID="Label5" runat="server" Text="Online Examination Program"></asp:Label>
                <li><a href="">Home</a></li>
                <li><a href="">Stats</a></li>
                <li><asp:Label ID="lUser" runat="server" Text="Welcome:/"></asp:Label></li>
                <li><asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Web Frms/MainFrm.aspx">Log Out</asp:HyperLink></li>
                <%--<li style="margin-left: 510px;"></li>--%>   
            </ul>
            </nav>
        </div>

    <%--<div>        
        <center>
            <asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" 
                Visible="False" />
            <asp:Label CssClass="Dtl" ID="lblTime" Visible="false" Font-Bold="true" runat="server" Text=""></asp:Label>
        </center>
    </div>--%>

    <div style="margin-left: 120px;">
        <h2>Questions</h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="School Year:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSchoolYear" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" onselectedindexchanged="cbSchoolYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="Label2" runat="server" Text="Grade:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbGrade" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" onselectedindexchanged="cbGrade_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="Label3" runat="server" Text="Section:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSec" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" Enabled="false" onselectedindexchanged="cbSec_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="Label4" runat="server" Text="Subject:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSubject" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" Enabled="false" onselectedindexchanged="cbSubject_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <fieldset style="width:400px">
                        <legend><b>Quarters</b></legend>
                            <asp:RadioButton ID="rd1" Enabled="false" Text="Quarter 1" runat="server" 
                            oncheckedchanged="RadioButton1_CheckedChanged" AutoPostBack="True" 
                            GroupName="Chupapi" /> 
                            <asp:RadioButton ID="rd2" Enabled="false" Text="Quarter 2" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" oncheckedchanged="rd2_CheckedChanged" />
                            <asp:RadioButton ID="rd3" Enabled="false" Text="Quarter 3" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" oncheckedchanged="rd3_CheckedChanged" />
                            <asp:RadioButton ID="rd4" Enabled="false" Text="Quarter 4" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" oncheckedchanged="rd4_CheckedChanged" />
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    
    <div style="margin-left:120px; margin-top:15px;">
        <asp:Label ID="lCode" runat="server" Text=""></asp:Label>    
        <asp:Label ID="lDesc" runat="server" Text=""></asp:Label>
        <asp:Label ID="lTotScore" runat="server" Text=""></asp:Label>
        <asp:Label style="margin-left:8px;" ID="lCorrect" runat="server" Text=""></asp:Label>
        <asp:Label style="margin-left:8px;" ID="lIncorrect" runat="server" Text=""></asp:Label>
        <asp:Label style="margin-left:8px;" ID="lRemarks" runat="server" Text=""></asp:Label>
        <asp:Label style="margin-left:8px;" ID="lStudID" runat="server" Text=""></asp:Label>
        <asp:Label style="margin-left:8px;" ID="lExamTaken" runat="server" Text=""></asp:Label>
        <asp:Label ID="lItems" Font-Size="12" runat="server" Text=""></asp:Label>    
        <asp:Button style="margin-left: 8px; height: 26px;" ID="bTake" runat="server" 
            Visible="false" Width="118px" Text="Go" 
        onclick="bTake_Click" />                
    </div>

    <div style="margin-left: 120px; margin-top: 15px;">
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td><b><%#Eval("QuestionNo") %> : <%#Eval("Question") %></b></td>
                        <%--<td><%#Eval("QuestionNo") %> : <%#Eval("Question") %></td>--%>
                    </tr>
                    <tr>    
                        <td>
                            <asp:RadioButton ID="rOption1" runat="server" Text='<%#Eval("Option1") %>' GroupName="rdexam"></asp:RadioButton>
                            <asp:RadioButton ID="rOption2" runat="server" Text='<%#Eval("Option2") %>' GroupName="rdexam"></asp:RadioButton>
                            <asp:RadioButton ID="rOption3" runat="server" Text='<%#Eval("Option3") %>' GroupName="rdexam"></asp:RadioButton>
                            <asp:RadioButton ID="rOption4" runat="server" Text='<%#Eval("Option4") %>' GroupName="rdexam"></asp:RadioButton>
                            <br />
                            <asp:Label ID="lCorrectAns" runat="server" Text='<%#Eval("Corrections") %>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-bottom: 1em;">
                            <asp:Label ID="lUserSelectedOption" runat="server" Text=""></asp:Label> 
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button style="margin-top: 20px;" ID="bSubmit" Visible="false" runat="server" Text="Submit" 
            Width="118px" onclick="bSubmit_Click" />
        <asp:Label style="margin-left: 5px;" ID="lSave" runat="server" ForeColor="Green" Text=""></asp:Label>
        <asp:Button style="margin-top: 20px; height: 26px;" ID="Button1" runat="server" Text="Button" 
            onclick="Button1_Click" Visible="False" />

    </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
            <%--<p style="font-size: 12px; margin-left: 120px; margin-top: 300px;">@ 2020-2021 - My Online Exam Application</p>--%>
        </div>
</body>
</html>
