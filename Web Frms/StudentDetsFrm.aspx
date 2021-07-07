<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetsFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.StudentDetsFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .Decors 
            {
                text-decoration: none
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
            <h2>Students</h2>
        </div>
        <legend style="margin-top:20px; margin-left: 120px;">Subjects Details
        <asp:HyperLink ID="lCreate" runat="server" style="margin-left: 12px; text-decoration: none" 
        NavigateUrl="~/Web Frms/StudentFrm.aspx">Create New</asp:HyperLink>
        </legend>
        <div style="margin-top:20px; margin-left: 120px;">
            <asp:GridView ID="GridView1" runat="server" Width="1150px" CellPadding="5" AutoGenerateColumns="false" GridLines="None"> 
                <Columns>
                    
                    <asp:BoundField DataField="StudentID" HeaderText="Subject ID" 
                    SortExpression="StudentID" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="FullName" HeaderText="Full Name" 
                    SortExpression="FullName" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" 
                    SortExpression="ContactNo" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Email" HeaderText="Email" 
                    SortExpression="Email" >
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:HyperLinkField ControlStyle-CssClass="Decors" Text="Edit" DataNavigateUrlFields="StudentID,ContactNo,Address,Email,FullName"           
                    DataNavigateUrlFormatString="UpdateStudentFrm.aspx?StudentID={0}&ContactNo={1}&Address={2}&Email={3}&FullName={4}" >
                    <HeaderStyle HorizontalAlign="Right"/>
                    </asp:HyperLinkField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton style="text-decoration: none" ID="lDelete" runat="server" CommandArgument='<%# Eval("StudentID") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 150px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
