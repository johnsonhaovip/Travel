<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Personal_Detail.aspx.cs" Inherits="User_Personal_Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <link href="../css/PersonalStyle.css" rel="stylesheet" />
    <div id="left">
        <div class="details">
            <p>个人资料</p>
        </div>
        <div id="nav1" style="height: 380px;">
            <asp:DataList ID="DL_head" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="1">
                <ItemTemplate>
                    <div class="img_head">
                        <div id="div_head" style="text-align: center;">
                            <img src="<%# Eval("u_head") %>" style="width: 100px; height: 100px;" alt="用户头像" />
                        </div>

                        <div id="div_name" style="text-align: center; float: left; width: 265px; margin: 0 auto">
                            欢迎您:<asp:Label ID="lb_name" runat="server" Text='<%# Eval("u_name") %>' />
                        </div>

                    </div>
                </ItemTemplate>
            </asp:DataList>

            <div class="lb_style">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">我的行程</asp:LinkButton>
            </div>
            <div class="lb_style">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">我的游记</asp:LinkButton>
            </div>
            <div class="lb_style">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">我的收藏</asp:LinkButton>
            </div>
            <div class="lb_style">
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">我的评论</asp:LinkButton>
            </div>
        </div>

       <%-- 点击账号设置可隐藏哈显示--%>
        <div class="Account_settings " style="width: 259px">

            <asp:Panel ID="Panel1" runat="server" CssClass="title">
                <asp:LinkButton ID="LinkButton5" runat="server">账号设置</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" CssClass="content">
                <p>
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">修改头像</asp:LinkButton>

                </p>
                <p>
                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">修改昵称</asp:LinkButton>
                </p>
                <p>
                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">修改密码</asp:LinkButton>
                </p>
            </asp:Panel>


            <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                TargetControlID="Panel2"
                ExpandControlID="Panel1"
                CollapseControlID="Panel1">
            </asp:CollapsiblePanelExtender>
        </div>

    </div>

    <%--获取用户头像,和昵称--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 1 tab_user.u_head,tab_user.u_name from tab_user where tab_user.u_emaile=@u_emaile">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%--  获取用户行程--%>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select TOP 5 tab_travel.u_id, tab_travel.t_depart,tab_travel.t_destination,
                         tab_travel.t_startTime,tab_travel.t_sumTime,tab_travel.t_title,
                         tab_travel.u_name,tab_travel.t_day1,tab_travel.t_day2,tab_travel.t_day3,
                         tab_travel.t_day4,tab_travel.t_day5,tab_travel.UploadTime from tab_travel 
                         where tab_travel.u_emaile=@u_emaile order by UploadTime desc">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%-- 获取用户游记,并且获取用户得到的评论,在根据评论获取评论人信息--%>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select TOP 5 tab_article.u_id,tab_article.t_title,tab_article.t_content,
                       tab_article.art_illustration,tab_article.art_ClickNumber,
                      tab_article.art_discuss,tab_article.d_name,tab_article.UploadTime,
	                   tab_article.d_emaile,tab_article.u_name from tab_article,tab_user 
                       where tab_article.u_emaile=tab_user.u_emaile and tab_article.u_emaile=@u_emaile order by UploadTime desc">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%--   根据别人的评论获取评论人的昵称和emaile--%>

    <%--<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select  tab_article.art_discuss,tab_article.d_name,
	                   tab_article.d_id,tab_article.u_name,tab_user.u_emaile,tab_user.u_name
	                   from tab_article,tab_user 
	                   where tab_user.u_discuss=tab_article.art_discuss and tab_article.u_emaile=@u_emaile">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>--%>

    <%--  获取用户收藏 --%>

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select TOP 5 tab_collect.u_id, tab_collect.u_collect,
        tab_collect.t_content,tab_collect.u_emaile
        from tab_collect,tab_user 
        where tab_collect.u_emaile=tab_user.u_emaile and tab_collect.u_emaile=@u_emaile order by UploadTime desc">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>


    <%--  获取用户最近评论,和文章的作者--%>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 5 tab_discuss.u_id,tab_discuss.u_discuss,tab_discuss.u_emaileA,tab_discuss.UploadTime
        from tab_discuss,
        tab_user where tab_user.u_emaile=tab_discuss.u_emaileB 
		and tab_discuss.u_emaileB=@u_emaile order by UploadTime desc">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%--获取用户昵称--%>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 1 tab_user.u_name from tab_user where tab_user.u_emaile=@u_emaile">
        <SelectParameters>
            <asp:SessionParameter Name="u_emaile" SessionField="u_emaile" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div id="right">

        <%--我的行程--%>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="mytravel">
                    我的行程
                </div>

                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2"
                    OnItemCommand="DataList1_ItemCommand"
                    RepeatDirection="Horizontal" RepeatColumns="1">

                    <ItemTemplate>
                        <div class="mycontent">
                            <div class="mycontent_txt">
                                <a href='MyTravel.aspx?u_id=<%#Eval("u_id") %>'>
                                    <asp:Label ID="t_title" runat="server" Text='<%# Eval("t_title") %>' />
                                </a>
                            </div>
                            创建时间:<a><%# ((DateTime)Eval("UploadTime")).ToString("yyyy-MM-dd") %></a><div class="mycontent_btn">
                                <asp:Button ID="delete" CommandName="delete" runat="server" Text="删除" CommandArgument=<%# Eval("u_id") %>  />
                                <asp:Button ID="change" CommandName="change" runat="server" Text="修改" CommandArgument=<%# Eval("u_id") %> />
                            </div>

                        </div>
                    </ItemTemplate>
                   
                    
                </asp:DataList>
                 
            </asp:View>

            <%-- 我的游记--%>
            <asp:View ID="View2" runat="server">
                <div class="mytravel">
                    我的游记
                    <a href="AddArticle.aspx">添加游记</a>
                </div>
                <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource3"
                    OnItemCommand="DataList2_ItemCommand"
                    RepeatDirection="Horizontal" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="mycontent">
                            <div class="mycontent_txt">
                                <a href='MyArticle.aspx?u_id=<%#Eval("u_id")%>'>
                                    <asp:Label ID="t_title" runat="server" Text='<%# Eval("t_title") %>' />
                                </a>
                            </div>
                            创建时间:<a><%# ((DateTime)Eval("UploadTime")).ToString("yyyy-MM-dd") %></a><div class="mycontent_btn">
                                <asp:Button ID="delete" CommandName="delete" runat="server" Text="删除" 
                                    CommandArgument=<%# Eval("u_id") %>/>
                                  <asp:Button ID="change" CommandName="change"  runat="server" Text="修改" 
                                     CommandArgument=<%# Eval("u_id") %>
                                      />
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </asp:View>

            <%--我的收藏--%>
            <asp:View ID="View3" runat="server">
                <div class="mytravel">
                    我的收藏
                </div>
                <asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataSource4"
                    OnItemCommand="DataList3_ItemCommand"
                    RepeatDirection="Horizontal" RepeatColumns="1">
                    <ItemTemplate>

                        <div class="mycontent">
                            <div class="mycontent_txt">
                                <a href='MyCollect.aspx?u_id=<%#Eval("u_id")%>'>
                                    <asp:Label ID="u_collect" runat="server" Text='<%# Eval("u_collect") %>' />
                                </a>
                            </div>

                            <div class="mycontent_btn">
                                <asp:Button ID="delete" CommandName="delete" runat="server" Text="删除"
                                     CommandArgument=<%# Eval("u_id") %> />
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </asp:View>

            <%--我的最近评论--%>
            <asp:View ID="View4" runat="server">
                <div class="mytravel">
                    我的评论
                </div>
                <asp:DataList ID="DataList4" runat="server" DataSourceID="SqlDataSource5"
                    OnItemCommand="DataList4_ItemCommand"
                    RepeatDirection="Horizontal" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="mycontent">
                            <div class="mycontent_txt">
                                <a href='LookDiscussAndArctile.aspx?u_id=<%#Eval("u_id") %>'>
                                    <asp:Label ID="u_discuss" runat="server" Text='<%# Eval("u_discuss") %>' />
                                </a>
                               
                            </div>

                            <div>
                                作者:<asp:Label ID="u_emaileA" runat="server" Text='<%# Eval("u_emaileA") %>' />
                            </div>
                           
                            <div class="mycontent_btn">
                                <asp:Button ID="delete" CommandName="delete" runat="server" Text="删除"
                                     CommandArgument=<%# Eval("u_id") %> />
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </asp:View>

            <%--修改头像--%>
            <asp:View ID="View5" runat="server">
                <div class="mytravel">
                    修改头像
                </div>
                <div class="mycontent">
                    <div class="mycontent_txt">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btn_up_head" Text="上传" runat="server" OnClick="btn_up_head_Click" />
                    </div>
                </div>

            </asp:View>

            <%-- 修改昵称--%>

            <asp:View ID="View6" runat="server">
                <div class="mytravel">
                    修改昵称
                </div>
                <asp:DataList ID="DataList5" runat="server" DataSourceID="SqlDataSource6" RepeatDirection="Horizontal" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="mycontent">
                            <div class="mycontent_txt">
                                昵称:<asp:Label ID="u_name" runat="server" Text='<%# Eval("u_name") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div class="mycontent_txt">
                    <asp:TextBox ID="u_nameNew" runat="server" placeholder="请输入你的新昵称" />
                </div>
                <div class="mycontent_btn">
                    <asp:Button ID="btn_chenge_name" runat="server" Text="确认修改" OnClick="btn_chenge_name_Click" />
                </div>
            </asp:View>

            <%--修改密码--%>
            <asp:View ID="View7" runat="server">
                <div class="mytravel">
                    修改密码
                </div>
                <div class="mycontent_txt">
                    <asp:TextBox ID="txt_password" runat="server" placeholder="请输入你的密码" />
                    <asp:TextBox ID="txt_newpassword" runat="server" placeholder="请输入你要设置的新密码" />
                </div>
                <div class="mycontent_btn">
                    <asp:Button ID="btn_change_password" runat="server" Text="确认修改" OnClick="btn_change_password_Click" />
                </div>
            </asp:View>

        </asp:MultiView>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

