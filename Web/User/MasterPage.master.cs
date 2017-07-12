using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "";
        if (Convert.ToString(Session["u_emaile"]) == str)
        {
            lab_denglu.Text = "登录";
           
            lab_loginoff.Visible = false;
       
        }
        else
        {
            //把用户登录后session 交给登录按钮
           
            lab_denglu.Text = Convert.ToString(Session["u_emaile"]);
            lab_loginoff.Visible = true;
            lab_loginoff.Text = "注销";
            
            string u_id = Request.QueryString["u_id"];//从个人资料里获取u_id
            Session["u_id"] = u_id;//将u_id保存在session中

        }

    }
    protected void lab_loginoff_Click(object sender, EventArgs e)
    {
        Session["u_emaile"] = "";
        Response.Redirect("Index.aspx");
    }
    protected void lab_denglu_Click(object sender, EventArgs e)
    {
       // href='<%=ResolveUrl("Login.aspx") %>'
        //跳转到指定界面
        Response.Redirect("Login.aspx");
    }
    protected void lab_zhuce_Click(object sender, EventArgs e)
    {
        //href='<%=ResolveUrl("User_Regist.aspx") %>'
        Response.Redirect("User_Regist.aspx");
    }
}
