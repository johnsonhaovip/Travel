using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        //string u_emaile = txt_emaile.Text.Trim();
        string u_emaile = txt_emaile.Value.Trim();
        string u_password = txt_password.Text.Trim();

        if (string.IsNullOrEmpty(u_emaile) || string.IsNullOrEmpty(u_password))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('账号或密码不能为空')</script>");
        }
        else
        {
            if (Travel.BLL.UserBusiness.Login(u_emaile, u_password))
            {
                //登录成功
                Session["u_emaile"] = u_emaile;
                Session["LastLoginTime"] = DateTime.Now.ToString();

                //给当前用户颁发一个身份凭证
                FormsAuthentication.RedirectFromLoginPage(u_emaile, false);


                //跳转到指定界面
                Response.Redirect("Personal_Detail.aspx");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('账号或密码输入错误！请重试')</script>");
            }
        }
    }
}