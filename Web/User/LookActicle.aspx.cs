using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_LookActicle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "";
        if (Convert.ToString(Session["u_emaile"]) == str)
        {
            (Master.FindControl("lab_denglu") as Button).Text = "登录";
            (Master.FindControl("lab_loginoff") as Button).Visible = false;
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先登录！')</script>");
            //跳转到指定界面
            Response.Redirect("Login.aspx");
        }
        else
        {
            //把用户登录后session 交给登录按钮
            (Master.FindControl("lab_denglu") as Button).Text = Convert.ToString(Session["u_emaile"]);
            (Master.FindControl("lab_loginoff") as Button).Visible = true;
            (Master.FindControl("lab_loginoff") as Button).Text = "注销";

            string u_id = Request.QueryString["u_id"];//从评论表中获取u_id
            Session["u_id"] = u_id;//将u_id保存在session中

            ////通过u_id获取游记作者
            //Travel.Model.Tab_discuss discuss = new Travel.Model.Tab_discuss();
            //discuss.U_emaileA = Travel.BLL.DiscussBusiness.GetDiscussById(Convert.ToInt32(Session["u_id"])).U_emaileA;
            ////将游记作者保存在seeion中
            //Session["u_emaile"] = discuss.U_emaileA;

            ////通过作者获取游记标题
            //Travel.Model.Tab_article article = new Travel.Model.Tab_article();
            //article.T_title = Travel.BLL.ArticleBusiness.GetArticleByEmaile(Convert.ToString(Session["u_emaile"])).T_title;
            ////将游记标题保存在session中
            //Session["t_title"] = article.T_title;

        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["u_id"] != null)
            {
                int u_id = Convert.ToInt32(Request.QueryString["u_id"]);
                Travel.BLL.ArticleBusiness.ChangeClickNumber(u_id);
            }
        }

        
    }
    /// <summary>
    /// 创建评论
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_sure_Click(object sender, EventArgs e)
    {
        string discuss = neirong.Text.Trim();//获取评论的内容
        Travel.Model.Tab_article tab_article = new Travel.Model.Tab_article();

        Travel.Model.Tab_discuss tab_discuss = new Travel.Model.Tab_discuss();
        tab_discuss.U_discuss = discuss;
        tab_discuss.U_emaileA = Travel.BLL.ArticleBusiness.GetArctileById(Convert.ToInt32(Session["u_id"])).U_emaile;
        tab_discuss.U_emaileB = Convert.ToString(Session["u_emaile"]);
        tab_discuss.UploadTime = DateTime.Now;//获取当前时间
        if(string.IsNullOrEmpty(tab_discuss.U_emaileB))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先登录！')</script>");
            //跳转到指定界面
            Response.Redirect("Login.aspx");

        }
        else
        {
            if (string.IsNullOrEmpty(discuss))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先填写完整数据！')</script>");

            }
            else
            {
                if(Travel.BLL.DiscussBusiness.AddDiscuss(tab_discuss))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('评论成功！')</script>");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请重新尝试！')</script>");

                }
            }
        }
       

        

    }

}