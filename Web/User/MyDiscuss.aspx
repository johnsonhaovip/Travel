<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="MyDiscuss.aspx.cs" Inherits="User_MyDiscussaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/MyDiscussStyle.css" rel="stylesheet" />
    <link href="../css/MyArticleStyle.css" rel="stylesheet" />
    <div id="d_content" style="height: 700px; width: 900px; border: 1px solid #dedede; margin: 0 auto">
        <div id="mydiscuss" style="width: 865px; height: 30px; border-bottom: 2px solid #e2face; color: #459406; font-size: 16px; line-height: 36px; overflow: hidden;">
            我的评论
        </div>
        <%--根据我的评论--%>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select top 1 tab_discuss.u_id, tab_article.t_title ,tab_article.t_content ,tab_article.art_illustration ,
       tab_article.u_emaile,tab_discuss.u_emaileB,tab_discuss.u_discuss
	   from tab_article,tab_discuss where tab_article.u_emaile=tab_discuss.u_emaileA and tab_discuss.u_id=@u_id order by tab_discuss.UploadTime desc">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select top 1 tab_discuss.u_emaileA,tab_discuss.u_discuss 
                           from tab_discuss 
                          where tab_discuss.u_id=@u_id order by  tab_discuss.UploadTime desc">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>


        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>
                <p>
                    游记标题：<%#Eval("t_title")%>
                </p>
                <div class="t_image" style="float: left;">
                    <img src='<%#Eval("art_illustration")%>' style="width: 300px; height: 250px; float: left" />
                </div>

                <p class="t_content" style="float: left;">
                    <%#Eval("t_content")%>
                </p>
            </ItemTemplate>
        </asp:DataList>



        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>
                <p>
                    作者:   <%#Eval("u_emaileA")%>
                </p>

                <p>
                    我的评论: <%#Eval("u_discuss")%>
                </p>
            </ItemTemplate>
        </asp:DataList>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

