<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamRecordsFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.ExamRecordsFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 37px;
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
        <h2>Exam Records</h2>
            <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Student ID:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbID" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" onselectedindexchanged="cbID_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="Label2" runat="server" Text="Student Name:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbNym" runat="server" Height="19px" Width="300px" 
                        AutoPostBack="True" onselectedindexchanged="cbNym_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 120px;">
        <table>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server" Text="School Year:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSchoolYear" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="cbSchoolYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td class="style1">
                    <asp:Label ID="Label4" runat="server" Text="Grade:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbGrade" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" onselectedindexchanged="cbGrade_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td class="style1">
                    <asp:Label ID="Label6" runat="server" Text="Section:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSec" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" Enabled="false" 
                        onselectedindexchanged="cbSec_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

                <td class="style1">
                    <asp:Label ID="Label7" runat="server" Text="Subject:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbSubject" runat="server" Height="19px" Width="160px" 
                        AutoPostBack="True" Enabled="false" 
                        onselectedindexchanged="cbSubject_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <fieldset style="width:400px">
                        <legend><b>Quarters</b></legend>
                            <asp:RadioButton ID="rd1" Enabled="false" Text="Quarter 1" runat="server" 
                             AutoPostBack="True" GroupName="Chupapi" 
                            oncheckedchanged="rd1_CheckedChanged" /> 
                            <asp:RadioButton ID="rd2" Enabled="false" Text="Quarter 2" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" 
                            oncheckedchanged="rd2_CheckedChanged" />
                            <asp:RadioButton ID="rd3" Enabled="false" Text="Quarter 3" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" 
                            oncheckedchanged="rd3_CheckedChanged" />
                            <asp:RadioButton ID="rd4" Enabled="false" Text="Quarter 4" runat="server" 
                            AutoPostBack="True" GroupName="Chupapi" 
                            oncheckedchanged="rd4_CheckedChanged"  />
                    </fieldset>
                </td>
            </tr>
        </table>       
    </div>

    <div style="margin-top:20px; margin-left: 120px;">
        <asp:GridView ID="gvDisp" runat="server" Width="1300px" CellPadding="5" 
                AutoGenerateColumns="False" GridLines="None">
               <Columns>
                    <asp:BoundField DataField="ResultNo" HeaderText="Result No" 
                    SortExpression="ResultNo" >
                    <HeaderStyle HorizontalAlign="Left" Width="120px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Student" HeaderText="Student" 
                    SortExpression="Student" >
                    <HeaderStyle HorizontalAlign="Left" Width="240px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Score" HeaderText="Score" 
                    SortExpression="Score" >
                    <HeaderStyle HorizontalAlign="Left" Width="90px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Correct" HeaderText="Correct" 
                    SortExpression="Correct" >
                    <HeaderStyle HorizontalAlign="Left" Width="90px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Incorrect" HeaderText="Incorrect" 
                    SortExpression="Incorrect" >
                    <HeaderStyle HorizontalAlign="Left" Width="90px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                    SortExpression="Remarks" >
                    <HeaderStyle HorizontalAlign="Left" Width="90px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" 
                    SortExpression="ExamDate" >
                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton style="text-decoration: none;" ID="lDelete" runat="server" CommandArgument='<%# Eval("ResultNo") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:HyperLinkField Text="Delete" DataNavigateUrlFields="SubjectID"           
                    DataNavigateUrlFormatString="SubjectDetsFrm.aspx?" >
                    <HeaderStyle HorizontalAlign="Left"/>
                    </asp:HyperLinkField>--%>
               </Columns>
            </asp:GridView>
    </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
            <%--<p style="font-size: 12px; margin-left: 120px; margin-top: 300px;">@ 2020-2021 - My Online Exam Application</p>--%>
        </div>
</body>
</html>
