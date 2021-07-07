<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenuFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.AdminMenuFrm" %>

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
                        <li><a href="">Home</a></li>
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
                    <li><a href="">Contacts</a></li>
                    <li><asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Web Frms/MainFrm.aspx">Log Out</asp:HyperLink></li>
                </ul>
        </nav>
    </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 530px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
