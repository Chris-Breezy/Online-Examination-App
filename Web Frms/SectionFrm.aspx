<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.SectionFrm" %>

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
                    <li><asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Web Frms/MainFrm.aspx">Log Out</asp:HyperLink></li>
                </ul>
        </nav>
    </div>
        <div style="margin-left: 120px;">
            <h2>Sections</h2>
        </div>
        <fieldset style="margin-top:20px; margin-left: 120px; width:700px; height:250px;">
            <legend>Create Section</legend>
            <div style="margin-left: 60px; margin-top:30px;">
                <label><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Section ID:</span>
                    <asp:TextBox ID="tID" runat="server"></asp:TextBox>
                </label>
                <br />
                <label><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Section:</span>	
                    <asp:TextBox ID="tSection" runat="server"></asp:TextBox>
	            </label>
                <br />
                <label><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">School Year:</span>
                    <asp:DropDownList ID="cbYear" Height="20px" Width="177px" runat="server">
                    </asp:DropDownList>	
	            </label>
                <br />
                <label><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Grade:</span>	
                    <asp:DropDownList ID="cbGrade" Height="20px" Width="177px" runat="server">
                    </asp:DropDownList>
	            </label>
                <asp:Label ID="lSave" ForeColor="Red" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button style="margin-left:104px;" ID="bSave" runat="server" Text="Create" 
                    onclick="bSave_Click" />

            </div>
        </fieldset>

        <div style="margin-left: 120px; margin-top: 30px;">
            <asp:HyperLink style="text-decoration: none;" ID="lBack" runat="server" NavigateUrl="~/Web Frms/SectionDetsFrm.aspx">Back</asp:HyperLink>
        </div>

    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
