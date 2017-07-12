using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "";
        if (Convert.ToString(Session["u_emaile"]) == str)
        {
            (Master.FindControl("lab_denglu") as Button).Text = "登录";
            (Master.FindControl("lab_loginoff") as Button).Visible = false;
        }
        else
        {
            //把用户登录后session 交给登录按钮
            (Master.FindControl("lab_denglu") as Button).Text = Convert.ToString(Session["u_emaile"]);
            (Master.FindControl("lab_loginoff") as Button).Visible = true;
            (Master.FindControl("lab_loginoff") as Button).Text = "注销";
            string u_id = Request.QueryString["u_id"];//从个人资料里获取u_id
            Session["u_id"] = u_id;//将u_id保存在session中

        }
    }
}