<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="LookActicle.aspx.cs" Inherits="User_LookActicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div id="a_content">
    
         <link href="../css/MyArticleStyle.css" rel="stylesheet" />
         <script src="../js/jquery-1.7.2.min.js"></script>
         <script src="../js/jquery-2.0.2.js"></script>
        <div id="myarticle">
            预览游记
        </div>
        <%--根据行程表ID获取行程--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select  tab_article.u_emaile, tab_article.t_title,tab_article.t_content,
                       tab_article.art_illustration,tab_article.art_ClickNumber,
                       tab_article.art_discuss from tab_article
                       where tab_article.u_id=@u_id order by UploadTime desc">
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

           <script>
               $(function () {
                   $("#ContentPlaceHolder2_btn_count").click(function () {
                       $("#count_box").slideDown(2000);
                   });
                   $("#btn_close").click(function () {
                       $("#count_box").slideUp(1000);
                   });
               });
        </script>

        <input type="button" id="btn_count" value="点击写评论" runat="server" />
        <div id="count_box">
            <asp:TextBox ID="neirong" Width="890px" Height="150px" TextMode="multiLine"  
                          placeholder="输入你想发表的评论" runat="server" />
            <asp:Button ID="btn_sure" runat="server" Text="确定" OnClick="btn_sure_Click" />
            <input type="button" id="btn_close" value="关闭" />
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

