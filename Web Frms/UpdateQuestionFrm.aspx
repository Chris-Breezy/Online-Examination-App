<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateQuestionFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.UpdateQuestionFrm" %>

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
                <ul style="margin-left: 120px;">
                        <asp:Label ID="Label5" runat="server" Text="Onlne Exam"></asp:Label>
                        <li><a href="AdminMenuFrm.aspx">Home</a></li>
                    <li class="sub">
                    <a href="">Master Files</a>
                            <ul>
                                <li><a href="UsersFrm.aspx">Add User</a></li>
                                <li><a href="SchoolYearDets.aspx">School Year</a></li>
                                <li><a href="StudentDetsFrm.aspx">Students</a></li>
                                <li><a href="SubjectDetsFrm.aspx">Subjects</a></li>
                                <li><a href="GradeDetsFrm.aspx">Grades</a></li>
                                <li><a href="SectionDetsFrm.aspx">Sections</a></li>
                                <li><a href="ExamRecordsFrm.aspx">Exam Results</a></li>
                            </ul>
                        </li>
                    <li><a href="QuestionaireDetsFrm.aspx">Questions</a></li>
                    <li><a href="AdminMenuFrm.aspx">Contacts</a></li>
                    <li><asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="~/Web Frms/MainFrm.aspx">Log Out</asp:HyperLink></li>
                </ul>
        </nav>
    </div>
        
        <div style="margin-left: 120px;">
        <h2>Questionaire</h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="School Year:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSchoolYear" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="cbSchoolYear_SelectedIndexChanged">
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
                    <asp:DropDownList ID="cbSec" runat="server" Enabled="false" Height="19px" 
                        Width="160px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Subject:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSubj" runat="server" Enabled="false" Height="19px" 
                        Width="160px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                <fieldset style="width:350px; height:35px;">
                    <legend><b>Quarters</b></legend>            
                    <asp:RadioButton ID="rd1" Text="Quarter 1" Enabled="true" GroupName="RadioButts" runat="server" Checked="False" />
                    <asp:RadioButton ID="rd2" Text="Quarter 2" Enabled="true" GroupName="RadioButts" runat="server" Checked="False" />
                    <asp:RadioButton ID="rd3" Text="Quarter 3" Enabled="true" GroupName="RadioButts" runat="server" Checked="False" />
                    <asp:RadioButton ID="rd4" Text="Quarter 4" Enabled="true" GroupName="RadioButts" runat="server" Checked="False" />
                </fieldset>
                </td>
            </tr>
        </table>
    </div>
    
    <fieldset style="margin-top:20px; margin-left: 120px; width:600px; height:320px;">
        <legend><b>Update Questionaire</b></legend>
        
        <div style="display: block; margin-top: 20px;">
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Question ID:</span> 
        <asp:TextBox ID="tID" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lID" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />

            <label class="label"><span style="display:inline-block; padding-bottom: 0.2em; text-align:right; width:100px;">Question:</span> 
        <asp:TextBox ID="tQuestion" runat="server" Height="54px" TextMode="MultiLine" 
                Width="259px"></asp:TextBox>
        </label>
            <asp:Label ID="lQuestion" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Option 1:</span> 
        <asp:TextBox ID="tOp1" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lOpt1" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Option 2:</span> 
        <asp:TextBox ID="tOp2" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lOpt2" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Option 3:</span> 
        <asp:TextBox ID="tOp3" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lOpt3" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Option 4:</span> 
        <asp:TextBox ID="tOp4" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lOpt4" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
        <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Corrections:</span> 
        <asp:TextBox ID="tCorrect" runat="server"></asp:TextBox>
        </label>
            <asp:Label ID="lCorrect" ForeColor="Red" runat="server" Text=""></asp:Label>
        <br />
            <span style="display:inline-block; margin-left: 104px;">
                <asp:Button ID="bSave" runat="server" Text="Save" 
                Width="87px" Height="30px" onclick="bSave_Click" />    
            </span>
            
            <asp:Label ID="lblSave" CssClass="Lebel" ForeColor="Green" runat="server" Text=""></asp:Label>
    </div>    
    </fieldset>

    <div style="margin-left: 120px; margin-top: 30px;">
        <asp:HyperLink style="text-decoration: none;" ID="HyperLink1" runat="server" 
        NavigateUrl="~/Web Frms/QuestionaireDetsFrm.aspx" Visible="true">Go Back</asp:HyperLink>
    </div>



    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
