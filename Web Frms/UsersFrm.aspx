<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.UsersFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvGrid 
        {
            background-color: #FFEB9C;
            border-top: solid;
            color: #9C6500;
        }            
        .Decs 
        {
            text-decoration: none;
        }
    </style>
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
            <h2>Users</h2>
        </div>
            <legend style="margin-top:20px; margin-left: 120px;">Users Details
            <asp:HyperLink ID="lCreate" runat="server" style="margin-left: 12px; text-decoration: none" 
            NavigateUrl="~/Web Frms/AddUserFrm.aspx">Create New</asp:HyperLink>
            </legend>
            
        <div style="margin-top:20px; margin-left: 120px;">
            <asp:GridView ID="GridView1" CellPadding="5" AutoGenerateColumns="False" runat="server" 
                Width="1000px" DataKeyNames="UserID" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" 
                        SortExpression="UserID" >
                        <HeaderStyle HorizontalAlign="Left" Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Username" HeaderText="Username" 
                        SortExpression="Username" >
                        <HeaderStyle HorizontalAlign="Left" Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Password" HeaderText="Password" 
                        SortExpression="Password" >
                        <HeaderStyle HorizontalAlign="Left" Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" 
                        SortExpression="StudentID" >
                        <HeaderStyle HorizontalAlign="Left" Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Student" HeaderText="Student" 
                        SortExpression="FullName" >
                        <HeaderStyle HorizontalAlign="Left" Width="350px" />
                        </asp:BoundField>
                        <asp:HyperLinkField ControlStyle-CssClass="Decs" Text="Edit" DataNavigateUrlFields="UserID,Student,Username,StudentID" 
                        DataNavigateUrlFormatString="UpdateUserFrm.aspx?UserID={0}&Student={1}&Username={2}&StudentID={3}" />
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton style="text-decoration: none" ID="lDelete" runat="server" CommandArgument='<%# Eval("UserID") %>' OnClick="lDelete_OnClick">Delete</asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>

                        </Columns>
                        </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:Online_ExamConnectionString %>" 
                                SelectCommand="SELECT * FROM [tblUser]"></asp:SqlDataSource>
        </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 150px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
