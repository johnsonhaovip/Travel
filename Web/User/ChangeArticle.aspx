<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeArticle.aspx.cs" Inherits="User_ChangeArticle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select  tab_article.u_emaile, tab_article.t_title,tab_article.t_content,
                       tab_article.art_illustration,tab_article.art_ClickNumber
                       from tab_article
                       where tab_article.u_id=@u_id">
        <SelectParameters>
            <asp:SessionParameter Name="u_id" SessionField="u_id" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"
         OnItemCommand="DataList1_ItemCommand"
        RepeatDirection="Horizontal" RepeatColumns="1">
        <ItemTemplate>
            <div id="addarticle" style="width: 900px; height: 540px; margin-left:200px; border: 2px solid #e2face;">
                <div id="t_title" style="margin: 0 auto; width: 300px;">
                    <asp:TextBox ID="biaoti" runat="server" placeholder="请输入40字以内的标记"
                        Text='<%# Eval("t_title") %>' />
                </div>

                <div id="t_content" style="width: 898px; height:405px; margin: 0 auto; margin-top: 5px;">
                    <asp:TextBox ID="content" runat="server" placeholder="请输入游记内容"
                        Text='<%#Eval("t_content")%>'
                        Width="890px" Height="398px" TextMode="multiLine" />
                </div>

                <div id="btn" style="margin: 0 auto; width: 50px; height: 40px">
                    <asp:Button ID="sure" Text="确定" CommandName="sure" runat="server" />
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

