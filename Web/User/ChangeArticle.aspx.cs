using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChangeArticle : System.Web.UI.Page
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
        }
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "sure")
        {

            string title = "";
            string content = "";
            for (int i = 0; i < this.DataList1.Items.Count; i++)
            {
                TextBox Title = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("biaoti"));
                TextBox Content = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("content"));
                title = Title.Text.Trim();//获取值
                content = Content.Text.Trim();
            }

            Travel.Model.Tab_article tab_article = new Travel.Model.Tab_article();

            tab_article.U_id = Convert.ToInt32(Request.QueryString["u_id"]);//从个人资料里获取u_id
            tab_article.T_title = title;
            tab_article.T_content = content;
            tab_article.UploadTime = DateTime.Now;//获取当前时间
            tab_article.Art_ClickNumber = 0;
            if (Travel.BLL.ArticleBusiness.ChangeArticle(tab_article))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('修改游记成功！')</script>");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请重新尝试！')</script>");

            }
        }

    }
}