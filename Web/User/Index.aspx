<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="User_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 8 tab_place.u_id,tab_place.s_place, tab_place.s_picture,tab_place.s_introduce,tab_place.s_type,tab_place.s_ClickNumber
                       from tab_place where tab_place.s_type='境内' order by s_ClickNumber desc,s_update desc"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 2 tab_place.u_id,tab_place.s_place, tab_place.s_picture,tab_place.s_introduce,tab_place.s_type,tab_place.s_ClickNumber
                       from tab_place where tab_place.s_type='境外' order by s_ClickNumber desc,s_update desc"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 4 tab_place.u_id,tab_place.s_place, tab_place.s_picture,tab_place.s_introduce,tab_place.s_type,tab_place.s_ClickNumber
                       from tab_place where tab_place.s_type='境外' order by s_ClickNumber asc,s_update desc"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:cnstr %>"
        SelectCommand="select top 6 tab_article.u_id, tab_article.art_illustration,tab_article.t_title from tab_article 
                           order by UploadTime desc"></asp:SqlDataSource>


    <div class="banner">

        <ul class="list0">
            <li class="cur"><a href="#">
                <img src="../img/bg-1.jpg" alt="" /></a></li>
            <li><a href="#">
                <img src="../img/bg-2.jpg" alt="" /></a></li>
            <li><a href="#">
                <img src="../img/bg-3.jpg" alt="" /></a></li>

        </ul>
        <div class="fadeCover"></div>
        <ul class="circle">
            <li class="cur">1</li>
            <li>2</li>
            <li>3</li>

        </ul>
    </div>
    <!-- 内容区域 -->
    <!-- 分享 -->

    <div class="cl"></div>
    <div class="hot">
        <div class="new">
            最新点评
        <span></span>
        </div>
        <div class="main">
            <ul>
                <li class="cur">马尔代夫真的太美了还遇到了我的偶像蒋浩先生，下次还要再去！</li>
                <li>丽江之美，美及天下</li>
                <li>做一个没有故事的人,与我一起游世界。</li>
                <li>转机的时候还能在新加坡机场免税店购物,</li>

            </ul>
        </div>
        <script type="text/javascript" src="../js/hot.js"></script>

        <div class="manyidu">
            满意度：
        <span>100%</span>
        </div>
        <div class="comeon">
            即刻出发
        <span></span>
        </div>
    </div>
    <div class="cl"></div>
    <%-- <div class="tejia">
        <p class="wenzi">

            <span class="cur">每日特价</span>
            <span>特价机票</span>

        </p>
        <p class="sanjiao"></p>
        <p class="more"><a href="#">更多>></a></p>
    </div>
    <div class="youhuitu">
        <ul>
            <li>
                <img src="img/te01.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">迪拜帆船游超值特惠</div>
                    <div class="xiangxi">全国联运-迪拜帆船酒店三天三晚自由行，奢华体验 都套餐选择住帆船，做土豪，享好礼。</div>
                </div>
            </li>
            <li>
                <img src="img/te02.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">澳洲三城游超值特惠</div>
                    <div class="xiangxi">澳洲三城自由行8/9天，悉尼黄金海岸布尼斯班 豪华酒店南航 广州飞不回头</div>
                </div>
            </li>
            <li>
                <img src="img/te03.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">亚德里亚海超值特惠</div>
                    <div class="xiangxi">全国联运-亚德里亚自由行，奢华体验 都套餐选，做土豪，享好礼。</div>
                </div>
            </li>
            <li>
                <img src="img/te04.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">美国自由行超值特惠</div>
                    <div class="xiangxi">美国自由行西岸10天7晚 自驾游全国出发一价全包含签证 全国联运7晚酒店自驾签证费全包</div>
                </div>
            </li>
        </ul>

    </div>
    <div class="youhuitu">
        <ul>
            <li>
                <img src="img/te05.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">迪拜帆船游超值特惠</div>
                    <div class="xiangxi">全国联运-迪拜帆船酒店三天三晚自由行，奢华体验 都套餐选择住帆船，做土豪，享好礼。</div>
                </div>
            </li>
            <li>
                <img src="img/te06.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">澳洲三城游超值特惠</div>
                    <div class="xiangxi">澳洲三城自由行8/9天，悉尼黄金海岸布尼斯班 豪华酒店南航 广州飞不回头</div>
                </div>
            </li>
            <li>
                <img src="img/te07.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">亚德里亚海超值特惠</div>
                    <div class="xiangxi">全国联运-亚德里亚自由行，奢华体验 都套餐选，做土豪，享好礼。</div>
                </div>
            </li>
            <li>
                <img src="img/te08.jpg" alt="" />
                <div class="youhuitu-in">
                    <div class="youhuitu-inl">优惠</div>
                    <div class="youhuitu-inr">美国自由行超值特惠</div>
                    <div class="xiangxi">美国自由行西岸10天7晚 自驾游全国出发一价全包含签证 全国联运7晚酒店自驾签证费全包</div>
                </div>
            </li>
        </ul>

    </div>--%>

    <div class="yaotiao">
        <img src="../img/yaotiao.jpg" alt="" />
    </div>
    <div class="pinpai">
        <p class="wenzi">
            境内游    
        </p>
        <p class="more"><a href="#">更多>></a></p>
    </div>
    <div class="pinpai_in">
        <div class="pinpai_inl">

            <img src="../img/pinpai_left.png" alt="" />
            <div class="pinpai_inlin">
            </div>
            <span class="pinpai_inl_span1">马尔代夫超值连线游</span>
            <span class="pinpai_inl_span2">让你一次游个够，心动不如行动吧！</span>
        </div>


        <div class="pinpai_inr">
            <ul>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatColumns="4">
                    <ItemTemplate>
                        <li class="cur">

                            <a href='LookPlace.aspx?u_id=<%#Eval("u_id")%>'>
                                <img src='<%#Eval("s_picture")%>' alt="" />
                                <span></span>
                                <p><%#Eval("s_place")%></p>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:DataList>
                <%-- 
                <li>
                    <img src="img/libo.jpg" alt="" />
                    <span></span>
                    <p>荔波</p>
                </li>
                <li>
                    <img src="img/malai.jpg" alt="" />
                    <span></span>
                    <p>马来西亚</p>
                </li>
                <li>
                    <img src="img/rongshui.jpg" alt="" />
                    <span></span>
                    <p>融水</p>
                </li>
                <li>
                    <img src="img/shannan.jpg" alt="" />
                    <span></span>
                    <p>山南</p>
                </li>
                <li>
                    <img src="img/shilin.jpg" alt="" />
                    <span></span>
                    <p>石林</p>
                </li>
                <li>
                    <img src="img/shanqiu.jpg" alt="" />
                    <span></span>
                    <p>山丘</p>
                </li>
                <li>
                    <img src="img/xian.jpg" alt="" />
                    <span></span>
                    <p>西安</p>
                </li>--%>
            </ul>

        </div>


    </div>
    <div class="pinpai">
        <p class="wenzi">
            出境游    
        </p>
        <p class="more"><a href="#">更多>></a></p>
    </div>
    <div class="chujingyou">
        <div class="chujingyou-l">
            <ul>
                <asp:DataList ID="DataList4" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal" RepeatColumns="4">
                    <ItemTemplate>
                        <li class="li11 tututu" style="margin-left: 13px">
                            <img src='<%#Eval("s_picture")%>' alt="" style="width: 360px" />
                            <a href='LookPlace.aspx?u_id=<%#Eval("u_id")%>'>
                                <span><%#Eval("s_place")%></span>
                            </a>
                            <div class="heibu" style="width: 360px"><%#Eval("s_place")%></div>
                        </li>
                    </ItemTemplate>
                </asp:DataList>

                <asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataSource3" RepeatDirection="Horizontal" RepeatColumns="4">
                    <ItemTemplate>
                        <li class="tututu">
                            <img src='<%#Eval("s_picture")%>' alt="" />
                            <a href='LookPlace.aspx?u_id=<%#Eval("u_id")%>'>
                                <span><%#Eval("s_place")%></span>
                            </a>
                            <div class="heibu"><%#Eval("s_place")%></div>
                        </li>
                    </ItemTemplate>
                </asp:DataList>

            </ul>
        </div>
        <div class="chujingyou-r">
            <span></span>
            <img src="../img/cheshow.jpg" alt="" />
            <div class="show">
                <ul>
                    <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource4" RepeatDirection="Horizontal" RepeatColumns="1">
                        <ItemTemplate>
                            <li><a href='LookActicle.aspx?u_id=<%#Eval("u_id")%>'>【游记】<%#Eval("t_title")%></a></li>
                        </ItemTemplate>
                    </asp:DataList>

                    <%--<li><a href="#">【游记】自驾重庆武隆风景区</a></li>
                    <li><a href="#">【游记】无止境之征探索未历之美</a></li>
                    <li><a href="#">【游记】骏雅新派逛古都</a></li>
                    <li><a href="#">【游记】奥迪2015国际露营大会</a></li>--%>
                </ul>
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

