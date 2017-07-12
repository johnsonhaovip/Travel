<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="MyArticle.aspx.cs" Inherits="User_MyArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/MyArticleStyle.css" rel="stylesheet" />
    <div id="a_content">
        <div id="myarticle">
            我的游记
        </div>
        <%--根据行程表ID获取行程--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select  tab_article.u_emaile, tab_article.t_title,tab_article.t_content,
                       tab_article.art_illustration,tab_article.art_ClickNumber,
                      tab_article.art_discuss,tab_article.d_name,
	                   tab_article.d_emaile,tab_article.u_name from tab_article
                       where tab_article.u_id=@u_id">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>
                
                <div class="title">
                    <asp:Label ID="t_title" runat="server" Text='<%# Eval("t_title") %>' />
                </div>
                <div class="mycontent">
                    <div class="t_image">
                        <img src='<%#Eval("art_illustration")%>' style="width: 300px; height: 250px; float:left" />
                    </div>

                    <p class="t_content">
                        <%#Eval("t_content")%>
                    </p>
                </div>

            </ItemTemplate>
        </asp:DataList>
    </div>

 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

