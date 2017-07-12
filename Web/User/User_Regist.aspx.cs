using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_User_Regist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btn_zhuce_Click(object sender, EventArgs e)
    {
        
        //string u_emaile = txt_emaile.Text.Trim();
        string u_emaile = txt_emaile.Value.Trim();
        string u_password = txt_password.Text.Trim();
        string u_name = txt_name.Text.Trim();
        string u_re_password = re_password.Text.Trim();

        DateTime lastLoginTime = DateTime.Now;

        Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
        tab_user.U_emaile = u_emaile;
        tab_user.U_name = u_name;
        tab_user.U_password = u_password;
        tab_user.LastLoginTime = lastLoginTime;

        if (string.IsNullOrEmpty(u_emaile) || string.IsNullOrEmpty(u_password))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('账户和密码不能为空！')</script>");
        }
        else
        {
            if (u_password != u_re_password)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('两次密码不想同！')</script>");

            }
            else
            {
                if (Travel.BLL.UserBusiness.UserIsExist(u_emaile))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('该用户已存在！')</script>");
                }
                else
                {
                    if (Travel.BLL.UserBusiness.AddUser(tab_user))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('注册成功！')</script>");
                        //将用户放进Session里
                        Session["u_emaile"] = u_emaile;
                        //给用户颁发一个身分凭证
                        FormsAuthentication.RedirectFromLoginPage(u_emaile, false);
                        Response.Redirect("Personal_Detail.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('用户注册失败！')</script>");
                    }
                }
            }
        }
    }
}