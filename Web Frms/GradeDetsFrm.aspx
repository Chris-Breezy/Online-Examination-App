<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeDetsFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.GradeDetsFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .Decor 
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
        <h2>Grades</h2>
        <asp:HyperLink style="text-decoration: none;" ID="lCreate" runat="server"  
        NavigateUrl="~/Web Frms/GradeFrm.aspx">Create New</asp:HyperLink>
        </div>

        <div style="margin-left: 120px; margin-top:20px;">
                <asp:GridView ID="GridView1" CellPadding="5" AutoGenerateColumns="False" runat="server" Width="800px" DataKeyNames="GradeID" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="GradeID" HeaderText="Grade ID" 
                            SortExpression="GradeID" >
                        <HeaderStyle HorizontalAlign="Left" Width="130px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Grade" HeaderText="Grade" 
                            SortExpression="Grade" >
                        <HeaderStyle HorizontalAlign="Left" Width="130px" />
                        </asp:BoundField>

                        <asp:HyperLinkField ControlStyle-CssClass="Decor" Text="Edit" DataNavigateUrlFields="GradeID,Grade"         
                            DataNavigateUrlFormatString="UpdateGradeFrm.aspx?GradeID={0}&Grade={1}" >
                        <HeaderStyle HorizontalAlign="Right" Width="30px" />
                        </asp:HyperLinkField>
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton style="text-decoration: none;" ID="lDelete" runat="server" CommandArgument='<%# Eval("GradeID") %>' OnClick="lDelete_OnClick" >Delete</asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
