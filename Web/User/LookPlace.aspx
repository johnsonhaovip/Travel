<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="LookPlace.aspx.cs" Inherits="User_LookPlace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="a_content">
    
         <link href="../css/MyArticleStyle.css" rel="stylesheet" />
         <script src="../js/jquery-1.7.2.min.js"></script>
         <script src="../js/jquery-2.0.2.js"></script>
        <div id="myarticle">
            预览目的地
        </div>
        <%--根据行程表ID获取行程--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select tab_place.u_id, tab_place.u_emaile, tab_place.s_place, 
                           tab_place.s_picture,tab_place.s_introduce,tab_place.s_type,tab_place.s_ClickNumber 
                           from tab_place where tab_place.u_id=@u_id
                           order by s_ClickNumber desc">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>
                
                <div class="title">
                    <asp:Label ID="t_title" runat="server" Text='<%# Eval("s_place") %>' />
                </div>

                <div class="mycontent">
                    <div class="t_image">
                        <img src='<%#Eval("s_picture")%>' style="width: 300px; height: 250px; float:left" />
                    </div>

                    <p class="t_content">
                        <%#Eval("s_introduce")%>
                    </p>
                </div>

            </ItemTemplate>
        </asp:DataList>
         
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

