<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserFrm.aspx.cs" Inherits="OnlineExamSys.Web_Frms.AddUserFrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style4.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Butones 
        {
            margin-left: 104px;
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

        <fieldset style="margin-top:20px; margin-left: 120px; width:700px; height:250px;">
            <legend>Create Users</legend>

            <div style="margin-left: 60px; margin-top:30px;">
                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">User ID:</span> 
                    <asp:TextBox ID="tID" runat="server" OnTextChanged="tID_TextChange" Width="170px"></asp:TextBox>
                </label>
                <asp:Label ID="lID" ForeColor="Red" runat="server" Text=""></asp:Label>
                <br />
                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Student ID:</span> 
                        <asp:DropDownList ID="cbID" runat="server" Width="178px" Height="20px" 
                    AutoPostBack="True" onselectedindexchanged="cbID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </label>
                <br />
                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Student:</span> 
                    <asp:DropDownList ID="cbStuds" runat="server" Width="178px" Height="20px" 
                    AutoPostBack="True" onselectedindexchanged="cbStuds_SelectedIndexChanged">
                    </asp:DropDownList>
                <asp:Label ID="lStuds" ForeColor="Red" runat="server" Text=""></asp:Label>
                </label>
                <br />

                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">User Name:</span> 
                <asp:TextBox ID="tUser" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lUser" ForeColor="Red" runat="server" Text=""></asp:Label>
                </label>
                <br />

                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Password:</span> 
                <asp:TextBox ID="tPass" TextMode="Password" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lPass" ForeColor="Red" runat="server" Text=""></asp:Label>
                </label>
                <br />

                <label class="label"><span style="display:inline-block; padding-bottom: 0.5em; text-align:right; width:100px;">Confirm Pass:</span> 
                <asp:TextBox ID="tConfirm" TextMode="Password" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lConfirm" ForeColor="Red" runat="server" Text=""></asp:Label>
                </label>
                <br />
                <asp:Button CssClass="Butones" ID="bSave" runat="server" Text="Create" 
                onclick="bSave_Click" />
                <asp:Label style="margin-left: 130px;" ID="lError" runat="server" Text=""></asp:Label>
            </div>        
        </fieldset>
        <div style="margin-left: 120px; margin-top: 30px;">
            <asp:HyperLink style="text-decoration: none;" ID="lBack" runat="server" NavigateUrl="~/Web Frms/UsersFrm.aspx">Back</asp:HyperLink>
        </div>

    
    </form>
        <div>
            <p style="font-size: 12px; margin-left: 120px; margin-top: 150px;">@ 2020-2021 - My Online Exam Application</p>
        </div>
</body>
</html>
