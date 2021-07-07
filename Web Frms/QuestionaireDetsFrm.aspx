<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionaireDetsFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.QuestionaireDetsFrm" %>

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
    <div style="margin-left: 30px;">
            <h2>Questionaire</h2>
        <asp:HyperLink style="text-decoration: none;" ID="lCreate" runat="server" 
        NavigateUrl="~/Web Frms/QuestionaireFrm.aspx">Create New</asp:HyperLink>    
    </div>

    <div style="margin-top:0px; margin-top:20px; margin-left: 30px;">
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
                            <asp:DropDownList ID="cbSec" runat="server" Enabled="false" Height="19px" 
                            Width="160px" AutoPostBack="True" 
                                onselectedindexchanged="cbSec_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Subject:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="cbSubj" runat="server" Enabled="false" Height="19px" 
                            Width="160px" AutoPostBack="True" 
                                onselectedindexchanged="cbSubj_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <fieldset style="width:400px; height:35px;">
                                <legend>Quarters</legend>
                                    <asp:RadioButton ID="rdAll" Text="All" Enabled="true" 
                                    GroupName="RadioButts" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="rdAll_CheckedChanged"/>           
                                    <asp:RadioButton ID="rd1" Text="Quarter 1" Enabled="true" 
                                    GroupName="RadioButts" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="rd1_CheckedChanged" />
                                    <asp:RadioButton ID="rd2" Text="Quarter 2" Enabled="true" 
                                    GroupName="RadioButts" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="rd2_CheckedChanged" />
                                    <asp:RadioButton ID="rd3" Text="Quarter 3" Enabled="true" 
                                    GroupName="RadioButts" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="rd3_CheckedChanged" />
                                    <asp:RadioButton ID="rd4" Text="Quarter 4" Enabled="true" 
                                    GroupName="RadioButts" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="rd4_CheckedChanged" />
                            </fieldset>
                        </td>
                        </tr>
                </table>
            </div>

        <div style="margin-top:10px; margin-top:20px; margin-left: 30px;">
                    <asp:GridView ID="gvDisp" Width="1700px" CellPadding="5"  
                        AutoGenerateColumns="False" runat="server" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="QuestionNo" HeaderText="Question No" 
                                ItemStyle-Width="10%" ReadOnly="True" 
                            SortExpression="QuestionNo" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Question" HeaderText="Question" 
                                ItemStyle-Width="50%" ReadOnly="True" 
                            SortExpression="Question" >
                            <HeaderStyle HorizontalAlign="Left" Width="700px" />
                            <ItemStyle Width="50%"></ItemStyle>
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="Option1" HeaderText="Option1" ReadOnly="True" 
                            SortExpression="Option1" />
                            <asp:BoundField DataField="Option2" HeaderText="Option2" ReadOnly="True" 
                            SortExpression="Option2" />
                            <asp:BoundField DataField="Option3" HeaderText="Option3" ReadOnly="True" 
                            SortExpression="Option3" />
                            <asp:BoundField DataField="Option4" HeaderText="Option4" ReadOnly="True" 
                            SortExpression="Option4" />--%>
                            <%--<asp:BoundField DataField="Corrections" HeaderText="Corrections" ReadOnly="True" 
                            SortExpression="Corrections" />--%>

                            <asp:HyperLinkField ControlStyle-CssClass="Decor" Text="Edit" DataNavigateUrlFields="QuestionNo, Question, Option1, Option2, Option3, Option4, Corrections, SchoolYearID, GradeID, SectionID, SubjectID, QuarterID, QuestionID"         
                            DataNavigateUrlFormatString="UpdateQuestionFrm.aspx?QuestionNo={0}&Question={1}&Option1={2}&Option2={3}&Option3={4}&Option4={5}&Corrections={6}&SchoolYearID={7}&GradeID={8}&SectionID={9}&SubjectID={10}&QuarterID={11}&QuestionID={12}" >
                            <ControlStyle CssClass="Decor"></ControlStyle>
                            <HeaderStyle HorizontalAlign="Right" Width="220px" />
                            </asp:HyperLinkField>

                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton style="text-decoration: none;" ID="lDelete" runat="server" CommandArgument='<%# Eval("Question") %>' OnClick="lDelete_OnClick">Delete</asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <%--<asp:HyperLinkField Text="Edit" ItemStyle-Width="2%">
                            <ItemStyle Width="5%"></ItemStyle>
                            </asp:HyperLinkField>
                            <asp:HyperLinkField Text="Delete" ItemStyle-Width="2%">
                            <ItemStyle Width="5%"></ItemStyle>
                            </asp:HyperLinkField>--%>

                        </Columns>
                    </asp:GridView>
                </div>
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 30px; margin-top: 80px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
    
</body>
</html>
