using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_AddPlace : System.Web.UI.Page
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
    protected void sure_Click(object sender, EventArgs e)
    {
        
        Travel.Model.Tab_place tab_place = new Travel.Model.Tab_place();
     

        if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
        {
            string type= DropDownList1.Text.Trim();
            string title = biaoti.Text.Trim();
            string t_content = Editor1.Text.Trim(); //获取编辑器里面的值

            tab_place.U_emaile = Convert.ToString(Session["u_emaile"]);//从session中获取u_emaile
            tab_place.S_place = title;
            tab_place.S_introduce = t_content;
            tab_place.S_type = type;
            tab_place.S_update = DateTime.Now;
            tab_place.S_picture = "art_img\\" + Guid.NewGuid().ToString("D") + ".jpg";//获取插图路径
           
            FileUpload1.SaveAs(Server.MapPath(tab_place.S_picture));

            tab_place.S_ClickNumber = 0;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(t_content))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先填写完整数据！')</script>");
            }
            else
            {
                if(Travel.BLL.PlaceBusiness.AddPlace(tab_place))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('添加目的地成功！')</script>");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('失败!请重新尝试！')</script>");

                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请选择JPG图片！')</script>");
        }
    }
}