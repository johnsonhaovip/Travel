using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel.BLL;
using Travel.Model;
using Travel.DAL;
using System.Web.Security;

public partial class commitroute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //"123,46;345,123;45,123"
        String route = Request["route"];
        //BLL.addModel(route); 
        Response.ContentType = "text/json";
        Response.Write("{'code':0,'errorinfo'}");

        Tab_travel tab_travel = new Tab_travel();
        Travel.Model.Tab_travel ta = new Tab_travel();
        ta.T_day1 = route;
        ta.U_emaile = "987654321@qq.com";


        Travel.BLL.TravelBusiness.AddTravel(tab_travel);

        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('成功')</script>");


        //string u_emaile = "987654321@qq.com";
        //string u_password = "jianghao";

        //if (string.IsNullOrEmpty(u_emaile) || string.IsNullOrEmpty(u_password))
        //{
        //    Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('账号或密码不能为空')</script>");
        //}
        //else
        //{
        //    if (Travel.BLL.UserBusiness.Login(u_emaile, u_password))
        //    {
        //        //登录成功
        //        Session["u_emaile"] = u_emaile;
        //        Session["LastLoginTime"] = DateTime.Now.ToString();

        //        //给当前用户颁发一个身份凭证
        //        FormsAuthentication.RedirectFromLoginPage(u_emaile, false);
        //        //跳转到指定界面
        //        Response.Redirect("User/Personal_details.aspx");

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('账号或密码输入错误！请重试')</script>");
        //    }
        //}



    }
}