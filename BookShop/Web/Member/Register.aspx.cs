using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if(CheckValidateCode())
                {
                    Model.Users user = new Model.Users();
                    user.UserStateId = new Model.UserStates();
                    user.LoginId = Request.Form["txtUserName"];
                    user.Name = Request.Form["txtRealName"];
                    user.LoginPwd = Request.Form["txtPwd"];
                    user.Mail = Request.Form["txtEmail"];
                    user.Address = Request.Form["txtAddress"];
                    user.Phone = Request.Form["txtPhone"];
                    user.UserStateId.Id = 1;
                    BLL.Users bll = new BLL.Users();
                    string msg = string.Empty;
                    int id = bll.Add(user,out msg);
                    if(id > 0 )
                    {
                        //发送激活链接
                        //跳转

                        Response.Redirect("/ShowMsg.aspx?msg=" + Server.UrlEncode(msg)
                            + "&txt=" + Server.UrlEncode("首页")
                            + "&url=/Default.aspx");
                    }
                }
            }

        }

        private bool CheckValidateCode()
        {
            if (!string.IsNullOrEmpty(Session["vCode"].ToString()))
            {
                string sysCode = Session["vCode"].ToString();
                string txtCode = Request.Form["txtCode"].ToString();
                if(sysCode.Equals(txtCode,StringComparison.InvariantCultureIgnoreCase))
                {
                    Session["vCode"] = null;
                    return true;
                }
            }
            return false;
        }
    }
}