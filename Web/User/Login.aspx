<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <script src="../jQuery.isc/jquery-image-scale-carousel-condensed.js"></script>
    <script src="../jQuery.isc/jquery-image-scale-carousel.js"></script>
    <link href="../jQuery.isc/jQuery.isc.css" rel="stylesheet" />
    <link href="../jQuery.isc/lib.css" rel="stylesheet" />

    <link href="../css/LoginStyle.css" rel="stylesheet" />

    <script>
        var imglist = [
            "../img/1.jpg",
            "../img/2.jpg",
            "../img/r3.jpg",
            "../img/4.jpg",
            "../img/5.jpg",
            "../img/6.jpg",
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
        <div id="loginright">

            <section class="container">
                <div class="login">
                    <h1>用户登录</h1>

                    <p>

                
                        <input type="email" id="txt_emaile" placeholder="邮箱号" runat="server" />
                       <%-- <asp:TextBox ID="txt_emaile" runat="server" placeholder="邮箱号" />--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="邮箱不能为空！"
                            ControlToValidate="txt_emaile"
                            Display="None">
                        </asp:RequiredFieldValidator>
                    </p>

                    <p>
                        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" placeholder="密码" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="密码不能为空！"
                            ControlToValidate="txt_password"
                            Display="None">
                        </asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                            TargetControlID="RequiredFieldValidator1"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>
                    </p>


                    <p class="remember_me">
                        <label>
                            <input type="checkbox" name="remember_me" id="remember_me">
                            记住密码
                        </label>
                    </p>

                    <p class="submit">
                        <%-- <input type="submit" name="commit" value="登录1">--%>

                        <asp:Button ID="btn_Login" Text="登录" runat="server" OnClick="btn_Login_Click" />
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                            TargetControlID="RequiredFieldValidator2"
                            PopupPosition="Right">
                        </asp:ValidatorCalloutExtender>

                    </p>

                </div>

                <div class="login-help">
                    <p>还没注册?<a href='<%=ResolveUrl("User_Regist.aspx") %>'>点击注册</a></p>
                </div>

            </section>

        </div>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

