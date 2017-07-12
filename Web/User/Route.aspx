<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Route.aspx.cs" Inherits="User_Route" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/RouteStylecss.css" rel="stylesheet" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <script src="../js/BaiduMap.js"></script>


    <div id="big">
        <div id="Route_left">
            <h2 style="text-align: center; border-bottom: 2px solid #808080;">行程列表</h2>
            <div class="left_1">

                <div id="t_depart">
                    <asp:TextBox ID="tx_title" Text="" placeholder="写一个响亮的旅行名字" runat="server" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="旅行名字不能为空！"
                            ControlToValidate="tx_title"
                            Display="None">
                        </asp:RequiredFieldValidator>

                    <asp:TextBox ID="tx_depart" Text="" placeholder="请输入出发地" runat="server" />

                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="出发地不能为空！"
                            ControlToValidate="tx_depart"
                            Display="None">
                        </asp:RequiredFieldValidator>
                     <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                            TargetControlID="RequiredFieldValidator1"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                </div>
                <div id="r-startTime">
                    <asp:TextBox ID="tx_startTime" Text="" placeholder="输入开始旅行的时间" runat="server" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tx_startTime" PopupPosition="Right"></asp:CalendarExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="开始旅行的时间不能为空！"
                            ControlToValidate="tx_startTime"
                            Display="None">
                        </asp:RequiredFieldValidator>

                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                            TargetControlID="RequiredFieldValidator2"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                </div>
                <div id="r-sumTime">
                    <asp:TextBox ID="tx_sumTime" Text="" placeholder="输入预计旅行的天数" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="旅行的天数不能为空！"
                            ControlToValidate="tx_sumTime"
                            Display="None">
                        </asp:RequiredFieldValidator>
                     <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                            TargetControlID="RequiredFieldValidator3"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>
                </div>
                

                <div id="favorite" class="destination onselect">
                    <h3 class="txt_destinattion">创建目的地</h3>
                    <div id="r-latitude">
                        <asp:TextBox ID="tx_latitude" Text="" runat="server" placeholder="经纬度" />
                    </div>

                    <div id="r-destination">
                       <asp:TextBox ID="tx_destination" Text="" runat="server" placeholder="旅游地点" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="目的地不能为空！"
                            ControlToValidate="tx_latitude"
                            Display="None">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                            TargetControlID="RequiredFieldValidator4"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>
                    </div>
                    <div id="r-dis">
                        <asp:TextBox ID="tx_dis" Text=""  runat="server"  placeholder="里程"/>
                    </div>
                </div>
                <div id="sure">
                    <asp:Button ID="btn_sure" Text="确认行程" runat="server" OnClientClick="sure()" OnClick="btn_sure_Click" />
                     <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                            TargetControlID="RequiredFieldValidator1"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>
                </div>

            </div>




        </div>
        <%-- 左边结束--%>


        <div id="Route_content">

            <div id="search-box">
                <asp:TextBox ID="txt_search" Text="" placeholder="寻找你想去的地方或目的地" runat="server" />
                <%--  <input id="txt_search" placeholder="寻找你想去的地方城市或目的地" value="" runat="server" />--%>

                <asp:Button ID="btn_search" runat="server" OnClientClick="initialize()" Text="搜索" Width="43px" Height="43px" OnClick="btn_search_Click" />
            </div>

            <div id="allmap">
            </div>

        </div>
        <%--中间结束--%>


        <div id="Route_right">
            <div id="Route_nav">
                <div class="place">
                    <asp:Label ID="lab_place" Text="成都" runat="server" />
                </div>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">前人游记</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">酒店</asp:LinkButton>

            </div>

            <%-- 右边导航条结束--%>
            <div id="Route_share">

                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                      
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
                            <ItemTemplate>
                                <div class="nav_content">
                                    <div class="art_pic">
                                        <img src="<%# Eval("art_illustration") %>" style="width: 120px; height: 100px" alt="旅途图片" />
                                    </div>

                                    <div class="art_content">
                                        <p>
                                            <asp:Label ID="content" runat="server" Text='<%# Eval("t_title") %>' />
                                        </p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>

                    </asp:View>

                    <asp:View ID="View2" runat="server">
                        酒店内容
                    </asp:View>
                </asp:MultiView>

            </div>
        </div>

        <%--右边结束--%>
    </div>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 5 tab_article.art_illustration, tab_article.t_title from tab_article
             where tab_article.t_title like'%t_destination%' ">

        <SelectParameters>
            <%-- <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />--%>
            <asp:SessionParameter Name="t_destination" SessionField="t_destination" />
        </SelectParameters>

    </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

