<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="User_Regist.aspx.cs" Inherits="User_User_Regist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <script src="../jQuery.isc/jquery-image-scale-carousel-condensed.js"></script>
    <script src="../jQuery.isc/jquery-image-scale-carousel.js"></script>
    <link href="../jQuery.isc/jQuery.isc.css" rel="stylesheet" />
    <link href="../jQuery.isc/lib.css" rel="stylesheet" />

    <link href="../css/RegistStyle.css" rel="stylesheet" />

    <script>
        var imglist = [
            "../img/r1.jpg",
            "../img/r2.jpg",
            "../img/r3.jpg",
            "../img/r4.jpg",
            "../img/r5.jpg",
            "../img/r6.jpg",
            "../img/r7.jpg"
        ]
        $(function () {
            $("#loginleft").isc({
                imgArray: imglist,
                autoplay: true,
                autoplayTimer: 3000
            })
        })
    </script>


    <div id="loginContent">
        <div id="loginleft">
        </div>

        <div id="registright">
            <div class="container">

                <div class="regist">
                    <h1>用户注册</h1>

                    <p>
                        <%--<asp:TextBox ID="txt_emaile" runat="server" placeholder="邮箱号" />--%>
                        <input type="email" id="txt_emaile" placeholder="邮箱号" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="邮箱不能为空！"
                            ControlToValidate="txt_emaile"
                            Display="None"> </asp:RequiredFieldValidator>
                    </p>

                    <p>
                        <asp:TextBox ID="txt_name" runat="server" placeholder="昵称" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="昵称不能为空！"
                            ControlToValidate="txt_name"
                            Display="None"> </asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                            TargetControlID="RequiredFieldValidator1"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>
                    </p>

                    <p>
                        <asp:TextBox ID="txt_password" runat="server" placeholder="密码" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="密码不能为空！"
                            ControlToValidate="txt_password"
                            Display="None"> </asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                            TargetControlID="RequiredFieldValidator2"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                    </p>
                    <p>

                        <asp:TextBox ID="re_password" placeholder="再次输入密码" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="请再次输入密码！"
                            ControlToValidate="re_password"
                            Display="None"> </asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                            TargetControlID="RequiredFieldValidator3"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                    </p>


                    <p class="submit">
                        <asp:Button ID="btn_Regist" Text="注册" runat="server" OnClick="btn_zhuce_Click" />
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                            TargetControlID="RequiredFieldValidator4"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                    </p>


                    
                    <div class="regist-help">
                        <p>已经有账号?<a href='<%=ResolveUrl("Login.aspx") %>'>点击登录</a></p>
                    </div>

                </div>

            </div>

        </div>



    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

