<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="AddArticle.aspx.cs" Inherits="User_AddArticle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <div id="addarticle" style="width:900px;height:540px;margin:0 auto;border:2px solid #e2face;">
        <div id="t_title" style=" margin:0 auto; width:300px;">
            <asp:TextBox ID="biaoti" runat="server" placeholder="请输入40字以内的标记" />
        </div>
        <div id="t_content" style="width:898px;height:400px;margin:0 auto;margin-top:5px;">
            <%--<cc1:Editor ID="Editor1" runat="server" />--%>
             <asp:TextBox ID="Editor1" runat="server" placeholder="请输入游记内容" Width="890px" Height="398px" TextMode="multiLine"/>
        </div>
       
        <div id="art_illustration" style="margin:0 auto;margin-top:5px; width:300px;height:30px;">
           选择插图:  <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div id="btn" style="margin:0 auto;width:50px; height:50px">
            <asp:Button ID="sure" Text="确定" runat="server" OnClick="sure_Click" />
        </div>
        <input type="hidden" id="neirong" value="" runat="server">
        
        <script>
            document.getElementById("neirong").value=document.getElementById("Editor1").value;
        </script>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

