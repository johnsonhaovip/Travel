<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/ArticleStyle.css" rel="stylesheet" />
    <script src="../js/jquery-2.0.2.js"></script>
    <style>
        .btncss {
            color: White;
            border-style: none;
            width: 35px;
            height: 35px;
            background: url(img/collect2.png) no-repeat;
        }
    </style>




    <div id="a_content">

        <div id="myarticle">
            所有游记
        </div>
      
        <asp:Repeater ID="rp_Arctile" runat="server">

            <HeaderTemplate>
                <table style="margin: 0 auto;">
                    <tr>
                        <td id="t_title" style="width: 200px; height: 50px; background-color: #f6f6f6; text-align: center;">游记标题</td>
                        <td id="t_content" style="width: 450px; height: 40px; background-color: #f6f6f6; text-align: center;">游记内容</td>
                        <td id="art_ClickNumber" style="width: 50px; height: 40px; background-color: #f6f6f6; text-align: center;">点击量</td>
                        <td id="u_emaile" style="width: 150px; height: 40px; background-color: #f6f6f6; text-align: center;">上传者</td>
                        <td id="UploadTime" style="width: 80px; height: 40px; background-color: #f6f6f6; text-align: center;">上传时间</td>
                        <td id="collect" style="width: 80px; background-color: #f6f6f6; text-align: center;">收藏</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>

                    <td id="songname" style="background-color: #f6f6f6">
                        <a href='LookActicle.aspx?u_id=<%# Eval("u_id")%>'>
                            <p id="title" style="width: 200px; height: 50px; text-align: center;" runat="server"><%# Eval("t_title") %></p>
                        </a>
                    </td>
                    <td id="t_content" style="width: 450px; height: 40px; background-color: #f6f6f6"><%# foramtstr(Eval("t_content").ToString()) %></td>
                    <td id="art_ClickNumber" style="width: 50px; height: 40px; background-color: #f6f6f6; text-align: center;"><%# Eval("art_ClickNumber") %></td>
                    <td id="u_emaile" style="width: 150px; height: 40px; background-color: #f6f6f6"><%#Travel.BLL.UserBusiness.GetUserByEmaile(Convert.ToString(Eval("u_emaile"))).U_emaile %>
                    </td>
                    <td id="UploadTime" style="width: 80px; height: 40px; background-color: #f6f6f6"><%# ((DateTime)Eval("UploadTime")).ToString("yyyy-MM-dd") %></td>
                    <td id="collect" style="color: aqua; background-color: #f6f6f6; width: 80px">
                        <a href='<%# Eval("t_title") %>' onserverclick="Unnamed_ServerClick" runat="server">点击收藏</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
                    
            </FooterTemplate>

        </asp:Repeater>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

