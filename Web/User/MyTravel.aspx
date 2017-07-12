<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="MyTravel.aspx.cs" Inherits="User_MyTravelaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script src="../js/MyTravelMap.js"></script>
    <link href="../css/MyTravelStyle.css" rel="stylesheet" />
    <script src="../js/jquery-2.0.2.js" type="text/javascript"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>

    <div id="left">

        <div id="mytravel" style="width: 268px; height: 30px; border-bottom: 2px solid #e2face; color: #459406; font-size: 16px; line-height: 36px; overflow: hidden;">
            我的行程
        </div>
        <%--根据行程表ID获取行程--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
            SelectCommand="select tab_travel.t_depart,tab_travel.t_destination,
                         tab_travel.t_startTime,tab_travel.t_sumTime,tab_travel.t_title,
                         tab_travel.u_name,tab_travel.t_day1,tab_travel.t_day2,tab_travel.t_day3,
                         tab_travel.t_day4,tab_travel.t_day5,tab_travel.UploadTime from tab_travel 
                         where  tab_travel.u_id=@u_id ">
            <SelectParameters>
                <asp:SessionParameter Name="u_id" SessionField="u_id" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
            <ItemTemplate>
                <div class="mycontent1">
                    旅行名称:<asp:Label ID="Label1" runat="server" Text='<%# Eval("t_title") %>' />
                </div>

                <div class="mycontent1">
                    出发地:<asp:Label ID="t_depart" runat="server" Text='<%# Eval("t_depart") %>' />
                </div>

                <div class="mycontent1">
                    目的地:<asp:Label ID="t_destination" runat="server" Text='<%# Eval("t_destination") %>' />
                </div>

                <div class="mycontent1">
                    出发时间:<asp:Label ID="t_startTime" runat="server" Text='<%# ((DateTime)Eval("t_startTime")).ToString("yyyy-MM-dd") %>' />
                </div>

                <div class="mycontent1">
                    旅行天数:
                    <asp:Label ID="t_sumTime" runat="server" Text='<%# Eval("t_sumTime") %>' />

                </div>
                <div class="mycontent1">
                    创建时间:
                    <asp:Label ID="UploadTime" runat="server" Text='<%# ((DateTime)Eval("UploadTime")).ToString("yyyy-MM-dd") %>' />
                </div>

            </ItemTemplate>
        </asp:DataList>

    </div>

    <%--    左边结束--%>
    <div id="MyTravel_content">
        <div id="search-box">
            <asp:TextBox ID="txt_search" Text="" placeholder="寻找你想去的地方或目的地" runat="server" />
            <asp:Button ID="btn_search" runat="server" OnClientClick="initialize()" Text="搜索" Width="50px" Height="45px" OnClick="btn_search_Click" />
        </div>

        <div id="allmap">
        </div>

    </div>
    <%--中间结束--%>

    <div id="MyTravel_right">
        <div class="r-discost">
            行走里程:<asp:Label ID="lab_dis" Text="" runat="server" />
        </div>
        <div class="r-discost">
            预计费用:<input type="text" id="lab_cost" value="" />
        </div>

        <script>
            $(function () {
                $("#ContentPlaceHolder2_btn_count").click(function () {
                    $("#count_box").slideDown(2000);
                });
                $("#btn_close").click(function () {
                    $("#count_box").slideUp(1000);
                });
            });
            function jisuan() {
                var a = document.getElementById("eat").value;//吃的消费
                var b = document.getElementById("stay").value;//住 的消费
                var c = document.getElementById("ticket").value;//门票的消费
                var d = document.getElementById("traffic").value;//交通工具的消费
                var sum = parseInt(a) + parseInt(b) + parseInt(c) + parseInt(d);
                document.getElementById("lab_cost").value = sum;
            }
        </script>

        <input type="button" id="btn_count" value="点击计算费用" runat="server" />
        <div id="count_box">
            <input type="text" id="eat" placeholder="输入吃的预计消费" />
            <input type="text" id="stay" placeholder="输入住宿的预计消费" />
            <input type="text" id="ticket" placeholder="输入各种门票的预计消费" />
            <input type="text" id="traffic" placeholder="输入交通工具的预计消费" />
            <input type="button" id="sure" value="确定" onclick="jisuan()" />
            <input type="button" id="btn_close" value="关闭" />
        </div>


        <div class="r-tishi">
            温馨提示:费用的实际情况和预计可能有所不同。
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

