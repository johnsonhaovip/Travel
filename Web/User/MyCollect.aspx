<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="MyCollect.aspx.cs" Inherits="User_MyCollect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/MyArticleStyle.css" rel="stylesheet" />
    <div id="d_content" style="height: 700px; width: 900px; border: 1px solid #dedede; margin: 0 auto">
        <div id="mydiscuss" style="width: 865px; height: 30px; border-bottom: 2px solid #e2face; color: #459406; font-size: 16px; line-height: 36px; overflow: hidden;">
            我的收藏
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select  tab_collect.u_emaile, tab_collect.u_collect,tab_collect.t_content,
                       tab_collect.UploadTime from tab_collect
                       where tab_collect.u_id=@u_id order by UploadTime desc">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>

                <div class="title">
                    <asp:Label ID="t_title" runat="server" Text='<%# Eval("u_collect") %>' />
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

